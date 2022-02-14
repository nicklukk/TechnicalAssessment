using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.BL
{
    public interface IUserService
    {
        Task<User> CreateAsync(ApiModels.UserCreateModel userCreateModel, CancellationToken cancelationToken);
    }
}
