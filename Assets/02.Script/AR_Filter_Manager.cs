using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;



public class AR_Filter_Manager : MonoBehaviour
{
    public GameObject[] filter_prefab;


    ARFaceManager ar_face_mgr;
    ARSessionOrigin session_origin;
    //NativeArray<ARCoreFaceRegionData> faceregion;

    // Start is called before the first frame update
    void Start()
    {
        ar_face_mgr = this.GetComponent<ARFaceManager>();
        session_origin = this.GetComponent<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void applyFilterA()
    {
        ar_face_mgr.facePrefab = filter_prefab[0];
    }
    public void applyFilterC()
    {
        ar_face_mgr.facePrefab = filter_prefab[1];
    }
}
