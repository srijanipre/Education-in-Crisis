using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    public float openAngle = -90f;
    public float speed = 120f;

    private bool open = false;
    private Quaternion closedRot;
    private Quaternion openRot;

    private AudioSource audioSource; // NEW

    void Start()
    {
        closedRot = transform.localRotation;
        openRot = closedRot * Quaternion.Euler(0, 0, openAngle);

        audioSource = GetComponent<AudioSource>(); // NEW
    }

    void Update()
    {
        Quaternion target = open ? openRot : closedRot;
        transform.localRotation =
            Quaternion.RotateTowards(transform.localRotation, target, speed * Time.deltaTime);
    }

    public void Toggle()
    {
        open = !open;

        // NEW: play door sound when toggled
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}