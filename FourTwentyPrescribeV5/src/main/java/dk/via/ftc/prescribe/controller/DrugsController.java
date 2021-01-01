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
import java.util.List;
import java.util.ResourceBundle;

/**
 * initializable is an interface that has one method called initialize which we use to populate the druglist from the business layer
 * drugTable uses tableList as its model for each drug
 * tableList uses drugList to get its drugs
 */
public class DrugsController implements Initializable {
    //prod.productName, prod.strain, prod.indications, prod.product_id
    @FXML
    private TableView<Drug> drugTable;
    @FXML
    private TableColumn<Drug, String> product_id;
    @FXML
    private TableColumn<Drug, String> productName;
    @FXML
    private TableColumn<Drug, String> strain;
    @FXML
    private TableColumn<Drug, String> indications;
    @FXML
    private TextField tfDrugSearch;
    /**
     *
     */
    List<Drug> drugList;
    private ObservableList<Drug> tableList = FXCollections.observableArrayList();

    /**
     * before GUI launches, call PrescribeSocketClient to load all the drugs from the business layer and assigns it to drugList
     * @param url
     * @param resourceBundle
     */
    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        drugList = PrescribeSocketClient.loadAllDrugsFromBusinessLayer();

        searchDrug();

    }

    /**
     * reads in text entered in the search box
     * clears observablelist which is tableList that contains the data
     * drugTable is the table that displays the data in observableList
     * tfDrugSearch is the search text field and its text will be used to search each drug for a match
     */
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
        product_id.setCellValueFactory(new PropertyValueFactory<>("productId"));
        productName.setCellValueFactory(new PropertyValueFactory<>("productName"));
        strain.setCellValueFactory(new PropertyValueFactory<>("strain"));
        indications.setCellValueFactory(new PropertyValueFactory<>("indications"));
        drugTable.setItems(tableList);
    }

    /**
     * if drug is selected should return to the prescriber form, currently prints to console
     * @param mouseEvent
     */

    public void selectDrugInfoView(javafx.scene.input.MouseEvent mouseEvent) {
        if (this.drugTable.getSelectionModel().getSelectedItem() != null && mouseEvent.getClickCount() == 2)
        {
            Drug selectedDrug = this.drugTable.getSelectionModel().getSelectedItem();
            System.out.println(selectedDrug.getProductName());
        }
    }


}
