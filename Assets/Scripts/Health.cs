using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    //[SerializeField] AudioClip deathSound;
    //[SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, durationOfExplosion);
        //AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume); //death sound
    }
}
