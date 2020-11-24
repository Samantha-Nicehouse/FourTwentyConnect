package dk.via.Connect.Database.DTO;
import java.util.Collection;
public interface VendorDAO {


        VendorRegistrationDTO create(String vendorName, String vendorLicense, String city, String country, String stateProvince);
        Collection<VendorRegistrationDTO> readAll();
        void update(VendorRegistrationDTO vendor);
        void delete(VendorRegistrationDTO vendor);
        VendorRegistrationDTO read(String vendorId);
    }

