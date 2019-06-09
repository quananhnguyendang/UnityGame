using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuongDiChuyen : MonoBehaviour {
    public float tocdo = 0.05f;
    public float doihuong = -1;

    Vector3 dichuyen;

    public Menu menu;

	// Use this for initialization
	void Start () {
       dichuyen = this.transform.position;

        menu = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<Menu>();
	}
	
	// Update is called once per frame
	void Update () {

        if (menu.pause)
        {
            this.transform.position = this.transform.position;
        }

        if(menu.pause == false)
        {
            dichuyen.x += tocdo;
            this.transform.position = dichuyen;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Nen"))
        {
            tocdo *= doihuong;
        }
    }
}
