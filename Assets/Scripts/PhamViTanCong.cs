using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhamViTanCong : MonoBehaviour {
    public TruAI tru;

    public bool kiemtratrai = false;
    // Use this for initialization
    private void Awake()
    {
        tru = gameObject.GetComponentInParent<TruAI>();
        
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (kiemtratrai)
            {
                tru.TruTanCong(false);
            }
            else
            {
                tru.TruTanCong(true);
            }
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
