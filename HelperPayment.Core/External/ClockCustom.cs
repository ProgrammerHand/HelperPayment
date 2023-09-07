namespace HelperPayment.Core.External
{
    public class ClockCustom : IClockCustom
    {
        public DateTime Now => DateTime.UtcNow;

    }
}
