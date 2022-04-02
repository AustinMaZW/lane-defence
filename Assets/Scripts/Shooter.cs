using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>(); //get animator component in game object, since both on same parent level
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            //set the parameter in animator transition to be true so it would transition the state
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //set the parameter in animator transition to be true so it would transition the state
            animator.SetBool("isAttacking", false);

        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        
        foreach (AttackerSpawner spawner in spawners)
        {
            // check if spawner y coordinate is same as position of object that calls the method (shooter)
            // Mathf.Epsilon is the smallest number that we can identify (since in computer there may be a small fraction of diff
            // taking Abs value because there are cases where number could be neg but still not in same lane.
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
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
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
