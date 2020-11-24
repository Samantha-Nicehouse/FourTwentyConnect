package dk.via.Connect.Database.Model;
import java.util.Objects;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "vendor")
public class Vendor {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private String VendorId;
    private String VendorName;
    private String VendorLicence;
    private String City;
    private String Country;
    private String StateProvince;

    public Vendor() {
    }

    public Vendor( String vendorName, String vendorLicence, String city, String country, String stateProvince) {

        VendorName = vendorName;
        VendorLicence = vendorLicence;
        City = city;
        Country = country;
        StateProvince = stateProvince;
    }

    public String getVendorId() {
        return VendorId;
    }



    public String getVendorName() {
        return VendorName;
    }

    public void setVendorName(String vendorName) {
        VendorName = vendorName;
    }


    public String getVendorLicence() {
        return VendorLicence;
    }

    public void setVendorLicence(String vendorLicence) {
        VendorLicence = vendorLicence;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String city) {
        City = city;
    }

    public String getCountry() {
        return Country;
    }

    public void setCountry(String country) {
        Country = country;
    }

    public String getStateProvince(){return StateProvince;}

    public void setStateProvince(String stateProvince){StateProvince = stateProvince;}

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 79 * hash + Objects.hashCode(this.VendorName);
        hash = 79 * hash + Objects.hashCode(this.VendorLicence);
        hash = 79 * hash + Objects.hashCode(this.City);
        hash = 79 * hash + Objects.hashCode(this.Country);
        hash = 79 * hash + Objects.hashCode(this.StateProvince);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Vendor other = (Vendor) obj;

        if (!this.getVendorName().equals(other.VendorName)) {
            return false;
        }

        if (!this.getVendorLicence().equals(other.VendorLicence)) {
            return false;
        }
        if (!this.getCity().equals(other.City)) {
            return false;
        }
        if (!this.getCountry().equals(other.Country)) {
            return false;
        }
        if (!this.getStateProvince().equals(other.StateProvince)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Vendor{");
        sb.append(", vendorName=").append(getVendorName());
        sb.append(", vendorLicence=").append(getVendorLicence());
        sb.append(", city=").append(getCity());
        sb.append(", country=").append(getCountry());
        sb.append(", stateProvince=").append(getStateProvince());
        sb.append('}');
        return sb.toString();
    }
}