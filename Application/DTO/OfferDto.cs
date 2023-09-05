﻿namespace HelperPayment.Application.DTO
{
    public sealed record OfferDto
    {
        public Guid Id { get; set; }
        public Guid InquiryId { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsDraft { get; set; }
        public string Status { get; set; }
        public string? ClientsReason { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
