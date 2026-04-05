using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMarker : MonoBehaviour
{
    public float floatAmount = 0.15f;
    public float floatSpeed = 1.5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.localPosition = startPos + new Vector3(0f, yOffset, 0f);
    }
}