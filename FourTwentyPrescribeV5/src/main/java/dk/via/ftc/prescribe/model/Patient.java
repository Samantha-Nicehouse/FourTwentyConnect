package dk.via.ftc.prescribe.model;

public class Patient {
	
	String patientName;
	String patientAddress;
	
	public Patient(String patientName, String patientAddress) {
		super();
		this.patientName = patientName;
		this.patientAddress = patientAddress;
	}
	
	public String getPatientName() {
		return patientName;
	}
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	public String getPatientAddress() {
		return patientAddress;
	}
	public void setPatientAddress(String patientAddress) {
		this.patientAddress = patientAddress;
	}

}
