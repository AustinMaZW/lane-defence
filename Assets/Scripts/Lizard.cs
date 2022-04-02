using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>()) // check if collided object have defender script 
        {
            GetComponent<Attacker>().Attack(otherObject); //trigger attack from attacker script
        }
    }
}
