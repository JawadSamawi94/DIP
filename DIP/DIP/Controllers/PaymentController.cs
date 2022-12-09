using DIP.Interfaces;
using DIP.Models;
using Microsoft.AspNetCore.Mvc;

namespace DIP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService<CardPayment> _paymentService;
        public PaymentController (IPaymentService<CardPayment> paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public ActionResult Pay(int total, double discount)
        {
            var payment = new CardPayment(total, discount);
            return Ok(_paymentService.Pay(payment));
        }
    }
}
