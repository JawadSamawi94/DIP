using DIP.Interfaces;

namespace DIP
{
    public class CardPayment : IPayment
    {
        public int Total { get; set; }
        public double Discount { get; set; }
        public CardPayment(int total, int discount)
        {
            Total = total;
            Discount = discount/100;
        }
        public CardPayment()
        {
        }
        public string Pay()
        {
            if (Discount < 1 && 0 < Discount) {
                double totalAfterDiscount = Total - (Total * Discount);
                Console.WriteLine($"Payment Successful. Total: {Total}, After Discount {totalAfterDiscount}");
                return $"Payment Successful. Total: {Total}, After Discount {totalAfterDiscount}";
            } else {
                throw new Exception("Discount is not Valid");
            }
        }
    }
}
