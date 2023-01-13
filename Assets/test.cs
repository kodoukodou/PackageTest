/*using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class test: MonoBehaviour
{

    [SerializeField]
    [Tooltip("��������GameObject")]
    public GameObject[] createPrefab;
    //private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;
    [SerializeField, Range(1, 100)]
    public int ObjCount;

    void Start()
    {
        for (int a = 0; ObjCount > a; a++)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            var obj = Instantiate(createPrefab[a % 3], new Vector3(x, y, z), createPrefab[a % 3].transform.rotation);
            obj.transform.SetParent(transform);
        }
    }

    /*private void Update()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        mbineInstance[] combine = new CombineInstance[meshFilters.Length];


        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
            //meshFilters[i].gameObject.SetActive(false);
        }

        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combine);
        GetComponent<MeshCollider>().sharedMesh = meshFilter.mesh;
        transform.gameObject.SetActive(true);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class test : MonoBehaviour
{

    [SerializeField]
    [Tooltip("��������GameObject")]
    public GameObject[] createPrefab;
    //private GameObject createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;
    [SerializeField, Range(1, 100)]
    public int ObjCount;

    void Start()
    {
        for (int a = 0; ObjCount > a; a++)
        {
            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
            var obj = Instantiate(createPrefab[a % 3], new Vector3(x, y, z), createPrefab[a % 3].transform.rotation);
            obj.transform.SetParent(transform);
        }
    }

    private void Update()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];


        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }
            //meshFilters[i].gameObject.SetActive(false);
        }

        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combine);
        GetComponent<MeshCollider>().sharedMesh = meshFilter.mesh;
        transform.gameObject.SetActive(true);
    }
}