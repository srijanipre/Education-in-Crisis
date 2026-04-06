using UnityEngine;

public class TabletClickHandler : MonoBehaviour
{
    public GameObject bigTablet;

    void OnMouseDown()
    {
        if (bigTablet != null)
        {
            bigTablet.SetActive(true);
        }
    }

    void Update()
    {
        if (CAVE2.GetButtonDown(CAVE2.Button.Button7))
        {
            if (bigTablet != null)
            {
                bigTablet.SetActive(true);
            }
        }
    }
}