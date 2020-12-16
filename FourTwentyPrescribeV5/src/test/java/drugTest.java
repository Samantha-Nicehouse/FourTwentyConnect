import dk.via.ftc.prescribe.model.Drug;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class drugTest {

    @Test
    public void getDrugTest(){
        Drug drug = new Drug("Test","1","Pain",1);
       assertEquals("Test", drug.getProductName());
        assertEquals(null, drug.getProductName());
        assertEquals("", drug.getProductName());
    }
}
