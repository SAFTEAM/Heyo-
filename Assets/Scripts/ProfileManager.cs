using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class ProfileManager : MonoBehaviour
{
    //Tanımlamalar
    Profile prf;

    public Button button_Save;

    public InputField Inp_Username;
    public InputField Inp_Age;

    public Text Text_Levelnumber;
    //Profil ekranı okuma ve kaydetme işlemleri
    void Start()
    {
        //Dosya kontrolü
        if (File.Exists(Application.persistentDataPath + "/profile.json"))
        {
            LoadSettings();
            Text_Levelnumber.text = Convert.ToString(prf.Level);
            Inp_Username.text = prf.Username;
            Inp_Age.text = Convert.ToString(prf.Age);
        }

        else
        {
            Text_Levelnumber.text = Convert.ToString(1);
        }

        button_Save.onClick.AddListener(delegate { SaveSettings(); });
    }

    public void LoadSettings()
    {
        prf = JsonUtility.FromJson<Profile>(File.ReadAllText(Application.persistentDataPath + "/profile.json"));
    }

    public void SaveSettings()
    {
        prf = new Profile();
        prf.Username = Inp_Username.text;
        prf.Age = Convert.ToInt32(Inp_Age.text);
        prf.Level = Convert.ToInt32(Text_Levelnumber.text);

        string jsonData = JsonUtility.ToJson(prf, true);
        File.WriteAllText(Application.persistentDataPath + "/profile.json", jsonData);

        SceneManager.LoadScene("Menu");
    }

}
