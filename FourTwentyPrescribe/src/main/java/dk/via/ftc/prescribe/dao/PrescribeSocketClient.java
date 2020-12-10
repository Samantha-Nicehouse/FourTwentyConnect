package dk.via.ftc.prescribe.dao;

import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;

import java.sql.SQLOutput;
import java.util.List;

import com.google.gson.Gson;

import dk.via.ftc.prescribe.model.Drug;

public class PrescribeSocketClient {
	
	String hostname = "localhost";
	int port = 4012;
	InputStream in;
	PrintWriter pw;
	Socket socket;
	Gson gson;
	
	String sampleJSON =
			"[{\"productName\":\"C8\",\"strain\":\"Afpak\",\"indications\":\"Depression, Insomnia, Pain, Stress, Lack of Appetite\",\"product_id\":1},{\"productName\":\"Product2\",\"strain\":\"Strain2\",\"indications\":\"Pain, Stress, Lack of Appetite\",\"product_id\":2}]";

	public PrescribeSocketClient() {
		gson = new Gson();
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
	
	public Drug[] loadAllDrugsFromBusinessLayer() {
		Drug[] drugs = null;
		try {
			pw.write("Hi FTC");
			pw.flush();

			//Data recieved in bytes
			byte[] buffer = new byte[1024];
			int count = in.read(buffer);
			String s = new String(buffer, StandardCharsets.UTF_8);
			drugs = gson.fromJson(s, Drug[].class);
			
			// print message to console
			System.out.println(s);
		}
		catch(IOException ioe) {
			ioe.printStackTrace();
		}
		return drugs;
	}
	
	public static void main(String[] args) {
		String hostname = "localhost";
		int port = 4012;
		InputStream in;
		PrintWriter pw;

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
		        } catch (UnknownHostException ex) {
		            System.out.println("Server not found: " + ex.getMessage());
		        } catch (IOException ex) {
		            System.out.println("I/O error: " + ex.getMessage());
		        }
		    }
	}