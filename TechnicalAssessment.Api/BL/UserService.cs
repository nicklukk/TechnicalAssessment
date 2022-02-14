using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;
using TechnicalAssessment.Api.Repositories;

namespace TechnicalAssessment.Api.BL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> CreateAsync(ApiModels.UserCreateModel userCreateModel, CancellationToken cancelationToken)
        {
            return await repository.CreateAsync(userCreateModel, cancelationToken);
        }
    }
}
