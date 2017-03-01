using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject fistik;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="fistik")
        {
            Destroy(fistik);
            SceneManager.LoadScene("Levelmenu");
        }
    }
}
