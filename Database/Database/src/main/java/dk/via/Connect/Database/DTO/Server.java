package dk.via.Connect.Database.DTO;

import dk.via.Connect.Database.DTO.DatabaseClientHandler;
import dk.via.Connect.Database.DTO.VendorDAOImpl;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
    int PORT = 4012;
    boolean running;
    DAOHandler dao;
    // This is the listener for socket connections from
    // the C# web layer
    // This spurns a new thread when a new client connection comes in
    public Server(){
        try {
            dao = new DAOHandler();
            ServerSocket serverSocket = new ServerSocket(PORT);

            running = true;
            while (running)
            {
                System.out.println("Waiting for a client...");
                Socket client = serverSocket.accept();
                System.out.println("Client connected");
                DatabaseClientHandler clientHandler = new DatabaseClientHandler(client, dao);
                Thread clientThread = new Thread(clientHandler);
                //clientThread.setDaemon(true);
                clientThread.start();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
