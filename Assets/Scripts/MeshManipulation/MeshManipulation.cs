using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshManipulation : MonoBehaviour
{

    Mesh deformingMesh;
    Vector3[] originalVertices, displacedVertices;

    // Start is called before the first frame update
    void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
        originalVertices[0] = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
