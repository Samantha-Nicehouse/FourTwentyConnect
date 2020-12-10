package dk.via.ftc.prescribe.dao;

import java.io.EOFException;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.List;

import dk.via.ftc.prescribe.model.Login;

public class LoginDAO {

	private static String PATH = System.getProperty("user.home") + File.separator + "Java2" + File.separator;
	private static String FILE_NAME = "FTClogin.dat";
	// serialize and deserialize to .dat file
	private List<Login> logins;
	
	public LoginDAO() {
		loadUsers();
	}

	public void saveAll() {
		// TODO Auto-generated method stub
		File f = new File(PATH + FILE_NAME);
		FileOutputStream fos;
		ObjectOutputStream oos = null;
		try {
			fos = new FileOutputStream(f);
		    oos = new ObjectOutputStream(fos);
			oos.writeObject(logins);
			oos.flush();
			
			oos.close();
			fos.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}	
	}
	
	public void addLoginUser(String username, String password) {
		Login lg = new Login(username, password);
		logins.add(lg);
	}
	
	public Login loginUser(String username, String password) {
		
		for(Login user : logins) {
			if(user.getUsername().equals(username) 
					&& user.getPassword().equals(password)) { 
				return user;
			}
		}
		return null;
	}
	
	private void loadUsers() {
		File f = new File(PATH + FILE_NAME);
		FileInputStream fis = null;
		ObjectInputStream ois = null;
		try {
			fis = new FileInputStream(f);
		    ois = new ObjectInputStream(fis);
		    logins = (List<Login>)ois.readObject();
			
			ois.close();
			fis.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (EOFException e) {
			// TODO Auto-generated catch block
			try {
				if(ois != null) {
				   ois.close();
				}
				if(fis != null) {
				   fis.close();
				}
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
			
			//e.printStackTrace();
		} 
		catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
