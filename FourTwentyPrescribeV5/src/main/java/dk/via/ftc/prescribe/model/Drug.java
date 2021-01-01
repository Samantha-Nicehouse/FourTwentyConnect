package dk.via.ftc.prescribe.model;

import java.util.Arrays;

/**
 * the model for a drug used by GUI
 */
public class Drug {

	String productName;
	String strain;
	String[] indicationList;
	String fullText;
	String positiveEffects;
	String negativeEffects;
	String thcContent;
	String productId;
	String indications;

	/***
	 * this constructor initializes the instance variables to the ones recieved and also sets up search text that will be used
	 * by GUI to match the search field to drug this is called full text
	 * @param productName name of product ex widows comfort
	 * @param strain name of strain ex aloha
	 * @param indications list of medical uses ex depression
	 * @param productId not really needed but from the business layer to identify a product
	 */
	
	public Drug(String productName, String strain, String indications, int productId) {
		this.productName = productName;
		this.strain = strain;
		this.productId = String.valueOf(productId);
		indicationList = indications.split(","); // splits list of indications by comma symbol and puts each match into a string array
		this.indications = indications; //has original string of indications(which is like a DTO) from business layer
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

	public String getProductId() {
		return productId;
	}

	public void setProductId(String productId) {
		this.productId = productId;
	}
	// Save Prescriptions locally to a RandomAccessFile

	public String getIndications() {
		return indications;
	}

	public void setIndications(String indications) {
		this.indications = indications;
	}

	public String getProductName() {
		return productName;
	}

	public String getStrain() {
		return strain;
	}

	public String getIndicationList() {
		return Arrays.toString(indicationList);
	}

	/**
	 * this is used by GUI to search object for a matching string
	 * @param searchString text from GUI search field
	 * @return true if fullText contains searchString that we want
	 */

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
