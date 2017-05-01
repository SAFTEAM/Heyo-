using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using System.IO;
using UnityEngine.SceneManagement;

public class Level_Find : MonoBehaviour {
    
    Level lvl;

    public Button button_CommandScreen;

	void Start () {
    //Seviye tespiti
        lvl = new Level();
        lvl.name =Application.loadedLevelName;
        button_CommandScreen.onClick.AddListener(delegate { OnSaveSettingButton(); });

    }
    //Kayıt işlemi
    public void SaveSettings()
    {

        string jsonData = JsonUtility.ToJson(lvl, true);
        File.WriteAllText(Application.persistentDataPath + "/level.json", jsonData);

    }
    //Okuma İşlemi
    public void LoadSettings()
    {

        lvl = JsonUtility.FromJson<Level>(File.ReadAllText(Application.persistentDataPath + "/level.json"));
        SceneManager.LoadScene(lvl.name);

    }
    //Buton Fonksiyonu
    public void OnSaveSettingButton()
    {
        SaveSettings();
    }
}
