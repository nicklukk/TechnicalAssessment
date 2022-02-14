using System;

namespace TechnicalAssessment.Api.ApiModels
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }
    }
}
