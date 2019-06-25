using System.Linq;
using hacker2019_bester.Data;
using hacker2019_bester.Repository.HealthCheck;

namespace hacker2019_bester.Repository
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly Context _context;

        public HealthCheckRepository(Context context)
        {
            this._context = context;
        }

        public string getMessageHealthCheck()
        {
            Models.HealthCheck model = _context.HealthCheck.SingleOrDefault(e => e.id == 1);
            return model.message;
        }
    }
}
