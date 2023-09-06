namespace HelperPayment.Core.External
{
    public interface IRowVersionControl
    {
        public byte[] RowVersion { get; }
    }
}
