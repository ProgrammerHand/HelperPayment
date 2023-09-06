using HelperPayment.Core.Models.Offer.Exceptions;

namespace HelperPayment.Core.Models.Offer.ValueObjects
{
    public sealed record SolutionCloudStorage
    {
        public string Value { get; }

        public SolutionCloudStorage(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new StorageLinkEmptyException();
            }
            Value = value;

        }

        public SolutionCloudStorage()
        {
        }
    }
}
