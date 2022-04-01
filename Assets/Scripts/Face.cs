using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class Face : MonoBehaviour
{
    private Mesh mesh;
    private Text infoText;

    private ARFace face;

    // Start is called before the first frame update
    void Start()
    {
        infoText = GameObject.Find("Canvas/Text").GetComponent<Text>();
      //  bonesContainer = GameObject.Find("Bones");
      //  var node = bonesContainer.transform.GetChild(0);
        // for (var i = 0; i < 18; i++)
        // {
        //     var newNode = Instantiate(node, new Vector3(0, 0, 0), Quaternion.identity);
        //     newNode.parent = bonesContainer.transform;
        // }

       mesh = GetComponent<MeshFilter>().mesh;
       face = GetComponent<ARFace>();
    }

    // Update is called once per frame
    void Update()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        if (mesh)
        {
            string rotation = "";
            if (face.transform.rotation.z > 0.1)
            {
                rotation = "right";
            }
            else if (face.transform.rotation.z < -0.1)
            {
                rotation = "left";
            }
            //Trackables_AR  ---- Session Origin
            if (mesh.vertices[14].y <-0.07&& mesh.vertices[14].y<-0.07)
            {
                infoText.text = "is open mouth_" + rotation;
            }
            else
            {
                infoText.text = "null_" + rotation;
            }
        }           
    }
}
