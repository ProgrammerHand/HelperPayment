﻿namespace HelperPayment.Core.Utility
{
    public interface IDataAudit
    {
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }

    }
}
