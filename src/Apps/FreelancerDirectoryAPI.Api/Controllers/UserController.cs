using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;
using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Api.Controllers
{
    [Route("api/user")]   
    public class UserController : BaseApiController
    {
        // Get users with pagination
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves a paginated list of users based on the provided parameters.")]
        [SwaggerResponse(200, "Returns the paginated list of users.", typeof(ServiceResult<PaginatedList<ApplicationUserDto>>))]
        [SwaggerResponse(400, "If there is an error in the query parameters.")]
        public async Task<ActionResult<ServiceResult<PaginatedList<ApplicationUserDto>>>> GetAllUsersWithPagination([FromQuery] GetUsersWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a single user by their unique identifier.")]
        [SwaggerResponse(200, "Returns the requested user if found.", typeof(ServiceResult<ApplicationUserDto>))]
        [SwaggerResponse(404, "If no user is found with the specified ID.")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> GetUserById(string id)
        {
            var query = new GetUserByIdCommand { Id = id };
            return Ok(await Mediator.Send(query));
        }

        // Create a new user
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Creates a new user with the specified details.")]
        [SwaggerResponse(200, "The user was successfully created.", typeof(ServiceResult<ApplicationUserDto>))]
        [SwaggerResponse(400, "If the user data is invalid.")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        // Update an existing user
        [HttpPut("update/{id}")]
        [SwaggerOperation(Summary = "Updates an existing user with the specified ID.")]
        [SwaggerResponse(200, "The user was successfully updated.", typeof(ServiceResult<ApplicationUserDto>))]
        [SwaggerResponse(400, "If the user data is invalid or the IDs do not match.")]
        public async Task<ActionResult<ServiceResult<ApplicationUserDto>>> UpdateUser(string id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Mismatched user ID");
            }
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        // Delete a user
        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Summary = "Deletes a user with the specified ID.")]
        [SwaggerResponse(200, "The user was successfully deleted.", typeof(ServiceResult))]
        [SwaggerResponse(400, "If no user is found with the specified ID or an error occurs during deletion.")]
        public async Task<ActionResult<ServiceResult>> DeleteUser(string id)
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
