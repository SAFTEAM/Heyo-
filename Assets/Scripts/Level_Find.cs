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
        lvl = new Level();
        lvl.name =Application.loadedLevelName;
        button_CommandScreen.onClick.AddListener(delegate { OnSaveSettingButton(); });
    }
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(lvl, true);
        File.WriteAllText(Application.persistentDataPath + "/level.json", jsonData);
    }
    public void LoadSettings()
    {
        lvl = JsonUtility.FromJson<Level>(File.ReadAllText(Application.persistentDataPath + "/level.json"));
        SceneManager.LoadScene(lvl.name);
    }
    public void OnSaveSettingButton()
    {
        SaveSettings();
    }
}
