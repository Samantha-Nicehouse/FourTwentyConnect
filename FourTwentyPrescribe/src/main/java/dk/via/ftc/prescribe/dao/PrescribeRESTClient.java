package dk.via.ftc.prescribe.dao;

import javax.xml.namespace.QName;
import javax.xml.ws.Service;

import dk.via.ftc.prescribe.model.Drug;

import java.net.URL;
import java.util.List;

public class PrescribeRESTClient {

    public static void main(String[] args) throws Exception {

        URL url = new URL("http://localhost:9999/ws/drugdao?wsdl");

        //1st argument service URI, refer to wsdl document above
        //2nd argument is service name, refer to wsdl document above
        QName qname = new QName("http://dao.soapws.via.dk/", "UserDAOImplService");

        Service service = Service.create(url, qname);

        DrugRestDAO drugDAO = service.getPort(DrugRestDAO.class); // client downloads the stub

        //create drug list object from server call
        List<Drug> drugs = drugDAO.getAllDrugs();
    }
}
