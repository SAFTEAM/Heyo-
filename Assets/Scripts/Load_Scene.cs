using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System.IO;
using UnityEngine.UI;

public class Load_Scene : MonoBehaviour
{
    //Tanımlamalar
    private Button btn_restart;

    //Sahne yükleme fonksiyonu
    public void LoadScreen(string screenName)
    {
          SceneManager.LoadScene(screenName);
    }
    //Sahne yeniden başlat fonksiyonu
    public void RestartFunction()
    {
        string level = Application.loadedLevelName;

        btn_restart = GameObject.Find("Button_Restart").GetComponent<Button>();

        btn_restart.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(level);
        });
    }
}
