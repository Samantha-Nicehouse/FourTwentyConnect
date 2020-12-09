namespace dk.via.ftc.businesslayer.Models
{
    public class DispensaryLicense
    {
        public string license { get; set; }
        public bool active {get; set; }

        public DispensaryLicense()
        {
            active = false;
        }
    }
}