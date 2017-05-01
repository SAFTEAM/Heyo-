using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.IO;
using System;
using UnityEngine.UI;

public class LevelMenuControl : MonoBehaviour
{
    //Tanımlamalar
    public Sprite sprite_open;
    public Sprite sprite_close;

    Profile prf;

    ArrayList levels = new ArrayList {"level1","level2","level3","level4","level5","level6","level7","level8","level9","level10" };

    void Start () {
        //Seviyeleri profilin seviyesine göre kilitleme işlemi
        prf = new Profile();

        if (File.Exists(Application.persistentDataPath + "/profile.json"))
        {
            for (int i = 0; i < 10; i++)
            {
                Button btn = GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
                btn.enabled = false;
                btn.image.overrideSprite = sprite_close;
            }

            LoadSettings();

            for(int i=0;i< prf.Level;i++)
            {
              Button btn=  GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
              btn.enabled = true;
              btn.image.overrideSprite = sprite_open;
            }          
        }

        else
        {
            //Profil yoksa
            prf = new Profile();
            prf.Username = "ISIMSIZ";
            prf.Age = 5;

            string jsonData = JsonUtility.ToJson(prf, true);
            File.WriteAllText(Application.persistentDataPath + "/profile.json", jsonData);

            for (int i = 0; i < 10; i++)
            {
                Button btn = GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
                btn.enabled = false;
                btn.image.overrideSprite = sprite_close;
            }

            LoadSettings();

            for (int i = 0; i < prf.Level; i++)
            {
                Button btn = GameObject.Find(Convert.ToString(levels[i])).GetComponent<Button>();
                btn.enabled = true;
                btn.image.overrideSprite = sprite_open;
            }
        }

    }
    /// Okuma İşlemi
    public void LoadSettings()
    {
        prf = JsonUtility.FromJson<Profile>(File.ReadAllText(Application.persistentDataPath + "/profile.json"));      
    }
    
}
