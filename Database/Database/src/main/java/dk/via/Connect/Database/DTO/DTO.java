package dk.via.Connect.Database.DTO;

public class DTO {
    String requesterType;

    public DTO() {
    }

    public DTO(String requesterType) {
        this.requesterType = requesterType;
    }

    public String getRequesterType() {
        return requesterType;
    }

    public void setRequesterType(String requesterType) {
        this.requesterType = requesterType;
    }
}
