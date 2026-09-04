using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;
using TaskApi.Enums;
using TaskApi.Models;
using TaskApi.helpers;

namespace TaskApi.Authorization
{
    public class TaskAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Tasks>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Tasks resource)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var roleClaim = context.User.FindFirst(ClaimTypes.Role)?.Value;

            if (roleClaim == Role.Admin.ToString())
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            if (roleClaim == Role.Moderator.ToString())
            {
                if (requirement.Name == Operations.Update.Name)
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }

                if (requirement.Name == Operations.Delete.Name)
                {
                    if (resource.User?.Role == Role.Admin)
                    {
                        return Task.CompletedTask;
                    }

                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }

            if (resource.UserId.ToString() == userId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}