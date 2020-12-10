package dk.via.ftc.prescribe.dao;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;

import dk.via.ftc.prescribe.model.Drug;

import java.util.Collection;
import java.util.List;

@WebService
@SOAPBinding(style = SOAPBinding.Style.DOCUMENT, use = SOAPBinding.Use.LITERAL)
public interface DrugRestDAO {
   @WebMethod List<Drug> getAllDrugs();

}

