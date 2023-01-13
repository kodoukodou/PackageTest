using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public sealed class Example : MonoBehaviour
{
    private ObjectPool<GameObject> m_objectPool; // �I�u�W�F�N�g�v�[��
    public GameObject createPrefab;
    //int a = 0;

    private void Start()
    {
        // �I�u�W�F�N�g�v�[�����쐬���܂�
        m_objectPool = new ObjectPool<GameObject>
        (
            createFunc: CreatePooledItem,         // �v�[���ɃI�u�W�F�N�g���s�����Ă��鎞�ɃI�u�W�F�N�g�𐶐����邽�߂ɌĂяo����܂�
            actionOnGet: OnTakeFromPool,          // �v�[������I�u�W�F�N�g���擾���鎞�ɌĂяo����܂�
            actionOnRelease: OnReturnedToPool,    // �v�[���ɃI�u�W�F�N�g��߂����ɌĂяo����܂�
            actionOnDestroy: OnDestroyPoolObject, // �v�[���̍ő�T�C�Y�𒴂����I�u�W�F�N�g���폜���鎞�ɌĂяo����܂�
            collectionCheck: true,                // ���łɃv�[���ɖ߂���Ă���I�u�W�F�N�g���v�[���ɖ߂����Ƃ������ɃG���[���o���Ȃ� true
            defaultCapacity: 10,                  // �����Ńv�[�����Ǘ����� Stack �̃f�t�H���g�̃L���p�V�e�B
            maxSize: 10                           // �v�[������I�u�W�F�N�g�̍ő吔�B�ő吔�𒴂����I�u�W�F�N�g�ɑ΂��Ă� actionOnRelease �ł͂Ȃ� actionOnDestroy ���Ă΂�܂�
        );
    }

    // �v�[���ɃI�u�W�F�N�g���s�����Ă��鎞�ɃI�u�W�F�N�g�𐶐����邽�߂ɌĂяo����܂�
    private GameObject CreatePooledItem()
    {
        // �L���[�u�𐶐����܂�
        //return GameObject.CreatePrimitive(PrimitiveType.Cube);
        return Instantiate (createPrefab, this.transform);
    }

    // �v�[������I�u�W�F�N�g���擾���鎞�ɌĂяo����܂�
    private void OnTakeFromPool(GameObject gameObject)
    {
        // �v�[������擾�����I�u�W�F�N�g���A�N�e�B�u�ɂ��܂�
        gameObject.SetActive(true);

        // �I�u�W�F�N�g�̈ʒu�������_���ɐݒ肵�܂�
        const float range = 5f;
        gameObject.transform.position = new Vector3
        (
            x: Random.Range(-range, range),
            y: Random.Range(-range, range),
            z: Random.Range(-range, range)
        );

        // �v�[������擾�����I�u�W�F�N�g�� 2 �b��Ƀv�[���ɖ߂��R���[�`��
        IEnumerator Process()
        {
            yield return new WaitForSeconds(2);
            m_objectPool.Release(gameObject);
        }

        // �v�[������擾�����I�u�W�F�N�g�� 2 �b��Ƀv�[���ɖ߂��R���[�`�������s���܂�
        StartCoroutine(Process());
    }

    // �v�[���ɃI�u�W�F�N�g��߂����ɌĂяo����܂�
    private void OnReturnedToPool(GameObject gameObject)
    {
        // �v�[���ɖ߂��I�u�W�F�N�g�͔�A�N�e�B�u�ɂ��܂�
        gameObject.SetActive(false);
    }

    // �v�[���̍ő�T�C�Y�𒴂����I�u�W�F�N�g���폜���鎞�ɌĂяo����܂�
    private void OnDestroyPoolObject(GameObject gameObject)
    {
        // �ő�T�C�Y�𒴂����I�u�W�F�N�g�̓v�[���ɖ߂����ɍ폜���܂�
        Destroy(gameObject);
    }

    private void OnGUI()
    {
        GUILayout.Label($"�v�[���Ώۂ̂��ׂẴI�u�W�F�N�g�̐��F{m_objectPool.CountAll.ToString()}");
        GUILayout.Label($"�A�N�e�B�u�ȃI�u�W�F�N�g�̐��F{m_objectPool.CountActive.ToString()}");
        GUILayout.Label($"��A�N�e�B�u�ȃI�u�W�F�N�g�̐��F{m_objectPool.CountInactive.ToString()}");

        if (GUILayout.Button("����"))
        {
            for (int i = 0; i < 2; i++)
            {
                var gameObject = m_objectPool.Get();
            }
        }
        else if (GUILayout.Button("�v�[�����N���A"))
        {
            m_objectPool.Clear();
        }
    }
}
