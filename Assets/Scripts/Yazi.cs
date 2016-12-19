using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Threading;

public class Yazi : MonoBehaviour
{

    public Button btnpati;
    public Button btnsagdon;
    public Button btnsoldon;
    public Button btnsil;
    public Button btncalistir;
    public Button btnyukari;
    public GameObject fil;
    ArrayList komutlar = new ArrayList();
    public string stringToEdit = "";
    void Start()
    {

        btnpati.onClick.AddListener(() =>
        {
            hareket("İlerle \n");
        });
        btnsagdon.onClick.AddListener(() =>
        {
            hareket("Sağa Dön \n");
        });
        btnsoldon.onClick.AddListener(() =>
        {
            hareket("Sola Dön \n");
        });
        btnyukari.onClick.AddListener(() =>
        {
            hareket("Yukarı \n");
        });
        btnsil.onClick.AddListener(() =>
        {
            komutlar.Clear();
            stringToEdit = "";
        });
        btncalistir.onClick.AddListener(() =>
        {
            Move();
            komutlar.Clear();
            stringToEdit = "";
        });
    }
    void OnGUI()
    {
        stringToEdit = GUI.TextArea(new Rect(100, 450, 1050, 210), stringToEdit, 500);
    }
    void hareket(string deger)
    {
        komutlar.Add(deger);
        stringToEdit += deger;
    }


    void ileri()
    {
        fil.transform.Translate(0, 127, 0);
    }
    void yukari()
    {
        fil.transform.Translate(0, 90, 0);
    }
    void soldon()
    {
        fil.transform.Rotate(Vector3.forward * 90);
    }
    void sagdon()
    {
        fil.transform.Rotate(-Vector3.forward * 90);
    }
    public void Move()
    {
        for (int i = 0; i < komutlar.Count; i++)
        {

            if (Convert.ToString(komutlar[i]) == "İlerle \n")
            {
                Invoke("ileri", 1 + (i * 1.5f));
            }
            if (Convert.ToString(komutlar[i]) == "Sağa Dön \n")
            {
                Invoke("sagdon", 1 + (i * 1.5f));
            }

            if (Convert.ToString(komutlar[i]) == "Sola Dön \n")
            {
                Invoke("soldon", 1 + (i * 1.5f));
            }
            if (Convert.ToString(komutlar[i]) == "Yukarı \n")
            {
                Invoke("yukari", 1 + (i * 1.5f));
            }

        }
 
    }
}
