import dk.via.ftc.prescribe.dao.PrescribeSocketClient;
import org.junit.runner.*;
import org.junit.runner.notification.Failure;

public class prescriberTest {
    public static void main(String[] args){
        JUnitCore junit = new JUnitCore();
        Result result = junit.run(PrescribeSocketClient.class);
        for(Failure failure : result.getFailures()){
            System.out.println(failure.toString());
        }
    }
}
