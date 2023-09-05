using HelperPayment.Core.Utility;

namespace Helper.Infrastructure
{
    public class ClockCustom : IClockCustom
    {
        public DateTime Now => DateTime.UtcNow;

    }
}
