using System.Globalization;
namespace DIP.Models
{
    public class DIPException : Exception
    {
        public DIPException() : base() { }

        public DIPException(string message) : base(message) { }

        public DIPException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
