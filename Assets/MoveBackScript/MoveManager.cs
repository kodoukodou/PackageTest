using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public GameObject[] Plane;
    public GameObject LastPlane;
    Vector3 LastPos;
    int PlaneLast;

    // Start is called before the first frame update
    void Start()
    {
        PlaneLast = Plane.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        LastPos=LastPlane.transform.position;

        Plane[PlaneLast].transform.position = new Vector3(Plane[PlaneLast].transform.position.x, Plane[PlaneLast].transform.position.y, Plane[PlaneLast].transform.position.z);

    }
}
