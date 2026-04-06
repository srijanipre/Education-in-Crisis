using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHallwayTrigger : MonoBehaviour
{
    public string hallwaySceneName = "HallwayScene";
    public string hallwaySpawnName = "Spawn_From3rdRoom";
    public string requiredTag = "Player";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag(requiredTag))
        {
            hasTriggered = true;
            SpawnState.nextHallwaySpawn = hallwaySpawnName;
            SceneManager.LoadScene(hallwaySceneName);
        }
    }
}
