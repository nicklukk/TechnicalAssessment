using System.Threading;
using System.Threading.Tasks;
using TechnicalAssessment.Api.Models;

namespace TechnicalAssessment.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ITechnicalAssessmentContext technicalAssessmentContext;

        public UserRepository(ITechnicalAssessmentContext technicalAssessmentContext)
        {
            this.technicalAssessmentContext = technicalAssessmentContext;
        }

        public async Task<User> CreateAsync(ApiModels.UserCreateModel userCreateModel, CancellationToken cancelationToken)
        {
            var user = new User
            {
                Id = System.Guid.NewGuid(),
                UserName = userCreateModel.UserName,
                Password = userCreateModel.Password,
                FullName = userCreateModel.FullName
            };

            await technicalAssessmentContext.Users.AddAsync(user, cancelationToken);
            await technicalAssessmentContext.SaveChangesAsync(cancelationToken);

            return user;
        }
    }
}
