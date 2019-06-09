using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
    public int Mau = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Mau <= 0)
        {
            Destroy(gameObject);
        }
	}

    void Damge(int satthuong)
    {
        Mau -= satthuong;
    }
}
