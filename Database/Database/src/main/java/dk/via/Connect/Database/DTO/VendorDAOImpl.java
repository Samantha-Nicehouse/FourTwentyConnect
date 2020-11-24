package dk.via.Connect.Database.dao;

import org.postgresql.Driver;

import java.sql.*;

public class VendorDAOImpl {

    private String jdbcURL;
    private String username;
    private String password;


    public VendorDAOImpl(String jdbcURL, String username, String password) throws Exception {
        this.jdbcURL = jdbcURL;
        this.username = username;
        this.password = password;
        try {
            DriverManager.registerDriver(new Driver());
        } catch (SQLException e) {
            throw new Exception("No JDBC driver", e);
        }
    }

    public VendorDAOImpl(String jdbcURL) throws Exception {
        this(jdbcURL, null, null);
    }

    public VendorDAOImpl() {
        this.jdbcURL = "jdbc:postgresql://b8zxgsmnlkoj6ypd21ro-postgresql.services.clever-cloud.com:5432/b8zxgsmnlkoj6ypd21ro";
        this.username = "u1qvxb47lih4lpp0hmzp";
        this.password = "L9CBWOWE3tlB0kpuncgG";
    }

    protected Connection getConnection() throws SQLException {
        if (username == null) {
            return DriverManager.getConnection(jdbcURL);
        } else {
            return DriverManager.getConnection(jdbcURL, username, password);
        }
    }

    // create a Vendor
    // update a vendor attribute
    // retrieve a vendor by a field
    // retrieve all vendors
    // delete a vendor
    public boolean createVendor(String vendorName, String vendorLicence, String city,  String stateProvince, String country,
              String username, String password, String email, String firstName, String lastName) {
        System.out.println("vendorName " + vendorName
                + " vendorLicence " + vendorLicence
                + " city " + city
                + " stateProvince " + stateProvince
                + " country " + country);
        String vendorsql = " INSERT INTO \"SEP3\".\"vendor\"  (vendor_name, vendor_license, city, state, country) values(?,?,?,?,?) ";
        String vendorId = "";
        // This takes care of creating the Vendor
        try {
            PreparedStatement preparedStatementVendor = getConnection().prepareStatement(vendorsql);
            preparedStatementVendor.setString(1, vendorName);
            preparedStatementVendor.setString(2, vendorLicence);
            preparedStatementVendor.setString(3, city);
            preparedStatementVendor.setString(4, country);
            preparedStatementVendor.setString(5, stateProvince);

            int result = preparedStatementVendor.executeUpdate();
            System.out.println("Ŗesult Vendor " + result);

            // now get the ID:
            ResultSet rs = preparedStatementVendor.getGeneratedKeys();
            if (rs.next()) {
                 vendorId = rs.getString(1);
            }
            createVendorAdmin(username, vendorId, password, email, firstName, lastName);
            return true;

        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }



     // This will take care of creating the vendor admin
    private boolean createVendorAdmin( String username, String vendorId, String password, String email, String firstName, String lastName){
        String vendoradminsql = " INSERT INTO \"SEP3\".\"vendorAdmin\" (username, vendor_id, pass, email, first_name, last_name) values(?,?,?,?,?,?)";
        try{
            PreparedStatement preparedStatementVendorAdmin = getConnection().prepareStatement(vendoradminsql);
            preparedStatementVendorAdmin.setString(1, username);
            preparedStatementVendorAdmin.setString(2, vendorId);
            preparedStatementVendorAdmin.setString(3, password);
            preparedStatementVendorAdmin.setString(4, email);
            preparedStatementVendorAdmin.setString(5, firstName);
            preparedStatementVendorAdmin.setString(6, lastName);




            int result2 = preparedStatementVendorAdmin.executeUpdate();
            System.out.println("Ŗesult Vendor Admin" + result2);
            return true;
        }
        catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }


}

 /* run the INSERT
    String sql = "INSERT INTO product values(?,?,?)";
    pst = cn.prepareStatement(sql, new String[] {"PRODUCT_ID"} );
pst.setString(1, name);
pst.setInt(2, quantity);
pst.setInt(3, price);
pst.executeUpdate();

    // now get the ID:
    ResultSet rs = pst.getGeneratedKeys();
if (rs.next()) {
        long productId = rs.getLong(1);
    }*/

/*
    public T mapSingle(DataMapper<T> mapper, String sql, Object... parameters) throws RemoteException {
        try (Connection connection = getConnection()) {
            PreparedStatement stat = prepare(connection, sql, parameters);
            ResultSet rs = stat.executeQuery();
            if(rs.next()) {
                return mapper.create(rs);
            } else {
                return null;
            }
        } catch (SQLException e) {
            throw new RemoteException(e.getMessage(), e);
        }
    }

    public List<T> map(DataMapper<T> mapper, String sql, Object... parameters) throws RemoteException {
        try (Connection connection = getConnection()) {
            PreparedStatement stat = prepare(connection, sql, parameters);
            ResultSet rs = stat.executeQuery();
            LinkedList<T> allCars = new LinkedList<>();
            while(rs.next()) {
                allCars.add(mapper.create(rs));
            }
            return allCars;
        } catch (SQLException e) {
            throw new RemoteException(e.getMessage(), e);
        }
    }

 */
    /*
    String url = "jdbc:postgresql://localhost/test";
    Properties props = new Properties();
    props.setProperty("user","fred");
props.setProperty("password","secret");
props.setProperty("ssl","true");
    Connection conn = DriverManager.getConnection(url, props);

    String url = "jdbc:postgresql://localhost/test?user=fred&password=secret&ssl=true";
    Connection conn = DriverManager.getConnection(url);
*/

