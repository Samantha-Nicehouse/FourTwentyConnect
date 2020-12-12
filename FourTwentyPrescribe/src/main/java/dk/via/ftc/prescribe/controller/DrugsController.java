package dk.via.ftc.prescribe.controller;

import dk.via.ftc.prescribe.dao.PrescribeSocketClient;
import dk.via.ftc.prescribe.model.Drug;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;

import java.awt.event.MouseEvent;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;

public class DrugsController implements Initializable {
    //prod.productName, prod.strain, prod.indications, prod.product_id
    @FXML
    private TableView<Drug> drugTable;
    @FXML
    private TableColumn<Integer, Integer> product_id;
    @FXML
    private TableColumn<Drug, String> productName;
    @FXML
    private TableColumn<Drug, String> strain;
    @FXML
    private TableColumn<Drug, String> indications;
    @FXML
    private TextField tfDrugSearch;

    List<Drug> drugList;
    private ObservableList<Drug> tableList = FXCollections.observableArrayList();
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        drugList = PrescribeSocketClient.loadAllDrugsFromBusinessLayer();

        searchDrug();

    }

    public void searchDrug(){
        tableList.clear();
        drugTable.getItems().clear();
        if(drugList != null){
            for(Drug dr : drugList){
                if(dr.findText(tfDrugSearch.getText())){
                    tableList.add(dr);
                }
            }
        }
        product_id.setCellValueFactory(new PropertyValueFactory<>("product_id"));
        productName.setCellValueFactory(new PropertyValueFactory<>("productName"));
        strain.setCellValueFactory(new PropertyValueFactory<>("strain"));
        indications.setCellValueFactory(new PropertyValueFactory<>("indications"));
        drugTable.setItems(tableList);
    }

    public void openBookInfoView(MouseEvent mouseEvent)
    {
        if (this.drugTable.getSelectionModel().getSelectedItem() != null && mouseEvent.getClickCount() == 2)
        {
            Drug selectedDrug = this.drugTable.getSelectionModel().getSelectedItem();
        }
    }
}
