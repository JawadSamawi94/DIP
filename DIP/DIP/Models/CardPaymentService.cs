using DIP.Interfaces;

namespace DIP
{
    public class CardPaymentService<CardPayment> : IPaymentService<CardPayment> where CardPayment : IPayment
    {
        public string Pay(CardPayment payment )
        {
            if (ValidDiscount(payment.Discount)) {
                double totalAfterDiscount = payment.Total - (payment.Total * payment.Total / 100);
                return $"Payment Successful. Total: {payment.Total}, After Discount {totalAfterDiscount}";
            } else {
                throw new Exception("Discount is not Valid");
            }
        }

        public bool ValidDiscount(double discount)
        {
            return discount.IsBetween(0, 100);
        }
    }
}
