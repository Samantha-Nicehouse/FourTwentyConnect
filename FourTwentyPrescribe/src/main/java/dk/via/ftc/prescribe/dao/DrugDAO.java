package dk.via.ftc.prescribe.dao;
import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;
import java.util.Collection;
import java.util.List;

@WebService
@SOAPBinding(style = SOAPBinding.Style.DOCUMENT, use = SOAPBinding.Use.LITERAL)
public interface DrugDAO {
        @WebMethod List<Drug> getDrugsByIndication(String medicalIndication);

    }
}
