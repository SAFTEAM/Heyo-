using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Game_Exit : MonoBehaviour
{
    public Button btn_Exit;
    void Start()
    {
        btn_Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        }
    );
    }
}
