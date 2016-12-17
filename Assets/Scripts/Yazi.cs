using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Yazi : MonoBehaviour {

    public Button btnpati;
    public Button btnsagdon;
    public Button btnsoldon;

    public Button btnsil;
    void Start () {
        btnpati.onClick.AddListener(() => {
            hareket("İlerle \n");
            });
        btnsagdon.onClick.AddListener(() => {
            hareket("Sağa Dön \n");
            });
        btnsoldon.onClick.AddListener(() => {
            hareket("Sola Dön \n");
        });
        btnsil.onClick.AddListener(() => {
            stringToEdit = "";            
        });
    }
    public string stringToEdit = "Komutları Giriniz";
  
    void OnGUI()
    {
        stringToEdit=GUI.TextArea(new Rect(120, 100, 1000, 500), stringToEdit, 900);
    }
    void hareket(string deger)
    {
        stringToEdit += deger;
    }

    void Update () {
     
    }
}
