using DIP.Interfaces;
using DIP.Models;

namespace DIP
{
    public class CardPaymentService : IPaymentService<CardPayment>
    {
        private LogBase _logBase = new FileLogger();
        public string Pay(CardPayment payment )
        {
            if (ValidDiscount(payment.Discount)) {
                var discountAmount = payment.Total * payment.Discount / 100;
                double totalAfterDiscount = payment.Total - discountAmount;
                var resp = $"Payment Successful. Total: {payment.Total}, After Discount {totalAfterDiscount}";
                _logBase.Log($"{resp}");
                return resp;
            } 
            else
            {
                throw new DIPException("Discount is not Valid");
            }
        }

        public bool ValidDiscount(double discount)
        {
            return discount.IsBetween(0, 100);
        }
    }
}
