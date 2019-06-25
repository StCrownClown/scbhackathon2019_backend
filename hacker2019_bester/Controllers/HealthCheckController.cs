using hacker2019_bester.Models;
using Microsoft.AspNetCore.Mvc;

namespace hacker2019_bester.Controllers
{
    public class HealthCheckController : Controller
    {
        public HealthCheckController()
        {

        }

        [HttpGet("api/healthcheck")]
        public HealthCheckResponse HeathCheck()
        {
            HealthCheckResponse model = new HealthCheckResponse
            {
                status = new Status { code = 777, description = "Very Good :)" },
                version = "0.1"
            };

            return model;
        }
    }
}
