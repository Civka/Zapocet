namespace Zapocet.Data.Model
{
    public class EshopExport
    {
        public PurchaseOrderHeaders PurchaseOrderHeaders { get; set; }
        public double TotalPrice { get; set; } = 0;

        public EshopExport( PurchaseOrderHeaders _purchaseOrderHeaders, double _totalPrice) 
        {
            this.PurchaseOrderHeaders = _purchaseOrderHeaders;
            this.TotalPrice = _totalPrice;
        }
    }
}
