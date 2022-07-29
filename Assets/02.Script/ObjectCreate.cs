using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectCreate : MonoBehaviour
{
    private static ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    static ObjectCreate()
    {
        raycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
    }

    public static bool Raycast(Vector2 screenPosition,out Pose pose)
    {
        if(raycastManager.Raycast(screenPosition, hits, TrackableType.All))
        {
            pose = hits[0].pose;
            return true;
        }
        else
        {
            pose = Pose.identity;
            return true;
        }
    }
    public static bool TryGetInputPosition(out Vector2 position)
    {
        position = Vector2.zero;
        //��ġ ���ϸ� false��ȯ
        if(Input.touchCount == 0)
        {
            return false;
        }
        //ù ��ġ�� ��ġ���� �����ǿ� ����
        position = Input.GetTouch(0).position;
        //ù��° ��ġ ���°� Began�� �ƴϸ� false ��ȯ
        if(Input.GetTouch(0).phase != TouchPhase.Began)
        {
            return false;
        }
        return true;
    }
}
