using UnityEngine;

public class DoorClicker : MonoBehaviour
{
    public float distance = 8f;

    void Update()
    {
        bool laptopClick = Input.GetMouseButtonDown(0);
        bool caveClick = CAVE2.GetButtonDown(CAVE2.Button.ButtonUp);

        if (laptopClick || caveClick)
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