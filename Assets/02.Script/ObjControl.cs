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
            //�̹� ���õ� ������Ʈ�� �������� ���� ����
            if (selectedObj == value)
            {
                return;
            }
            //������ ���õ� ������Ʈ�� ���� ��
            //�ش� ������Ʈ�� selected ��Ȱ��ȭ
            if (selectedObj != null)
            {
                selectedObj.Selected.SetActive(false);
            }
            //selectedobj�� value�� �����ϰ�.
            selectedObj = value;

            //���� ���õ� ������Ʈ�� selected ���� Ȱ��ȭ
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

    //�巡���� �� ȣ��Ǵ� �޼ҵ�
    public void OnPointerDrag(BaseEventData bed)
    {
        //��ġ �� �巹���ϴ� ��ġ�� ���� ���õ� ������Ʈ �̵�
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
