using HelperPayment.Core.Models.Offer.Exceptions;

namespace HelperPayment.Core.Models.Offer.ValueObjects
{
    public sealed record InquiryId
    {
        public Guid Value { get; }

        public InquiryId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(InquiryId data) => data.Value;

        public static implicit operator InquiryId(Guid value) => new(value);
    }
}
