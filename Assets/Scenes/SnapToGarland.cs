using UnityEngine;

public class SnapToGarland : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnapPoint"))
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}