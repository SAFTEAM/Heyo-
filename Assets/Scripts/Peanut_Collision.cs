using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using Assets.Scripts;

public class Peanut_Collision : MonoBehaviour
{
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
        if (collision.gameObject.tag== interactive_object.gameObject.tag)
        {
            if(interactive_object.gameObject.tag=="Elephant")
            {
                scene.SetActive(true);
                btn_next.gameObject.SetActive(false);
                btn_restart.gameObject.SetActive(true);
                finish_text.text = "BASARAMADINIZ !";
                finish_text.color = Color.red;
                Debug.Log("Duvar");
            }
            else if (interactive_object.gameObject.tag == "Peanut")
            {
                scene.SetActive(true);
                btn_restart.gameObject.SetActive(false);
                btn_next.gameObject.SetActive(true);
                finish_text.text = "BASARDINIZ !";
                finish_text.color = Color.green;
                Debug.Log("peanut");        
            }
            interactive_object.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
          //  Destroy(interactive_object);
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
                    bulunan =(string) levels[i];
            }
            SceneManager.LoadScene(bulunan);
        });
        btn_back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level_Menu");
        });

    }
}
