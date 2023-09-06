namespace HelperPayment.Core.External
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; }
        public DateTime? DeletedAt { get; }
    }
}
