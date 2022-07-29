using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjControl : MonoBehaviour
{
    
    [SerializeField]
    private GameObject Selected;
    // Start is called before the first frame update
    public bool IsSelected
    {
        get => SelectedObj == this;
    }

    private static ObjControl selectedObj;
    public static ObjControl SelectedObj
    {
        get => selectedObj;
        set
        {
            //이미 선택된 오브젝트를 선택했을 때는 종료
            if (selectedObj == value)
            {
                return;
            }
            //기존에 선택된 오브젝트가 있을 때
            //해당 오브젝트의 selected 비활성화
            if (selectedObj != null)
            {
                selectedObj.Selected.SetActive(false);
            }
            //selectedobj의 value를 저장하고.
            selectedObj = value;

            //현재 선택된 오브젝트의 selected 옵젝 활성화
            if (value != null)
            {
                value.Selected.SetActive(true);
                if (Input.touchCount > 0)
                {
                    Touch temptouch = Input.GetTouch(0);

                    if (temptouch.tapCount >= 3)
                    {
                        value.transform.GetComponent<Break>().Explosion();
                    }
                }
            }
        }
    }
    private void Awake()
    {
        Selected.SetActive(false);
    }

    //드래그할 때 호출되는 메소드
    public void OnPointerDrag(BaseEventData bed)
    {
        //터치 후 드레그하는 위치로 현재 선택된 오브젝트 이동
        if (IsSelected)
        {
            PointerEventData ped = (PointerEventData)bed;
            if (ObjectCreate.Raycast(ped.position, out Pose hitPose))
            {
                transform.position = hitPose.position;
            }
        }
    }
}
