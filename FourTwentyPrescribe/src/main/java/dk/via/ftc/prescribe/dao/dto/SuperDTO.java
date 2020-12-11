package dk.via.ftc.prescribe.dao.dto;

import java.util.List;

public class SuperDTO {

    List<DrugDTO> drugs;

    public SuperDTO() {

    }

    public SuperDTO(List<DrugDTO> drugs) {
        this.drugs = drugs;
    }

    public List<DrugDTO> getDrugs() {
        return drugs;
    }

    public void setDrugs(List<DrugDTO> drugs) {
        this.drugs = drugs;
    }
}
