using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class AR_Camera_Change : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 카메라 전환하는 함수 생성 
    public void OnSwapCameraButtonPress()
    {
        // AR Camera Manager 불러와서 
        ARCameraManager m_CameraManager = this.GetComponent<ARCameraManager>();

        switch (m_CameraManager.requestedFacingDirection)
        {
            // World 카메라인 case 
            case CameraFacingDirection.World:
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.User;
                print("self로 카메라전환");
                break;
            // User 카메라인 case 
            case CameraFacingDirection.User:
            default:
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.World;
                print("world로 카메라전환");
                break;
        }
    }
}
