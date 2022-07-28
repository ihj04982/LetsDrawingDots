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

    // ī�޶� ��ȯ�ϴ� �Լ� ���� 
    public void OnSwapCameraButtonPress()
    {
        // AR Camera Manager �ҷ��ͼ� 
        ARCameraManager m_CameraManager = this.GetComponent<ARCameraManager>();

        switch (m_CameraManager.requestedFacingDirection)
        {
            // World ī�޶��� case 
            case CameraFacingDirection.World:
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.User;
                print("self�� ī�޶���ȯ");
                break;
            // User ī�޶��� case 
            case CameraFacingDirection.User:
            default:
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.World;
                print("world�� ī�޶���ȯ");
                break;
        }
    }
}
