using UnityEngine;

public class WireSnapZone : MonoBehaviour
{
    public string correctWire;
    public Transform snapPoint;
    public ElectricityPuzzleManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == correctWire)
        {
            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            manager.CompleteWire(correctWire);

            gameObject.SetActive(false);
        }
    }
}