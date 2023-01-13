using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereMove : MonoBehaviour
{
    Vector3 startPosition, targetPosition;
    private Vector3 velocity = Vector3.zero;
    public float time = 1F;

    void Start()
    {
        targetPosition = new Vector3(20, 1, 0);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, time);
    }
}
