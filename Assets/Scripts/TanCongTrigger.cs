using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanCongTrigger : MonoBehaviour {

    public int satthuong = 20;
    public TruAI truai;
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damge", satthuong);
            //col.SendMessageUpwards("SatThuong", satthuong);
            //truai.Damge(20);
        }

        
    }




    void Start () {
        truai = gameObject.GetComponent<TruAI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
