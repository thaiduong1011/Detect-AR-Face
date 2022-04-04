using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BlendShapeRange {
    public int point = 0;
    public Vector3 LowBound;
    public Vector3 UpperBound;
    public ActionExecutor Action;
}

[Serializable]
public class ActionExecutor 
{
    public string MethodName;
    public float Delay;
}