using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPosition : MonoBehaviour
{
    [SerializeField] List<Spawner> spawners = new List<Spawner>();
    [SerializeField] private Transform player;
    
    void Reposition()
    {
        for(int i = 0; i < spawners.Count; i++)
        {
            player.position = spawners[i].PreviousSpawnPosition;
            player.rotation = spawners[i].PreviousSpawnDirection;
        }
    }
}

public class Spawner
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Quaternion spawnDirection;

    public Vector3 PreviousSpawnPosition { get {  return spawnPosition; } }
    public Quaternion PreviousSpawnDirection { get {  return spawnDirection; } }
}
