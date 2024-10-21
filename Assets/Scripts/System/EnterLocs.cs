using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLocs : MonoBehaviour
{

    public GameObject activeFrame;
    public GameObject passiveFrame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeFrame.SetActive(true);
            passiveFrame.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeFrame.SetActive(false);
            passiveFrame.SetActive(true);
        }
    }

}
