using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using System.IO;

public class SettingsManager : MonoBehaviour {
    //Tanımlamalar
    public Slider slider_music;
    public Toggle toggle_vibration;

    public GameSettings gamesettings;
    public AudioSource music_source;
    public Button button_save;

    void Start ()
    {
        gamesettings = new GameSettings();        
        //Buton tıklama  ve değişme fonksiyonları
        slider_music.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        toggle_vibration.onValueChanged.AddListener(delegate { OnVibrationChange(); });
        button_save.onClick.AddListener(delegate { OnSaveSettingButton(); });

        if(File.Exists(Application.persistentDataPath+"/gamesettings.json")==true)
        {
            LoadSettings();
        }      
    }
    //Kayıt işlemi
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gamesettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json",jsonData);
    }
    //Okuma İşlemi
    public void LoadSettings()
    {
        gamesettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        slider_music.value = gamesettings.music_volume;
        toggle_vibration.isOn = gamesettings.vibration;
    }
    public void OnSaveSettingButton()
    {
        SaveSettings();
    }
    public void OnMusicVolumeChange()
    {     
        music_source.volume = gamesettings.music_volume=slider_music.value;       
    }
    public void OnVibrationChange()
    {
        if (toggle_vibration.isOn)
            gamesettings.vibration = true;
        else
            gamesettings.vibration = false;    
    }
  
}
