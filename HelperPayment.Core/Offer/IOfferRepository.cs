namespace HelperPayment.Core.Offer
{
    public interface IOfferRepository
    {
        Task<Offer> GetByIdAsync(OfferId offer);
    }
}
