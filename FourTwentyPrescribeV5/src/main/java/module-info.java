module FourTwentyPrescribeV5 {
    requires javafx.controls;
    requires javafx.fxml;
    requires com.fasterxml.jackson.databind;
    requires java.desktop;
    requires junit;
    opens dk.via.ftc.prescribe to javafx.fxml;
    exports dk.via.ftc.prescribe;
    opens dk.via.ftc.prescribe.controller to javafx.fxml;
    exports dk.via.ftc.prescribe.controller;
    opens dk.via.ftc.prescribe.dao to javafx.fxml, com.fasterxml.jackson.databind;
    exports dk.via.ftc.prescribe.dao;
    opens dk.via.ftc.prescribe.model to javafx.base;
    exports dk.via.ftc.prescribe.model;


}