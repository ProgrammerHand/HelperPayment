namespace HelperPayment.Shared.Events
{
    public sealed record InvoicePaidEvent()
    {
        public Guid OfferId { get; set; }
    }
}
