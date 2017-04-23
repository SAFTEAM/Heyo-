using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System.IO;
using UnityEngine.UI;

public class Load_Scene : MonoBehaviour {
    private Button btn_restart;
    public void LoadScreen(string screenName)
    {
          SceneManager.LoadScene(screenName);
    }
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
