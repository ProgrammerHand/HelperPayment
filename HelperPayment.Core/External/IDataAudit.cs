namespace HelperPayment.Core.External
{
    public interface IDataAudit
    {
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

    }
}
