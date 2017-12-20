using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformer : MonoBehaviour {

    MeshFilter mf;
    MeshCollider mc;
    Vector3[] vertices;
    Color[] colors; 

	// Use this for initialization
	void Start ()
    {
        mf = GetComponent<MeshFilter>();
        mc = GetComponent<MeshCollider>();
        vertices = mf.mesh.vertices;

        colors = new Color[vertices.Length];

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = Mathf.Sin(vertices[i].x + Time.time);

           // colors[i] = Color.white = (vertices[i].y + 0.5f);

        }
        mf.mesh.vertices = vertices;
        mf.mesh.colors = colors;
	}
}
