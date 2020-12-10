package dk.via.ftc.prescribe.model;

import java.util.Arrays;

public class Drug {

	String productName;
	String strain;
	String[] indicationList;
	String fullText;
	String positiveEffects;
	String negativeEffects;
	String thcContent;
	
	public Drug(String productName, String strain, String indications) {
		this.productName = productName;
		this.strain = strain;
		indicationList = indications.split(",");
		fullText = productName;
		fullText += " " + strain;
		for(String ind : indicationList) {
			fullText += " " + ind;
		}
	}
	// Higher level 
	// JAX-RS - Client consuming your rest service from a Server port number
	// C# Business layer expose a service on a port number
	
	// Lower level 
	// Socket - Client makes a read call to C# port number
	// C# ServerSocket - Wait for client connection from 
	// C# ServerSocket return List of Drugs
	// Login prescriber will be saved locally in the JavaFX app.
	// Register a prescriber locally and save his login details.
	// Save Prescriptions locally to a RandomAccessFile

	public String getProductName() {
		return productName;
	}

	public String getStrain() {
		return strain;
	}

	public String getIndicationList() {
		return Arrays.toString(indicationList);
	}

	public boolean findText(String searchString) {
		return fullText.contains(searchString);
	}

	public String getPositiveEffects() {
		return positiveEffects;
	}

	public void setPositiveEffects(String positiveEffects) {
		this.positiveEffects = positiveEffects;
	}

	public String getNegativeEffects() {
		return negativeEffects;
	}

	public void setNegativeEffects(String negativeEffects) {
		this.negativeEffects = negativeEffects;
	}

	public String getThcContent() {
		return thcContent;
	}

	public void setThcContent(String thcContent) {
		this.thcContent = thcContent;
	}
	
}
