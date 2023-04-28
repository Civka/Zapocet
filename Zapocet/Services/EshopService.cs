using Microsoft.EntityFrameworkCore;
using Zapocet.Data;
using Zapocet.Data.Model;
using Zapocet.Data.Dto;
using Zapocet.Services.Interfaces;
using System.Globalization;

namespace Zapocet.Services
{

    public class EshopService : MasterService, IEshopService
    {
        public EshopService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<EshopExport> GetEshopData()
        {
            List<EshopExport> eshopExports = new List<EshopExport>();
            var headers = _context.PurchaseOrderHeaders.ToList();
            foreach (var header in headers)
            {
                double totalPrice = 0;
                var purchasesOrder = _context.PurchaseOrderItems.SingleOrDefault(x => x.PurchaserOrderId == header.Id);
                if (purchasesOrder != null)
                {
                    totalPrice = purchasesOrder.Amount * purchasesOrder.PricePerUnit;
                }
                eshopExports.Add(new EshopExport(header, totalPrice));
            }
            return eshopExports;
        }

        public GenericResponseDto AddEshopData(List<EshopDto> eshopDataDto) 
        {
            GenericResponseDto responseDto = new GenericResponseDto();

            foreach (var dataRow in eshopDataDto)
            {
                if(_context.PurchaseOrderHeaders.Any(x => x.PoNumber == dataRow.poid)) 
                {
                    responseDto.Failed++;
                    responseDto.FailedList.Add(dataRow.poid);
                    responseDto.Message = "We have some duplicates here!";
                    continue;
                }

                if (dataRow.email.Length > 30)
                {
                    dataRow.email = " Invalid, too much dlouhý";
                }

                var purchaseOrderHeaders = new PurchaseOrderHeaders()
                {
                    PoNumber = dataRow.poid,
                    CustomerName = dataRow.first_name,
                    CustomerLastName = dataRow.last_name,
                    CreatedOn = DateTime.ParseExact(dataRow.createdon, "M/d/yyyy", CultureInfo.InvariantCulture),
                    CustomerEmail = dataRow.email               
                };

                _context.PurchaseOrderHeaders.Add(purchaseOrderHeaders);
                _context.SaveChanges();


                var purchaseOrderItems = new PurchaseOrderItems() 
                {
                    PurchaserOrderId = purchaseOrderHeaders.Id,
                    ShopItemTitle = dataRow.item,
                    Amount = dataRow.amount,
                    PricePerUnit = dataRow.price
                };

                responseDto.Success++;

                _context.PurchaseOrderItems.Add(purchaseOrderItems);
                _context.SaveChanges();
            }

            return responseDto;
        }
    }
}
