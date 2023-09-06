namespace HelperPayment.Core.Models.Offer.Policies
{
    public interface IDiscounter
    {
        double CalculateDiscount(double price);
    }
}
