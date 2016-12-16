using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuKod : MonoBehaviour {

	// Use this for initialization
    public void LoadScreen(string screenName)
    {
        SceneManager.LoadScene(screenName);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
