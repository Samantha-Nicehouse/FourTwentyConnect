package dk.via.ftc.prescribe.dao;

import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import java.net.URL;

public class PrescribeDAO {

    public static void main(String[] args) throws Exception {

        URL url = new URL("http://localhost:9999/ws/userdao?wsdl");

        //1st argument service URI, refer to wsdl document above
        //2nd argument is service name, refer to wsdl document above
        QName qname = new QName("http://dao.soapws.via.dk/", "UserDAOImplService");

        Service service = Service.create(url, qname);

        DrugDAO userDAO = service.getPort(DrugDAO.class); // client downloads the stub



        //create user object and send it to the server to create for us
        Pr user1 = new User();
        user1.setId(1);
        user1.setEmail("sam@gmail.com");
        user1.setPassword("1234567");
        String response = userDAO.createUser(user1);
        System.out.println(response);
    }
}
