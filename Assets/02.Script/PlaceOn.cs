using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlaceOn : MonoBehaviour
{
    public static PlaceOn instance;
    private void Awake()
    {
        instance = this;
    }
    //������ ������Ʈ Stock
    public GameObject Stock1;
    public GameObject Stock2;
    public GameObject Stock3;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask PlacedObjectLayerMask;//ȭ�鿡 ��ġ�Ǵ� ������Ʈ���� ���̾�

    public int Stock1Count = 1;
    public int Stock2Count = 1;
    public int Stock3Count = 1;

    private Ray ray;
    private RaycastHit hit;

    List<GameObject> stockList = null;

    [SerializeField]
    private Vector2 touchPosition; //ȭ�� ��ġ ��ġ

    //���� �����
    int tempInt = 0;
    bool rand = false;
    bool start;
    
    public Transform objPool;

    void Start()
    {
        stockList = new List<GameObject>();
        for (int i = 0; i < Stock1Count; i++)
        {
            stockList.Add(Stock1);
        }
        for (int i = 0; i < Stock2Count; i++)
        {
            stockList.Add(Stock2);
        }
        for (int i = 0; i < Stock3Count; i++)
        {
            stockList.Add(Stock3);
        }

        start = false;
        rand = true;

    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.currentSelectedGameObject == true)
            {
                return; //UI ��ġ�� �������� ��� return
            }
            //ȭ�� ��ġX, ù��° ��ġ ���� Began�� �ƴϸ� �������� �ʴ´�.
            if (!ObjectCreate.TryGetInputPosition(out touchPosition))
            {
                return;
            }
            ray = arCamera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, PlacedObjectLayerMask))
            {
                ObjControl.SelectedObj = hit.transform.GetComponentInChildren<ObjControl>();
                return;
            }
            ObjControl.SelectedObj = null;
            if (start == true)
            {
                if (ObjectCreate.Raycast(touchPosition, out Pose hitPose))
                {
                    if (rand == true)
                    {
                        tempInt = Random.Range(0, stockList.Count);
                    }
                    //����Ʈ���� �������� ������Ʈ ����.
                    GameObject obj = stockList[tempInt];
                    //��ġ ��ġ�� �����Ѵ�.
                    GameObject temp = Instantiate(obj, hitPose.position, hitPose.rotation);
                    temp.transform.SetParent(objPool);
                }
            }
        }
    }

    public void RandomCreate()
    {
        start = true;
        rand = true;
    }
    public void OnCake1()
    {
        start = true;
        rand = false;
        tempInt = 0;
    }
    public void OnCake2()
    {
        start = true;
        rand = false;
        tempInt = 1;
    }
    public void OnHeart()
    {
        start = true;
        rand = false;
        tempInt = 2;
    }

    public void ClearScreen()
    {
        foreach (Transform child in objPool.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
