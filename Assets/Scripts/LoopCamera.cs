using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopCamera : MonoBehaviour {
    public DiChuyen dichuyen;
	// Use this for initialization
	void Start () {
        dichuyen = GameObject.FindGameObjectWithTag("Player").GetComponent<DiChuyen>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        offset.x = dichuyen.transform.position.x;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset*Time.deltaTime/0.4f;
    }
}
