namespace dk.via.ftc.businesslayer.Models
{
    public class VendorVendorAdmin
    {
        public VendorVendorAdmin()
        {
            vendor = new Vendor();
            vendorAdmin = new VendorAdmin();
        }
        public Vendor vendor
        {
            get; set;
        }
        public VendorAdmin vendorAdmin { get; set; }
        
    }
}