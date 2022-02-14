using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(ApiModels.UserCreateModel userCreateModel, CancellationToken cancelationToken);
    }
}
