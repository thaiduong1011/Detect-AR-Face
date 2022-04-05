using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ExpressionManager : MonoBehaviour
{
    public ExpressionConfiguration[] ExpresionConfigurations;
    private MeshFilter faceMeshFilter;

    [SerializeField]
    private Text infoText;
    private ARFace face;

    void Update()
    {
        Init();
        DetectExpressions();
    }

    void CreateDebugOverlays(string text)
    {
        infoText.text = text;
    }

    void DetectExpressions()
    {
        if (faceMeshFilter == null || faceMeshFilter.mesh.vertexCount == 0) return;


        foreach (var expression in  ExpresionConfigurations)
        {
            var count = 0;
            string text = "";
            foreach (var range in  expression.BlendShapeRanges)
            {
                var point = faceMeshFilter.mesh.vertices[range.point];
                if (point.x <= range.UpperBound.x && point.x >= range.LowBound.x 
                && point.y <= range.UpperBound.y && point.y >= range.LowBound.y 
                && point.z <= range.UpperBound.z && point.z >= range.LowBound.z)
                {
                    count++;
                }
            }

            if (count == expression.BlendShapeRanges.Length)
            {
                CreateDebugOverlays("OpenMouth_" + text);

            }
            else
            {
                CreateDebugOverlays("null_" + text);

            }
        }
    }

    void Init()
    {
        if (face == null)
        {
            var meshFilterTranform = GameObject.Find("AR Session Origin/Trackables");
            if (meshFilterTranform)
            {
                face = meshFilterTranform.GetComponentInChildren<ARFace>();
                faceMeshFilter = meshFilterTranform.GetComponentInChildren<MeshFilter>();
            }
        }
    }

}
