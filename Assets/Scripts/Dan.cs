using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dan : MonoBehaviour {
    //public DiChuyen dichuyen;

    public float thoigiandantontai = 2;
	// Use this for initialization
	void Start () {
        //dichuyen = GameObject.FindGameObjectWithTag("Player").GetComponent<DiChuyen>();
	}
	
	// Update is called once per frame
	void Update () {
        thoigiandantontai -= Time.deltaTime;
        if(thoigiandantontai <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("VaCham", 1);
            }
            Destroy(gameObject);
        }


    }
}
