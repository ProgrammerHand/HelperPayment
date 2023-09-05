namespace HelperPayment.Core.Utility
{
    public interface IRowVersionControl
    {
        public byte[] RowVersion { get; }
    }
}
