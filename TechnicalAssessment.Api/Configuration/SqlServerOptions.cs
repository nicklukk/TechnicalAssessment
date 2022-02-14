using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Api.Configuration
{
    public class SqlServerOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
