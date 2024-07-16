using FluentValidation.TestHelper;
using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;
using FreelancerDirectoryAPI.Application.ApplicationUser.Validation;
using NUnit.Framework;

namespace FreelancerDirectoryAPI.Application.UnitTests.Common.Validations
{


    [TestFixture]
    public class CreateUserCommandValidatorTests
    {
        private CreateUserCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CreateUserCommandValidator();
        }

        [TestCase("")]
        [TestCase(null)]
        public void UserName_ShouldHaveErrorWhenEmptyOrNull(string userName)
        {
            var command = new CreateUserCommand { UserName = userName, Email = "test@example.com" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.UserName)
                  .WithErrorMessage("Username is required.");
        }

        [TestCase("us")] 
        [TestCase("thisisaverylongusernamebeyondtheallowedrange")] 
        public void UserName_ShouldHaveErrorWhenLengthIsInvalid(string userName)
        {
            var command = new CreateUserCommand { UserName = userName, Email = "test@example.com" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.UserName)
                  .WithErrorMessage("Username must be between 3 and 20 characters.");
        }

        [TestCase("test")] 
        [TestCase("test@")] 
        [TestCase("@example.com")] 
        public void Email_ShouldHaveErrorWhenFormatIsInvalid(string email)
        {
            var command = new CreateUserCommand { UserName = "validUser", Email = email };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                  .WithErrorMessage("Email must be a valid email address.");
        }

        [Test]
        public void Should_PassForValidCommand()
        {
            var command = new CreateUserCommand { UserName = "validUser", Email = "valid@example.com" };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }

}
