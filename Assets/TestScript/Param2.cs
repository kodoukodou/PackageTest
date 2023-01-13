using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "test/Param2")]
public class Param2 : ScriptableObject
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    public GameObject[] createPrefab;
    /*[SerializeField]
    [Tooltip("��������͈�A")]
    public Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    public Transform rangeB;*/
    [SerializeField, Range(0, 100)]
    public int ObjCount;
}
