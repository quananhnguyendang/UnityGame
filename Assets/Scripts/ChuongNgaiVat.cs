using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuongNgaiVat : MonoBehaviour {
    public DiChuyen dichuyen;

    public int satthuong = 1;
	// Use this for initialization
	void Start () {
        dichuyen = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<DiChuyen>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dichuyen.VaCham(satthuong);
            dichuyen.DayLuiKhiVaCham(150f, dichuyen.transform.position);
        }
    }


    
}
