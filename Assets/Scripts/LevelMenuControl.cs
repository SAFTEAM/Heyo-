using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.IO;
using System;
using UnityEngine.UI;

public class LevelMenuControl : MonoBehaviour {

    Profile prf;
    ArrayList levels = new ArrayList {"level1","level2","level3","level4","level5","level6","level7","level8","level9","level10" };

    void Start () {
        prf = new Profile();
        if (File.Exists(Application.persistentDataPath + "/profile.json"))
        {
            for (int i = 0; i < 10; i++)
            {
                Button btn = GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
                btn.enabled = false;
            }
            LoadSettings();
            for(int i=0;i< prf.Level;i++)
            {
              Button btn=  GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
              btn.enabled = true;
            }          
        }

    }
    public void LoadSettings()
    {
        prf = JsonUtility.FromJson<Profile>(File.ReadAllText(Application.persistentDataPath + "/profile.json"));
      
    }
    
}
