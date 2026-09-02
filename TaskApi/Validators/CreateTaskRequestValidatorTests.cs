using TaskApi.Dtos;
using Xunit;

namespace TaskApi.Validators
{
    public class CreateTaskRequestValidatorTests
    {
        private readonly CreateTaskRequestValidator _validator = new();

        [Fact]
        public void EmptyTitle_ShouldHaveError()
        {
            var request = new CreateTaskRequestDto { Title = "" };
            var result = _validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Title" && e.ErrorMessage == "Title is required");
        }

        [Fact]
        public void TitleOver200Chars_ShouldHaveError()
        {
            var request = new CreateTaskRequestDto { Title = new string('a', 201) };
            var result = _validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Title" && e.ErrorMessage.Contains("200"));
        }

        [Fact]
        public void TitleWithHtml_ShouldHaveError()
        {
            var request = new CreateTaskRequestDto { Title = "<script>alert(1)</script>" };
            var result = _validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("HTML"));
        }

        [Fact]
        public void PastDueDate_ShouldHaveError()
        {
            var request = new CreateTaskRequestDto { Title = "Valid title", DueDate = DateTime.Now.AddDays(-1) };
            var result = _validator.Validate(request);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.ErrorMessage.Contains("future"));
        }

        [Fact]
        public void ValidRequest_ShouldNotHaveErrors()
        {
            var request = new CreateTaskRequestDto { Title = "Valid title", DueDate = DateTime.Now.AddDays(1) };
            var result = _validator.Validate(request);

            Assert.True(result.IsValid);
        }
    }
}
