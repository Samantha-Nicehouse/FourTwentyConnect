package dk.via.Connect.Database.DTO;

public class VendorDTO {

    private String vendorId;
    private String VendorName;
    private String vendorLicense;
    private String firstName;
    private String lastName;
    private String email;
    private int phoneNumber;
    private String City;
    private String Country;
    private String stateProvince;
    private String username;
    private String password;

    public VendorDTO() {
    }

    public VendorDTO(String vendorName, String vendorLicense, String city, String country, String stateProvince) {
        this.VendorName = vendorName;
        this.vendorLicense = vendorLicense;
        this.City = city;
        this.Country = country;
        this.stateProvince = stateProvince;
    }
    public String getVendorId(){return vendorId;}
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getVendorName() {
        return VendorName;
    }

    public void setVendorName(String vendorName) {
        this.VendorName = vendorName;
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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public int getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(int phoneNumber) {
        this.phoneNumber = phoneNumber;
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
