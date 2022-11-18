using DIP.Interfaces;
namespace DIP.Models
{
    public class CardPayment : IPayment
    {
        public int Total { get; set; }
        public double Discount { get; set; }
        public CardPayment(int total, double discount)
        {
            Total = total;
            Discount = discount;
        }
    }
}
