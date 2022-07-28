using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEditor.Presets;

public class Drawing02 : MonoBehaviour
{
    public static Drawing02 instance;
    private void Awake()
    {
        instance = this;
    }

    public Camera cam;
    public GameObject brush;
    public Slider brushSizeSlider;
    public GameObject brush_Basic;
    public GameObject brush_Neon;

    LineRenderer curLine;
    public List<LineRenderer> brushList = new List<LineRenderer>();
    public Transform brushPool;


    private int positionCount = 2;
    private Vector3 PrevPos = Vector3.zero;

    private void Start()
    {
        float curBrushSize = brushSizeSlider.value;
        curBrushSize = 2f;
        brush = brush_Basic;
    }

    internal void BrushNeonChange()
    {
        brush = brush_Neon;
    }
    internal void BrushBasicChange()
    {
        brush = brush_Basic;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0) == false)
        {
            DrawMouse();
        }
    }

    void DrawMouse()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));
        
        //if(Input.mousePosition.y <= -439)
        //{
            
        //    return;
        //}


        if (Input.GetMouseButtonDown(0))
        {
            createLine(mousePos);
        }
        else if (Input.GetMouseButton(0))
        {
            connectLine(mousePos);
        }
    }


    void createLine(Vector3 mousePos)
    {
        GameObject brushInstance = Instantiate(brush);
        curLine = brushInstance.GetComponent<LineRenderer>();
        
        positionCount = 2; //끝점과 시작점

        curLine.transform.parent = cam.transform;
        curLine.transform.position = mousePos;

        float curBrushSize = brushSizeSlider.value;
        //curLine.widthCurve(curLine);

        curLine.transform.SetParent(brushPool);
        brushList.Add(curLine);


        switch (curBrushSize)
        {
            case 0:
                curLine.startWidth = 0.005f;
                curLine.endWidth = 0.005f;
                break;
            case 1:
                curLine.startWidth = 0.01f;
                curLine.endWidth = 0.01f;
                break;
            case 2:
                curLine.startWidth = 0.015f;
                curLine.endWidth = 0.015f;
                break;
            case 3:
                curLine.startWidth = 0.02f;
                curLine.endWidth = 0.02f;
                break;
            case 4:
                curLine.startWidth = 0.025f;
                curLine.endWidth = 0.025f;
                break;
                
        }

        //lineRend.startWidth = 0.01f;
        //lineRend.endWidth = 0.01f;
        //lineRend.numCornerVertices = 5;
        //lineRend.numCapVertices = 5;
        ////lineRend.material = brush;
        curLine.SetPosition(0, mousePos);
        curLine.SetPosition(1, mousePos);

        //curLine = lineRend;
    }

    public void Undo()
    {

        LineRenderer undo = brushList[brushList.Count - 1];
        Destroy(undo.gameObject);
        brushList.RemoveAt(brushList.Count - 1);

    }
    public void ClearScreen()
    {

        foreach (LineRenderer item in brushList)
        {
            Destroy(item.gameObject);
        }
        brushList.Clear();

    }

    void connectLine(Vector3 mousePos)
    {
        if (PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, mousePos)) >= 0.001f)
        {
            PrevPos = mousePos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, mousePos);
        }
    }

    public void Clear()
    {
        //curLine.SetVertexCount(0);
    }

}