using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour {


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                Invoke("KhoiPhuc", 0.5f);
            }
        }
    }


    void KhoiPhuc()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    
}
