using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] GameObject debris = null; //파편 날아갈 변수
    [SerializeField] float force = 0f;//파편 날라갈 세기
    [SerializeField] Vector3 offset = Vector3.zero;//파편 날라갈 방향
    Transform objPool;
    // Start is called before the first  frame update
    public void Explosion()
    {
        //파편을 내 위치로 생성
        GameObject clone = Instantiate(debris, transform.position, Quaternion.identity);
        clone.transform.SetParent(objPool);
        //파편의 리지드 부르기
        Rigidbody[] rigids = clone.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigids.Length; i++)
        {
            rigids[i].AddExplosionForce(force, transform.position + offset, 10f);
        }//각 파편의 리지드 바디 날림

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
