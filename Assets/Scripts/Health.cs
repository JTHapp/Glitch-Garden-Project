using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    [SerializeField] GameObject deathVFX = default;
    [SerializeField] float destroyVFXDelay = 3f;
    
    public void DealDamage(float damage)
    {
        /*Attacker attacker = GetComponent<Attacker>(); //Another method I tried to deal with calling AttackerKilled(), it isn't working either
        Debug.Log(attacker);*/
        health -= damage;
        if (health <= 0 /*&& attacker*/)
        {
            /*TriggerDeathVFX();
            Destroy(gameObject);
            FindObjectOfType<LevelController>().AttackerKilled();
        }
        else
        {*/
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, destroyVFXDelay);

    }
}
