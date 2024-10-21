using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{


    public int health;
    public int numOfLives;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;



    // Update is called once per frame
    void Update()
    {
        liveChanges();
    }



    public void liveChanges()
    {

        if (health > numOfLives)
        {
            health = numOfLives;
        }


        for (int i = 0; i < lives.Length; i++)
        {

            if (i < health)
            {
                lives[i].sprite = fullLive;
            }

            else
            {
                lives[i].sprite = emptyLive;
            }


            if (i < numOfLives)
            {
                lives[i].enabled = true;
            }

            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
