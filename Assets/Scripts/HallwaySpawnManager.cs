using UnityEngine;

public class HallwaySpawnManager : MonoBehaviour
{
    public Transform playerObject;

    void Start()
    {
        if (string.IsNullOrEmpty(SpawnState.nextHallwaySpawn))
            return;

        GameObject spawn = GameObject.Find(SpawnState.nextHallwaySpawn);

        if (spawn != null && playerObject != null)
        {
            playerObject.position = spawn.transform.position;
            playerObject.rotation = spawn.transform.rotation;
        }

        SpawnState.nextHallwaySpawn = "";
    }
}