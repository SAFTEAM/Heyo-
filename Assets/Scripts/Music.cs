using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.IO;

public class Music : MonoBehaviour {

    private GameSettings gamesettings;
    public AudioSource music_source;
    void Start () {
        gamesettings = new GameSettings();
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            LoadSettings();
        }       
     
    }
   void LoadSettings()
    {
        gamesettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        music_source.volume = gamesettings.music_volume;
    }
    

}
