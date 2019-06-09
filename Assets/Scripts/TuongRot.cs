using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuongRot : MonoBehaviour {
    public Rigidbody2D rigid;
    public float thoigiantrihoan = 1 ;
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(rot());
        }
    }

    IEnumerator rot()
    {
        yield return new WaitForSeconds(thoigiantrihoan);
        rigid.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
