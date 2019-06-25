using Microsoft.AspNetCore.Mvc;

namespace hacker2019_bester.Controllers
{
    public class QRController : Controller
    {
        public QRController()
        {

        }

        [HttpPost("api/qr")]
        public void GenerateQRCode([FromBody] string uID)
        {
            return;
        }
    }
}
