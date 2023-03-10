using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "test/Param2")]
public class Param2 : ScriptableObject
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    public GameObject[] createPrefab;
    /*[SerializeField]
    [Tooltip("生成する範囲A")]
    public Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    public Transform rangeB;*/
    [SerializeField, Range(0, 100)]
    public int ObjCount;
}
