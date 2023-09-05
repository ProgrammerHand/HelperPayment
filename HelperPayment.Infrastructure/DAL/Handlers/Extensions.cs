using HelperPayment.Application.DTO;
using HelperPayment.Core.Offer;

namespace HelperPayment.Infrastructure.DAL.Handlers
{
    public static class Extensions
    {
        public static OfferDto AsDto(this Offer entity)
       => new()
       {
           Id = entity.Id,
           InquiryId = entity.InquiryId,
           Description = entity.Description.Value,
           Price = entity.Price is null ? 0 : entity.Price.Value,
           IsDraft = entity.IsDraft,
           PaymentDate = entity.PaymentDate,
           Status = Enum.GetName(entity.Status.Value),
           ClientsReason = entity.ClientsReason is null ? null : entity.ClientsReason.Value,
           RowVersion = entity.RowVersion,
           CreatedAt = entity.CreatedAt,
           ModifiedAt = entity.ModifiedAt,
           IsDeleted = entity.IsDeleted,
           DeletedAt = entity.DeletedAt
       };
    }
}
