using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public GameObject fistik;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name==fistik.tag)
        {
            Destroy(fistik);
            Debug.Log("yasin");
        }
    }
}
