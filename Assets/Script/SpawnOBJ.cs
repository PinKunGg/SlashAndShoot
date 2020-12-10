using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOBJ : MonoBehaviour
{
    public List<GameObject> targets;
    public float rate = 1f, MinSpawnRange, MaxSpawnRange;
    void Start()
    {
        InvokeRepeating("Spawn2", 1f, rate);
    }

    void Spawn2()
    {
        int spawnIndex = Random.Range(2, targets.Count);
        Vector3 spawnPos = new Vector3(Random.Range(-MaxSpawnRange / 2f, MaxSpawnRange / 2f), Random.Range(-1f, 2f), Random.Range(MinSpawnRange, MaxSpawnRange));
        Instantiate(targets[spawnIndex], spawnPos, targets[spawnIndex].transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position,new Vector3(MinSpawnRange * 2,MinSpawnRange * 2,MinSpawnRange * 2));
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,new Vector3(MaxSpawnRange * 2,MaxSpawnRange * 2,MaxSpawnRange * 2));
    }
}
