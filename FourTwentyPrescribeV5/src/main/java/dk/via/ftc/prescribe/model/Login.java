package dk.via.ftc.prescribe.model;

import java.io.Serializable;

public class Login implements Serializable{
	
	private static final long serialVersionUID = 3847667640519621997L;
	String username;
	String password;
	
	public Login(String username, String password) {
		super();
		this.username = username;
		this.password = password;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
	

	
}
