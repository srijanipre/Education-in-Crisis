uusing UnityEngine;

public class ElectricityPuzzleManager : MonoBehaviour
{
    public GameObject elec;
    public GameObject tri;
    public GameObject city;

    public Material lettersOff;
    public Material lettersOn;

    private bool wire1Done;
    private bool wire2Done;
    private bool wire3Done;

    void Start()
    {
        SetMaterial(elec, lettersOff);
        SetMaterial(tri, lettersOff);
        SetMaterial(city, lettersOff);
    }

    public void CompleteWire(string wireName)
    {
        if (wireName == "wire1" && !wire1Done)
        {
            wire1Done = true;
            SetMaterial(elec, lettersOn);
        }

        if (wireName == "wire2" && !wire2Done)
        {
            wire2Done = true;
            SetMaterial(tri, lettersOn);
        }

        if (wireName == "wire3" && !wire3Done)
        {
            wire3Done = true;
            SetMaterial(city, lettersOn);
        }

        if (wire1Done && wire2Done && wire3Done)
        {
            Debug.Log("Electricity puzzle solved!");
        }
    }

    void SetMaterial(GameObject obj, Material mat)
    {
        Renderer r = obj.GetComponent<Renderer>();
        if (r != null)
        {
            r.material = mat;
        }
    }
}