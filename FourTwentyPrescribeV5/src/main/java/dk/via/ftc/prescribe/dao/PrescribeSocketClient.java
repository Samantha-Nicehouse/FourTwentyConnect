package dk.via.ftc.prescribe.dao;
//prescribeSocketClient handles the dto
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.ftc.prescribe.model.Drug;

import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

/**
 * prescribeSocketClient handles the Drug dto
 * makes the network call to the business layer for a list of drugs available
 *
 */
public class PrescribeSocketClient {
	
	String hostname = "localhost";
	int port = 4012;
	InputStream in;
	PrintWriter pw;
	Socket socket;

	
	String sampleJSON =
			"[{\"productName\":\"C8\",\"strain\":\"Afpak\",\"indications\":\"Depression, Insomnia, Pain, Stress, Lack of Appetite\",\"product_id\":1},{\"productName\":\"Product2\",\"strain\":\"Strain2\",\"indications\":\"Pain, Stress, Lack of Appetite\",\"product_id\":2}]";

	/**
	 * constructor opens up socket connection to the business layer
	 * initializes input and output streams on the connection
	 */
	public PrescribeSocketClient() {

		try {
			socket = new Socket(hostname, port);
			System.out.println("Client Connected");
			in = socket.getInputStream(); // TO Read Bytes Recieved
			pw = new PrintWriter(socket.getOutputStream(), true);
		}
		catch(UnknownHostException uhe) {
			uhe.printStackTrace();
		}
		catch(IOException ioe) {
			ioe.printStackTrace();
		}
	}

	/**
	 * this method is static so it can be called without requiring an object of this class
	 * opens up socket connection to the business layer
	 * initializes input and output streams on the connection
	 * @return a list of drug objects
	 */
	
	public static List<Drug> loadAllDrugsFromBusinessLayer() {
		List<Drug> drugs = new ArrayList<>();
		String hostname = "localhost";
		int port = 4012;
		InputStream in;
		PrintWriter pw;
		ObjectMapper om = new ObjectMapper();


		try (Socket socket = new Socket(hostname, port)) {
			System.out.println("Client Connected");
			in = socket.getInputStream(); // TO Read Bytes Recieved
			pw = new PrintWriter(socket.getOutputStream(), true);

			pw.write("Hi FTC");
			pw.flush();

			//Data recieved in bytes
			byte[] buffer = new byte[5120];
			int count = in.read(buffer); //read response from business layer into buffer which is a byte array
			String s = new String(buffer, StandardCharsets.UTF_8); // converts buffer contents into string
			// print message to console
			System.out.println(s);

			Root root = om.readValue(s, Root.class); //map string to an root object using object mapper
			for (DrugDTO prod : root.drugs) { //loops through each drug in drugs collection variable
				//for each drug DTO in root we extract the content from it and create our model drug
				System.out.println(prod.indications);
				Drug dr = new Drug(prod.productName, prod.strain, prod.indications, prod.product_id); // creates a new drug
				drugs.add(dr);
			}

		} catch (UnknownHostException ex) {
			System.out.println("Server not found: " + ex.getMessage());
		} catch (IOException ex) {
			System.out.println("I/O error: " + ex.getMessage());
		}

		return drugs;
	}
	public static void main(String[] args) {
		String hostname = "localhost";
		int port = 4012;
		InputStream in;
		PrintWriter pw;
        ObjectMapper om = new ObjectMapper();


		try (Socket socket = new Socket(hostname, port)) {
					System.out.println("Client Connected");
					in = socket.getInputStream(); // TO Read Bytes Recieved
					pw = new PrintWriter(socket.getOutputStream(), true);

					pw.write("Hi FTC");
					pw.flush();

					//Data recieved in bytes
					byte[] buffer = new byte[1024];
					int count = in.read(buffer);
					String s = new String(buffer, StandardCharsets.UTF_8);
					// print message to console
		            System.out.println(s);

                    Root root = om.readValue(s, Root.class); // converts string from network  to root class object
            for (DrugDTO prod : root.drugs) { //for every drug in a collection of drugs
                System.out.println(prod.indications);
            }

		        } catch (UnknownHostException ex) {
		            System.out.println("Server not found: " + ex.getMessage());
		        } catch (IOException ex) {
		            System.out.println("I/O error: " + ex.getMessage());
		        }
		    }
	}

// import com.fasterxml.jackson.databind.ObjectMapper; // version 2.11.1
// import com.fasterxml.jackson.annotation.JsonProperty; // version 2.11.1
/* ObjectMapper om = new ObjectMapper();
Root root = om.readValue(myJsonString), Root.class); */
 class DrugDTO{
	public String productName;
	public String strain;
	public String indications;
	public int product_id;
}

/**
 * DTO that contains list of drugs recieved from business layer
 */
class Root{
   public List<DrugDTO> drugs;
}