
namespace Pension.Service.Contracts.Objects
{
    public class PaymentData
    {
        public List<PaymentYear> Items { get; set; }
    }
    public class PaymentYear
    {
        public int Year { get; set; }
        public List<decimal> ForPens { get; set; }
    }
}
