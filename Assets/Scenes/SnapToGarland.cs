using UnityEngine;


public class SnapToGarland : MonoBehaviour


{
    public Transform[] snapPoints;
    public float snapRange = 2f;

    private bool isSnapped = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isSnapped || rb == null) return;

        if (rb.velocity.magnitude < 0.05f)
        {
            TrySnap();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TrySnap();
        }

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

        if(closest != null)
        {
            transform.position = closest.position;
            transform.rotation = closest.rotation;
            transform.SetParent(closest);

            if(rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
            isSnapped = true;
        }
    }
 }
