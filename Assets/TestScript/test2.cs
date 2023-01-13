using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class test2: MonoBehaviour
{
    public Transform parent;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;
    public bool PoolCheck;

    [SerializeField]
    Param2 param;
    private int a=0;
    List<Object> objs_ = new List<Object>();
    private GameObject obj;
    //public GameObject s;

    ObjectPool<GameObject> ObjectPool;

    void Start()
    {
        ObjectPool = new ObjectPool<GameObject>
        (
            createFunc: CreatePooledItem,         // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
            actionOnGet: OnTakeFromPool,          // プールからオブジェクトを取得する時に呼び出されます
            actionOnRelease: OnReturnedToPool                           // プールするオブジェクトの最大数。最大数を超えたオブジェクトに対しては actionOnRelease ではなく actionOnDestroy が呼ばれます
        );

        if (PoolCheck)
        {
            for (int i = 0; i < 100; i++)
            {
                /*// rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x1 = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y1 = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z1 = Random.Range(rangeA.position.z, rangeB.position.z);
                obj = Instantiate(param.createPrefab[a % 3], new Vector3(x1, y1, z1), param.createPrefab[a % 3].transform.rotation, this.transform);*/
                //Debug.Log("OK");
                obj = ObjectPool.Get();
                a++;
                //obj.SetActive(false);
                var obj2 = obj.GetComponent<Object>();
                objs_.Add(obj2);
            }
        }
        
    }
    GameObject CreatePooledItem()
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x1 = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y1 = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z1 = Random.Range(rangeA.position.z, rangeB.position.z);
        return Instantiate(param.createPrefab[a % 3], new Vector3(x1, y1, z1), param.createPrefab[a % 3].transform.rotation, this.transform);
    }
    private void OnTakeFromPool(GameObject GameObject)
    {
        // プールから取得したオブジェクトをアクティブにします
        GameObject.SetActive(false);
    }
    public void OnReturnedToPool(GameObject GameObject)
    {
        // プールに戻すオブジェクトは非アクティブにします
        GameObject.SetActive(false);
    }

    void Update()
    {
        if (PoolCheck)
        {
            int Count=0;
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    Count++;
                }
            }
            //Debug.Log(Count);

            if (param.ObjCount > Count)
            {
                AddObj();
            }
        }
        else
        {
            if (objs_.Count < param.ObjCount)
                AddObj();
            if (objs_.Count > param.ObjCount)
                RemoveObj();
            if (param.ObjCount == 0)
                return;
        }

    }

    void AddObj()
    {
        if (PoolCheck)
        {
            for (int i = param.ObjCount; i>0; i--)
            {
                //Debug.Log(param.ObjCount);
                Debug.Log(objs_[i]);
                objs_[i].SetActive(true);
                //s.SetActive(true);
                //ObjectPool.Get();
            }
        }
        else
        {
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x1 = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
            float y1 = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
            float z1 = Random.Range(rangeA.position.z, rangeB.position.z);

            // GameObjectを上記で決まったランダムな場所に生成
            obj = Instantiate(param.createPrefab[a % 3], new Vector3(x1, y1, z1), param.createPrefab[a % 3].transform.rotation, this.transform);
            //obj.transform.SetParent(transform);
            a++;

            var obj2 = obj.GetComponent<Object>();
            objs_.Add(obj2);
        }
    }

    void RemoveObj()
    {
        if (PoolCheck)
        {
            for (int i = 0; i < 100 - param.ObjCount; i++)
            {
                var lastIndex = objs_.Count - 1;
                var obj3 = objs_[lastIndex];
                //objs_[i].SetActive(false);
                lastIndex--;
            }
        }
        else
        {
            var lastIndex = objs_.Count - 1;
            var obj3 = objs_[lastIndex];
            Destroy(obj3.gameObject);
            objs_.RemoveAt(lastIndex);
            //Debug.Log(objs_.Count);
        }
    }
}