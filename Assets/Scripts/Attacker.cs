using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned(); 
        // awake occurs before anything else
        // so when attacker is instantiated, it immediately calls AttackerSpawned
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        //if statement to prevent when move to next scene and nullexception since cannot call null object
        if (levelController!=null)
        {
            levelController.AttackerKilled();
        }
        // OnDestroy occurs last
        // so when attacker is destroyed, attackerkilled is called.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attack (GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; } //avoid issues where another object is attacking but it's not current target of this object
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

}
