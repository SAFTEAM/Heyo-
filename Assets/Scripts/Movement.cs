using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    
    public float playerSpeed = 10; 
    public float turnSpeed = 100; 

    void Update()
    {

        MoveForward(); 
        TurnRightAndLeft();
    }

    void MoveForward()
    {

        if (Input.GetKey("up"))
        {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }

    }

    void TurnRightAndLeft()
    {

        if (Input.GetKey("right"))
        {
            transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="fistik")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="fistik")
        {
            Debug.Log("dokundu");
        }
    }
}
