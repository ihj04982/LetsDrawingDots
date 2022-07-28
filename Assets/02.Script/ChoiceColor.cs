using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceColor : MonoBehaviour
{
    public LineRenderer curLine;
    public Material NeonMat;

    [GradientUsage(true, ColorSpace.Linear)]
    public Gradient[] m_FlagColor;

    private void Start()
    {
        curLine = this.GetComponent<LineRenderer>();
        NeonMat = this.GetComponent<Renderer>().material;
    }

    public void ChangeColor01()//버튼1을 누르면 작동하는 함수
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[0];
    }

    public void ChangeColor02()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[1];
    }

    public void ChangeColor03()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[2];
    }

    public void ChangeColor04()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[3];
    }

    public void ChangeColor05()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[4];
    }
    public void ChangeColor06()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[5];
    }
    public void ChangeColor07()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[6];
    }
    public void ChangeColor08()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[7];
    }
    public void ChangeColor09()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[8];
    }
    public void ChangeColor10()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[9];
    }
    public void ChangeColor11()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[10];
    }
    public void ChangeColor12()
    {
        Drawing02.instance.BrushBasicChange();
        curLine.colorGradient = m_FlagColor[11];
    }

    public void ColorPink()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(1f, 0.7607844f, 0.8784314f);
    }
    public void ColorOrange()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(1f, 0.7607844f, 0.8784314f);
    }
    public void ColorYellow()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(1f, 0.9882354f, 0.6941177f);
    }
    public void ColorGreen()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(0.7686275f, 1f, 0.8666667f);
    }
    public void ColorNeonSky()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(0.6745098f, 0.8784314f, 1f);
    }
    public void ColorPurple()
    {
        Drawing02.instance.BrushNeonChange();
        NeonMat.color = new Color(0.8039216f, 0.6745098f, 1f);
    }




}
