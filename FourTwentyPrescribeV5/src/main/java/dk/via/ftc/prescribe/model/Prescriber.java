package dk.via.ftc.prescribe.model;

import java.awt.image.BufferedImage;

public class Prescriber {
	String firstName;
	String lastName;
	BufferedImage signature;
	
	public String getFirstName() {
		return firstName;
	}
	
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	
	public String getLastName() {
		return lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	public BufferedImage getSignature() {
		return signature;
	}
	public void setSignature(BufferedImage signature) {
		this.signature = signature;
	}
	
	

}
