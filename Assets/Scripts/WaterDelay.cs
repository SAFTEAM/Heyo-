using UnityEngine;
using System.Collections;

public class WaterDelay : MonoBehaviour
{
    public GameObject water;
    // Use this for initialization
    IEnumerator ActivationRoutine()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(10);

            water.SetActive(false);

            yield return new WaitForSeconds(3);

            water.SetActive(true);

        }
    
    }
    private void Start()
    {
     //   StartCoroutine(ActivationRoutine());
    }
}
