using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuaQuaMan : MonoBehaviour {

    public int LevelLoad = 1;
    public GameMaster gm;


	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            LuuDiem();
            gm.input.text = "Nhấn P để qua màn";
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.P))
            {
                LuuDiem();
                SceneManager.LoadScene(LevelLoad);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            gm.input.text = "";
        }
    }

    void LuuDiem()
    {
        PlayerPrefs.SetInt("diem", gm.diem);
    }
}
