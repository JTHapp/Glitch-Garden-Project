using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = default;
    [SerializeField] GameObject gun = default;
    AttackerSpawner myLaneSpawner = default;
    Animator animator = default;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    
    private void SetLaneSpawner()
    {
        AttackerSpawner[] Spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in Spawners)
        {
            bool IsCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        { 
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}
