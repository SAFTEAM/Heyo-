using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cikis : MonoBehaviour
{

    // Use this for initialization

    public Button btnexit;
    void Start()
    {
        btnexit.onClick.AddListener(() =>
        {
            Application.Quit();
            Debug.Log("bas");
        }
    );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
