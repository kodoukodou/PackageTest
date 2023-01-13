using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public sealed class Example : MonoBehaviour
{
    private ObjectPool<GameObject> m_objectPool; // オブジェクトプール
    public GameObject createPrefab;
    //int a = 0;

    private void Start()
    {
        // オブジェクトプールを作成します
        m_objectPool = new ObjectPool<GameObject>
        (
            createFunc: CreatePooledItem,         // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
            actionOnGet: OnTakeFromPool,          // プールからオブジェクトを取得する時に呼び出されます
            actionOnRelease: OnReturnedToPool,    // プールにオブジェクトを戻す時に呼び出されます
            actionOnDestroy: OnDestroyPoolObject, // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
            collectionCheck: true,                // すでにプールに戻されているオブジェクトをプールに戻そうとした時にエラーを出すなら true
            defaultCapacity: 10,                  // 内部でプールを管理する Stack のデフォルトのキャパシティ
            maxSize: 10                           // プールするオブジェクトの最大数。最大数を超えたオブジェクトに対しては actionOnRelease ではなく actionOnDestroy が呼ばれます
        );
    }

    // プールにオブジェクトが不足している時にオブジェクトを生成するために呼び出されます
    private GameObject CreatePooledItem()
    {
        // キューブを生成します
        //return GameObject.CreatePrimitive(PrimitiveType.Cube);
        return Instantiate (createPrefab, this.transform);
    }

    // プールからオブジェクトを取得する時に呼び出されます
    private void OnTakeFromPool(GameObject gameObject)
    {
        // プールから取得したオブジェクトをアクティブにします
        gameObject.SetActive(true);

        // オブジェクトの位置をランダムに設定します
        const float range = 5f;
        gameObject.transform.position = new Vector3
        (
            x: Random.Range(-range, range),
            y: Random.Range(-range, range),
            z: Random.Range(-range, range)
        );

        // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチン
        IEnumerator Process()
        {
            yield return new WaitForSeconds(2);
            m_objectPool.Release(gameObject);
        }

        // プールから取得したオブジェクトを 2 秒後にプールに戻すコルーチンを実行します
        StartCoroutine(Process());
    }

    // プールにオブジェクトを戻す時に呼び出されます
    private void OnReturnedToPool(GameObject gameObject)
    {
        // プールに戻すオブジェクトは非アクティブにします
        gameObject.SetActive(false);
    }

    // プールの最大サイズを超えたオブジェクトを削除する時に呼び出されます
    private void OnDestroyPoolObject(GameObject gameObject)
    {
        // 最大サイズを超えたオブジェクトはプールに戻さずに削除します
        Destroy(gameObject);
    }

    private void OnGUI()
    {
        GUILayout.Label($"プール対象のすべてのオブジェクトの数：{m_objectPool.CountAll.ToString()}");
        GUILayout.Label($"アクティブなオブジェクトの数：{m_objectPool.CountActive.ToString()}");
        GUILayout.Label($"非アクティブなオブジェクトの数：{m_objectPool.CountInactive.ToString()}");

        if (GUILayout.Button("生成"))
        {
            for (int i = 0; i < 2; i++)
            {
                var gameObject = m_objectPool.Get();
            }
        }
        else if (GUILayout.Button("プールをクリア"))
        {
            m_objectPool.Clear();
        }
    }
}
