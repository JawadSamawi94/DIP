using DIP.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private IPayment _paymentService;
        public PaymentController (IPayment paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public ActionResult Pay(int total, double discount)
        {
            try
            {
                _paymentService.Total = total;
                _paymentService.Discount = discount / 100;
                return Ok(_paymentService.Pay());
            }
            catch
            {
                return View();
            }
        }
    }
}
