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
    //생성될 오브젝트 Stock
    public GameObject Stock1;
    public GameObject Stock2;
    public GameObject Stock3;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask PlacedObjectLayerMask;//화면에 배치되는 오브젝트들의 레이어

    public int Stock1Count = 1;
    public int Stock2Count = 1;
    public int Stock3Count = 1;

    private Ray ray;
    private RaycastHit hit;

    List<GameObject> stockList = null;

    [SerializeField]
    private Vector2 touchPosition; //화면 터치 위치

    //상태 만들기
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
                return; //UI 터치가 감지됐을 경우 return
            }
            //화면 터치X, 첫번째 터치 상태 Began이 아니면 실행하지 않는다.
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
                    //리스트에서 랜덤으로 오브젝트 고른다.
                    GameObject obj = stockList[tempInt];
                    //터치 위치에 생성한다.
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
