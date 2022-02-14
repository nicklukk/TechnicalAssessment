using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Core.Configuration
{
    public class SqlServerOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
