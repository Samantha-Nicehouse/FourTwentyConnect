package dk.via.Connect.Database.DTO;

import com.google.gson.Gson;
import dk.via.Connect.Database.DTO.VendorDTO;
import dk.via.Connect.Database.DTO.VendorDAOImpl;

import java.io.*;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class DatabaseClientHandler implements Runnable {
    Socket client;
    VendorDAOImpl dataAccessObj;
    Gson gson;
    private BufferedReader in;
    private PrintWriter out;
    private boolean running;




    public DatabaseClientHandler(Socket client, VendorDAOImpl dataAccessObj) throws IOException {
        this.client = client;
        this.dataAccessObj = dataAccessObj;
        gson = new Gson();
        this.in = new BufferedReader(
                new InputStreamReader(this.client.getInputStream(), StandardCharsets.UTF_8
                ));
        this.out = new PrintWriter(this.client.getOutputStream(), true);
    }

    @Override
    public void run() {
        // waiti for a client request
        running = true;
        out.println("You are connected");
        while (running)
        {
            try
            {
                String request = in.readLine();
                System.out.println("Client> " + request);
                String reply = serviceRequest(request);
                System.out.println("Server> " + reply);
                out.println(reply);
                if (request.contentEquals("quit"))
                {
                    close();
                }
            }
            catch (Exception e)
            {
                System.out.println("Client error ");
                e.printStackTrace();
                close();
            }
        }
        close();
    }


    private String serviceRequest(String request) {
        VendorDTO dto = gson.fromJson(request, VendorDTO.class);
        // there is a field in the DTO that states the type of requestor
        // if it is a vendor, we convert the DTO to a VendorDTO, search/update/create
        // else if it is a dispensary, we convert the DTO to a DispensaryDTO, search/update/create
        // else if it is a strain, we convert the DTO to a StrainDTO,  search/update/create
        // search all fields where name = ? and city = ? - name and city variables would have data
        // filterVariables = comma-separated list of fields to search by
        // update vendor set name = ? and city = ? where id = ?, -id, name and city variables would have data
        boolean success = dataAccessObj.createVendor(dto.getVendorName(),
                dto.getVendorLicence(), dto.getCity(), dto.getCountry(), dto.getStateProvince());
        return success ? "Vendor has been created successfully" : "Ērror creating vendor";
    }

    private String serviceRequest2(String request) {
        VendorDTO dto = gson.fromJson(request, VendorDTO.class);
        VendorAdminDTO dto2 = gson.fromJson(request, VendorAdminDTO.class);

        // there is a field in the DTO that states the type of requestor
        // if it is a vendor, we convert the DTO to a VendorDTO, search/update/create
        // else if it is a dispensary, we convert the DTO to a DispensaryDTO, search/update/create
        // else if it is a strain, we convert the DTO to a StrainDTO,  search/update/create
        // search all fields where name = ? and city = ? - name and city variables would have data
        // filterVariables = comma-separated list of fields to search by
        // update vendor set name = ? and city = ? where id = ?, -id, name and city variables would have data
        boolean success = dataAccessObj.registerVendor(dto.getVendorName(),
                dto.getVendorLicence(), dto.getCity(), dto.getCountry(), dto.getStateProvince(), dto.getVendorAdmin());
        return success ? "Vendor and Vendor Admin have been created successfully" : "Ērror creating vendor and admin";
    }

    public void close() {
        running = false;
        try {
            out.close();
            this.client.close();
        } catch (IOException e) {
            //
        }
    }
}


