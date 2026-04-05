using UnityEngine;

public class SnapToGarland : MonoBehaviour
{
    public Transform[] snapPoints;
    public float snapRange = 1.5f;

    private bool isSnapped = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isSnapped) return;

        TrySnap(); // ALWAYS check proximity
    }

    void TrySnap()
    {
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (Transform point in snapPoints)
        {
            float dist = Vector3.Distance(transform.position, point.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = point;
            }
        }

        // Snap ONLY if close enough
        if (closest != null && minDist <= snapRange)
        {
            transform.position = closest.position;
            transform.rotation = closest.rotation;

            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            isSnapped = true;
        }
    }
}