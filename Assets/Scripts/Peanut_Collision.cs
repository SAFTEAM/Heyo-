using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts;
using System;

public class Peanut_Collision : MonoBehaviour
{
    //Tanımlamalar
    public GameObject interactive_object;
    public GameObject scene;

    public Button btn_restart;
    public Button btn_next;
    public Button btn_back;

    public GameSettings gamesettings;

    public Text finish_text;
    
    ArrayList levels = new ArrayList { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Çarpışma olduğunda yapılacaklar
        if (collision.gameObject.tag== interactive_object.gameObject.tag)
        {
            if(interactive_object.gameObject.tag== "Peanut")
            {
                scene.SetActive(true);
                btn_restart.gameObject.SetActive(false);
                btn_next.gameObject.SetActive(true);

                finish_text.text = "BASARDINIZ !";
                finish_text.color = Color.green;
                GameObject fistik = GameObject.Find("Peanut");
                Destroy(fistik);
                Debug.Log("peanut");
                LevelSave();
            }                     

            else if (interactive_object.gameObject.tag == "Elephant")
            {
                scene.SetActive(true);
                btn_next.gameObject.SetActive(false);
                btn_restart.gameObject.SetActive(true);
                finish_text.text = "BASARAMADINIZ !";
                finish_text.color = Color.red;           
                Debug.Log("Duvar");
            }
            //Seviye kayıt işlemi
            Destroy(interactive_object);
            gamesettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

            if (gamesettings.vibration)
                Handheld.Vibrate();
        }
    }
    public void Start()
    {
        string level= Application.loadedLevelName;

        btn_restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(level);
        });

        btn_next.onClick.AddListener(() =>
        {
            string bulunan="";
            for (int i=0;i<levels.Count;i++)
            {
                if (level ==(string) levels[i])
                    bulunan =(string) levels[i+1];
            }
            SceneManager.LoadScene(bulunan);
        });

        btn_back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level_Menu");
        });

    }
    //Seviye kayıt fonksiyonu
    void LevelSave()
    {
        
        string levelname = Application.loadedLevelName;

        Profile prf = new Profile();
        prf = JsonUtility.FromJson<Profile>(File.ReadAllText(Application.persistentDataPath + "/profile.json"));
        int temp = prf.Level;
        for (int i = 0; i < levels.Count; i++)
        {
            if (levelname == Convert.ToString(levels[i]) && temp<i+2)
                prf.Level = i + 2;
        }

        string jsonData = JsonUtility.ToJson(prf, true);
        File.WriteAllText(Application.persistentDataPath + "/profile.json", jsonData);
    }
}
