using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget = default;
    float health = default;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    public void Start()
    {
        var attackerHealth = GetComponent<Health>();
        health = attackerHealth.health;
    }

    private void OnDestroy() // this is the pesky little method that is causing all of my problems
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        CheckHealth();
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void CheckHealth()
    {
        Debug.Log("check health method called");
        Debug.Log("Attacker health: " + health);

        if (health <= 0) //zero health is never achieved
        {
            Debug.Log("zero health confirmed"); 
            FindObjectOfType<LevelController>().AttackerKilled();
        }
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
