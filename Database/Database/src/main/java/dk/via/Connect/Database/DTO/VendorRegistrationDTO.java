package dk.via.Connect.Database.DTO;

public class VendorDTO extends DTO {

    private String vendorId;
    private String VendorName;
    private String vendorLicense;
    private String FirstName;
    private String LastName;
    private String Email;
    private String City;
    private String Country;
    private String stateProvince;
    private String UserName;
    private String Password;
    private VendorAdmin vendorAdmin;

    public VendorDTO(String vendorName, String vendorLicense, String city, String country, String stateProvince, String username, String password, String firstName, String lastName, String email) {
        this.VendorName = vendorName;
        this.vendorLicense = vendorLicense;
        this.City = city;
        this.Country = country;
        this.stateProvince = stateProvince;
        this.UserName = username;
        this.Password = password;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;

    }

    public VendorAdmin getVendorAdmin() {
        return vendorAdmin;
    }

    public String getVendorId(){return vendorId;}
    public String getUsername() {
        return UserName;
    }

    public void setUsername(String username) {
        this.UserName = username;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        this.Password = password;
    }

    public String getVendorName() {
        return VendorName;
    }

    public void setVendorName(String vendorName) {
        this.VendorName = vendorName;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        this.FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        this.LastName = lastName;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        this.Email = email;
    }


    public String getVendorLicence() {
        return vendorLicense;
    }

    public void setVendorLicence(String vendorLicence) {
        this.vendorLicense = vendorLicense;
    }

    public String getCity() {
        return City;
    }

    public void setCity(String city) {
        this.City = city;
    }

    public String getCountry() {
        return Country;
    }

    public void setCountry(String country) {
        this.Country = country;
    }

    public String getStateProvince(){return stateProvince;}

    public void setStateProvince(String stateProvince){this.stateProvince = stateProvince;}
}
