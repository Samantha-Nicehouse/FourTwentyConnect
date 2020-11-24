package dk.via.Connect.Database.DTO;

public class DAOHandler {

    VendorDAOImpl dataAccessObj;
    public DAOHandler(){
        dataAccessObj  = new VendorDAOImpl();
    }

    public VendorDAOImpl getDataAccessObj() {
        return dataAccessObj;
    }
}
