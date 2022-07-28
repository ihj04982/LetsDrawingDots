using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] GameObject debris = null; //���� ���ư� ����
    [SerializeField] float force = 0f;//���� ���� ����
    [SerializeField] Vector3 offset = Vector3.zero;//���� ���� ����
    Transform objPool;
    // Start is called before the first  frame update
    public void Explosion()
    {
        //������ �� ��ġ�� ����
        GameObject clone = Instantiate(debris, transform.position, Quaternion.identity);
        clone.transform.SetParent(objPool);
        //������ ������ �θ���
        Rigidbody[] rigids = clone.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigids.Length; i++)
        {
            rigids[i].AddExplosionForce(force, transform.position + offset, 10f);
        }//�� ������ ������ �ٵ� ����

        gameObject.SetActive(false);

    }

    void Start()
    {
        objPool = GameObject.Find("ObjectPool").transform;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
