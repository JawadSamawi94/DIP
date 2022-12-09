namespace DIP.Interfaces
{
    public interface IPayment
    {
        public int Total { get; set; }
        public double Discount { get; set; }

    }
}
