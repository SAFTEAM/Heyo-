using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Game_Exit : MonoBehaviour
{
    //Buton tanımı
    public Button btn_Exit;

  
    void Start()
    {
        //Çıkış fonksiyonu
        btn_Exit.onClick.AddListener(() =>
        {
            Application.Quit();
        }
    );
    }
}
