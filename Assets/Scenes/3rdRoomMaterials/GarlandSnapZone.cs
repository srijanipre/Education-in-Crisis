using UnityEngine;

public class GarlandSnapZone : MonoBehaviour
{
    public Transform snapPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Make sure it's a draggable object (optional tag check)
        if (other.CompareTag("Draggable"))
        {
            // Snap position + rotation
            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;

            // Disable physics so it stays
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
}