using DIP.Interfaces;
using DIP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService<IPayment> _paymentService;
        public PaymentController (IPaymentService<IPayment> paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public ActionResult Pay(int total, double discount)
        {
            IPayment payment = new CardPayment(total, discount);
            return Ok(_paymentService.Pay(payment));
        }
    }
}
