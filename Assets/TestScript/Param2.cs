using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "test/Param2")]
public class Param2 : ScriptableObject
{
    [SerializeField]
    [Tooltip("¶¬‚·‚éGameObject")]
    public GameObject[] createPrefab;
    /*[SerializeField]
    [Tooltip("¶¬‚·‚é”ÍˆÍA")]
    public Transform rangeA;
    [SerializeField]
    [Tooltip("¶¬‚·‚é”ÍˆÍB")]
    public Transform rangeB;*/
    [SerializeField, Range(0, 100)]
    public int ObjCount;
}
