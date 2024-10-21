using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{

    //playerData
    [SerializeField] public HealthSystem hSys;

    //trapData
    [SerializeField] private int DamageNumber;
    [SerializeField] private float Delay;

    private Collider2D TrapCollision;
    private Coroutine coroutuneSpikes;





    private void OnTriggerEnter2D(Collider2D TrapCollision)
    {

        if (TrapCollision.gameObject.tag.Equals("Player"))
        {
            TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D TrapCollision)
    {
        if (TrapCollision.gameObject.tag.Equals("Player"))
        {
            StopCoroutine(coroutuneSpikes);
            Debug.Log("Урон не получаешь");
        }
    }

    private void TakeDamage()
    {
        if (hSys.health > 0)
        {
            coroutuneSpikes = StartCoroutine(routine: Damage());
            Debug.Log("Урон получаешь");
        }

        else
        {
            hSys.health = 0;
            Debug.Log("Ты умер");
        }

    }

    IEnumerator Damage()
    {
        while (hSys.health > 0)
        {
            hSys.health -= DamageNumber;
            yield return new WaitForSeconds(Delay);
        }
    }

}
