using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    // Start is called before the first frame update

    IEnumerator Start()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); //choose a random index of attacker
        Spawn(attackerPrefabArray[attackerIndex]); //spawn that random attacker
    }
    private void Spawn (Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
        // instantiated child belongs to gameobject that calls spawn attacker. 
        // This is because transform represents the gameobject itself (e.g. it's position, child position etc)
    }

}
