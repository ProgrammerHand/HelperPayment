namespace HelperPayment.Core.Models.Offer.ValueObjects
{
    public sealed record AcceptanceStatus
    {
        public Status Value { get; }

        public AcceptanceStatus(Status status)
        {
            Value = status;
        }

        public static implicit operator Status(AcceptanceStatus data) => data.Value;

        public static implicit operator AcceptanceStatus(Status value) => new(value);
    }
}
