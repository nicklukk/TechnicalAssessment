using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.ApiModels;
using TechnicalAssessment.Api.BL;

namespace TechnicalAssessment.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<User> CreateUser([FromBody] UserCreateModel model, CancellationToken cancelationToken)
        {
            var user = await userService.CreateAsync(model, cancelationToken);

            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName
            };
        }
    }
}
