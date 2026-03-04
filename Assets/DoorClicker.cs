using UnityEngine;

public class DoorClicker : MonoBehaviour
{
    public float distance = 8f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                DoorToggle door = hit.collider.GetComponentInParent<DoorToggle>();

                if (door != null)
                {
                    door.Toggle();
                }
            }
        }
    }
}