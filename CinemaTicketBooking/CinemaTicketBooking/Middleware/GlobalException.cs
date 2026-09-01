using CinemaTicketBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBooking.Exceptions
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(RequestDelegate next, ILogger<GlobalException> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (MovieNotFoundException ex)
            {
                await WriteProblemDetails(context, 404, " Movie Not Found", ex.Message);
            }
            catch (BookingNotFoundException ex)
            {
                await WriteProblemDetails(context, 404, "Booking Not Found", ex.Message);
            }
            catch(ShowTimeNotFoundException ex)
            {
                await WriteProblemDetails(context, 404, "ShowTime Not Found", ex.Message);
            }
            catch(CustomerNotFoundException ex)
            {
                await WriteProblemDetails(context, 404, "Customer Not Found", ex.Message);
            }
            catch(MovieAlreadyExistsException ex)
            {
                await WriteProblemDetails(context, 404, "Duplicate Movie Title", ex.Message);
            }
            catch(InvalidBookingException ex)
            {
                await WriteProblemDetails(context, 404, "Invalid Booking", ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                await WriteProblemDetails(context, 500, "Internal Server Error", "An unexpected error occurred");
            }
        }


        public async Task WriteProblemDetails(HttpContext ctx, int status, string title, string detail)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/problem+json";

            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Instance = ctx.Request.Path
            };
            await ctx.Response.WriteAsJsonAsync(problem);
        }
    }
}
