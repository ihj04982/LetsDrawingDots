using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;


public class AR_Face_Manager : MonoBehaviour
{
    public GameObject filterB_prefabLeft;
    public GameObject filterB_prefabRight;


    GameObject filterB_Left;
    GameObject filterB_Right;


    ARFaceManager ar_face_mgr;
    ARSessionOrigin session_origin;


    NativeArray<ARCoreFaceRegionData> faceregion; // ���� ��ġ �� �����͸� ������ �迭

    // Start is called before the first frame update
    void Start()
    {
        ar_face_mgr = this.GetComponent<ARFaceManager>();
        session_origin = this.GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        // �� ������ ��... ������ ������ ���� sub system 
        ARCoreFaceSubsystem subsystem = (ARCoreFaceSubsystem)ar_face_mgr.subsystem; // ARCore ����� ���� ������ ��´�
        // �� �ν��� �Ǿ����� 
        foreach (ARFace face in ar_face_mgr.trackables)
        {
            // �󱼳� Ư�� ��ġ�������� ��´�
            subsystem.GetRegionPoses(face.trackableId, Unity.Collections.Allocator.Persistent, ref faceregion);

            foreach (ARCoreFaceRegionData face_rg in faceregion)
            {
                ARCoreFaceRegion region_type = face_rg.region; // Ư�� ���� �� ��� ��ü���� 

                if (region_type == ARCoreFaceRegion.ForeheadLeft) // ���� ���̸� 
                {
                    if (filterB_Left == null)
                    {
                        filterB_Left = Instantiate(filterB_prefabLeft, session_origin.trackablesParent);
                    }
                    filterB_Left.transform.position = face_rg.pose.position;
                    filterB_Left.transform.rotation = face_rg.pose.rotation; 
                }
                if (region_type == ARCoreFaceRegion.ForeheadRight) // ���� ���̸� 
                {
                    if (filterB_Right == null)
                    {
                        filterB_Right = Instantiate(filterB_prefabRight, session_origin.trackablesParent);
                    }
                    filterB_Right.transform.position = face_rg.pose.position;
                    filterB_Right.transform.rotation = face_rg.pose.rotation;
                }
            }
        }


    }
}
