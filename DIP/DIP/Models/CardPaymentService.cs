using DIP.Interfaces;
using DIP.Models;

namespace DIP
{
    public class CardPaymentService : IPaymentService<CardPayment>
    {
        public string Pay(CardPayment payment )
        {
            if (ValidDiscount(payment.Discount)) {
                var discountAmount = payment.Total * payment.Discount / 100;
                double totalAfterDiscount = payment.Total - discountAmount;
                return $"Payment Successful. Total: {payment.Total}, After Discount {totalAfterDiscount}";
            } else {
                throw new DIPException("Discount is not Valid");
            }
        }

        public bool ValidDiscount(double discount)
        {
            return discount.IsBetween(0, 100);
        }
    }
}
