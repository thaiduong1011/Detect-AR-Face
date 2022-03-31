using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ExpressionManager : MonoBehaviour
{
    public ExpressionConfiguration[] ExpresionConfigurations;

    public string FORMAT_DEBUG_TEXT = "({0}){1}(min={2} max={3}) -> val={4}";

    private Dictionary<string, float> currentBlendShapes;
    private Dictionary<string, Text> currentBlendShapeUIs;

    public float delayFor = 1.0f;
    private float delayTimer = 0;

    [SerializeField]
    private MeshFilter meshFilter;
    private Mesh faceMesh;

    [SerializeField]
    private GameObject faceParent;
    private ARFace face;
    private ARAnchor anchor;
    [SerializeField]
    private Text infoText;

    [SerializeField]
    private ARCameraManager cameraManager;
    [SerializeField]
    private ARFaceManager faceManager;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(delayTimer >= delayFor){
            DetectExpressions();
            delayTimer = 0;
        }
        else {
            delayTimer += Time.deltaTime * 1.0f;
        }
    }

    void CleanUp()
    {
        foreach (var configuration in ExpresionConfigurations)
        {
            foreach (var range in configuration.BlendShapeRanges)
            {
                range.DetectionCount = 0;
            }
        }
    }

    void CreateDebugOverlays(string text)
    {
        infoText.text = text;
    }

    void DetectExpressions()
    {
        face = faceParent.GetComponentInChildren<ARFace>();
        if (face == null)
        {
            face = GameObject.Find("AR Default Face")?.GetComponent<ARFace>();
        }

        string text = cameraManager.currentFacingDirection.ToString();
        text += "__" + faceManager.currentMaximumFaceCount;
        if (face)
        {
            CreateDebugOverlays(text +"__"+ face.fixationPoint.ToString());

        }
        else
        {
            CreateDebugOverlays(text + "__ null");
        }
    }

}
