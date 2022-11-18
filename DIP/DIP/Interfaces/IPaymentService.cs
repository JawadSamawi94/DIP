namespace DIP.Interfaces
{
    public interface IPaymentService<T> where T : IPayment
    {
        public string Pay(T payment);
        public bool ValidDiscount(double discount);
    }
}
