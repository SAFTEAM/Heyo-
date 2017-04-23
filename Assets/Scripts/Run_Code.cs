using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class Run_Code : MonoBehaviour
{
    string[] komutlar;
    public GameObject elephant;

    void Start()
    {
        if (File.Exists(Application.persistentDataPath + @"/commandsave.txt"))
        {
            komutlar = System.IO.File.ReadAllLines(Application.persistentDataPath + @"/commandsave.txt");
            Code_Start();
        }
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/commandsave.txt", " ");
    }

    void Forward()
    {
        elephant.transform.Translate(0, 0.80f, 0);
    }
    void Turn_Left()
    {
        elephant.transform.Rotate(Vector3.forward * 90);
    }
    void Turn_Right()
    {
        elephant.transform.Rotate(-Vector3.forward * 90);
    }
    void For()
    {
        elephant.transform.Rotate(-Vector3.forward * 90);
    }
    void If()
    {
        elephant.transform.Rotate(-Vector3.forward * 90);
    }

    public void Code_Start()
    {
        for (int i = 0; i < komutlar.Length; i++)
        {
            if (Convert.ToString(komutlar[i]) == "Ilerle")
            {
                Invoke("Forward", 1 + (i * 1.5f));
            }
            else if (Convert.ToString(komutlar[i]) == "Saga Don")
            {
                Invoke("Turn_Right", 1 + (i * 1.5f));
            }
            else if (Convert.ToString(komutlar[i]) == "Sola Don")
            {
                Invoke("Turn_Left", 1 + (i * 1.5f)); 
            }
            else if (Convert.ToString(komutlar[i]) == "Dongu")
            {
                Invoke("For", 1 + (i * 1.5f));
            }
            else if (Convert.ToString(komutlar[i]) == "Eger")
            {
                Invoke("If", 1 + (i * 1.5f)); 
            }                  
        }       
    }
}
