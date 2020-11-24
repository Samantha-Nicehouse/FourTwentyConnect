package dk.via.Connect.Database.DTO;

import java.util.Objects;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "vendor_admin")
public class VendorAdmin {


    private String username;
    private String vendorId;
    private String password;
    private String email;
    private String firstName;
    private String lastName;

    public VendorAdmin(){}

    public VendorAdmin(String username, String vendorId, String password, String email, String firstName, String lastName) {
        this.username = username;
        this.vendorId = vendorId;
        this.password = password;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getVendorId() {
        return vendorId;
    }

    public void setVendorId(String vendorId) {
        this.vendorId = vendorId;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }


    public int hashCode() {
        int hash = 7;
        hash = 79 * hash + Objects.hashCode(this.firstName);
        hash = 79 * hash + Objects.hashCode(this.lastName);
        hash = 79 * hash + Objects.hashCode(this.username);
        hash = 79 * hash + Objects.hashCode(this.password);
        return hash;
    }
    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof VendorAdmin)) return false;
       VendorAdmin that = (VendorAdmin) obj;
        return this.vendorId.equals(that.vendorId);
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("VendorAdmin{");
        sb.append(", username=").append(getUsername());
        sb.append(", password=").append(getPassword());
        sb.append(", firstname=").append(getFirstName());
        sb.append(", lastname=").append(getLastName());
        sb.append(", email=").append(getEmail());
        sb.append('}');
        return sb.toString();
    }
}
