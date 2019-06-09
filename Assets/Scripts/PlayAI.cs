using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAI : MonoBehaviour {
    public float thoigianbantrihoan = 0;
    public float satthuong = 20;
    public LayerMask Whatohit;
    public Transform diemban;
	// Use this for initialization
	void Start () {
        diemban = transform.Find("DiemTanCong");
	}
	
	// Update is called once per frame
	void Update () {
        thoigianbantrihoan += Time.deltaTime;
        if (thoigianbantrihoan >= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                thoigianbantrihoan = 0;
                shot();
            }
        }
	}
    void shot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 toadodiemban = new Vector2(diemban.position.x, diemban.position.y);

        RaycastHit2D hit = Physics2D.Raycast(toadodiemban,(mousePos-toadodiemban),10,Whatohit);

        Debug.DrawLine(toadodiemban, (mousePos - toadodiemban) * 100,Color.cyan);

        if (hit.collider != null)
        {
            Debug.DrawLine(toadodiemban, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);

            hit.collider.SendMessageUpwards("Damge", satthuong);    
        }
    }
}
