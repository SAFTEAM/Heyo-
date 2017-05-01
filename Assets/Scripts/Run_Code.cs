using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class Run_Code : MonoBehaviour
{
    //Tanımlamalar
    string[] commands;

    public GameObject elephant;
    

    void Start()
    {
        //Dosya kontrolü
        if (File.Exists(Application.persistentDataPath + @"/commandsave.txt"))
        {
            commands = System.IO.File.ReadAllLines(Application.persistentDataPath + @"/commandsave.txt");
            Code_Start();
        }
        System.IO.File.WriteAllText(Application.persistentDataPath + @"/commandsave.txt", " ");
    }
    //ileri fonksiyonu
    void Forward()
    {
        elephant.transform.Translate(0, 0.80f, 0);
    }
    //Sola Dön Fonksiyonu
    void Turn_Left()
    {
        elephant.transform.Rotate(Vector3.forward * 90);
    }
    //Sağa Dön Fonksiyonu
    void Turn_Right()
    {
        elephant.transform.Rotate(-Vector3.forward * 90);
    }

    //Komutları okuma fonksiyonu
    public void Code_Start()
    {
            for (int i = 0; i < commands.Length; i++)
            {
                if (Convert.ToString(commands[i]) == "Ilerle")
                {
                     Invoke("Forward", 1 + (i * 1f));                   
                }
                else if (Convert.ToString(commands[i]) == "Saga Don")
                {
                    Invoke("Turn_Right", 1 + (i * 1f));
                }
                else if (Convert.ToString(commands[i]) == "Sola Don")
                {
                    Invoke("Turn_Left", 1 + (i * 1f));
                }
            }  
    }

}

