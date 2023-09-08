using HelperPayment.Core.Models.Invoice;

namespace HelperPayment.Core.DTO
{
    public static class Extension
    {
        public static InvoiceDto AsDto(this Invoice entity)
      => new()
      {
          Id = entity.Id,
          OfferId = entity.OfferId,
          PaymentDate = entity.PaymentDate,
          RealisationStart = entity.RealisationStart,
          RealisationEnd = entity.RealisationEnd,
          Price = entity.Price,
          Proforma = entity.Proforma,
          Paid = Enum.GetName(entity.Paid),
          ClientEmail = entity.ClientsEmail,
          ClientName = entity.ClientsName,
      };
    }
}
