namespace HelperPayment.Core.Models.Offer
{
    public interface IOfferRepository
    {
        Task<Offer> GetByIdAsync(OfferId offer);
    }
}
