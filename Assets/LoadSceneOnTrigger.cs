using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [Tooltip("Exact scene name from Assets/Scenes (no .unity)")]
    public string sceneToLoad;

    [Tooltip("Only trigger when something with this tag enters. Leave empty to allow anything.")]
    public string requiredTag = "";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        hasTriggered = true;
        SceneManager.LoadScene(sceneToLoad);
    }
}