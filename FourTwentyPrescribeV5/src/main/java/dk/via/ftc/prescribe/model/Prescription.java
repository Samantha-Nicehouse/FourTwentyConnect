package dk.via.ftc.prescribe.model;

public class Prescription {
	private Drug drug;
	
	private Patient patient;
	
	private Prescriber prescriber;

	public Prescription(Drug drug, Patient patient, Prescriber prescriber) {
		super();
		this.drug = drug;
		this.patient = patient;
		this.prescriber = prescriber;
	}

	public Drug getDrug() {
		return drug;
	}

	public Patient getPatient() {
		return patient;
	}

	public Prescriber getPrescriber() {
		return prescriber;
	}
	
	

}
