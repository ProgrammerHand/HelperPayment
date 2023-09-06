using HelperPayment.Core.External;

namespace HelperPayment.Core
{
    public class ClockCustom : IClockCustom
    {
        public DateTime Now => DateTime.UtcNow;

    }
}
