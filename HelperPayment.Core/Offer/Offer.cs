using HelperPayment.Core.Offer.ValueObjects;
using HelperPayment.Core.Utility;

namespace HelperPayment.Core.Offer
{
    public class Offer : ISoftDelete, IRowVersionControl, IDataAudit
    {
        public OfferId Id { get; private set; }
        public InquiryId InquiryId { get; private set; }
        public UserId CustomerId { get; private set; }
        public OfferDescription Description { get; private set; }
        public OfferPrice? Price { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public SolutionCloudStorage? SolutionStorage { get; private set; }
        public DateTime RealisationStartDate { get; private set; }
        public bool IsDraft { get; private set; } = true;
        public bool IsVerified { get; private set; } = false;
        public AcceptanceStatus Status { get; private set; } = new(ValueObjects.Status.awaits_decision);
        public OfferRejectReason? ClientsReason { get; private set; }
        public byte[] RowVersion { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private Offer()
        {
        }

    }
}
