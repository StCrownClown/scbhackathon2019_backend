using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hacker2019_bester.Models
{
    public class HealthCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(true)]
        [Column("id")]
        public int id { get; set; }

        [Column("message")]
        public string message { get; set; }
    }

    public class HealthCheckResponse : BaseResponse
    {
        public string version { get; set; }
    }
}
