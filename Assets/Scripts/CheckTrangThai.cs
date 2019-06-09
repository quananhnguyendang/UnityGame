using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrangThai : MonoBehaviour {

    public DiChuyen dichuyen;

    public TuongDiChuyen tuongdichuyen;

    public Vector3 tdc;

    // Use this for initialization
    void Start() {
        dichuyen = gameObject.GetComponentInParent<DiChuyen>();
        tuongdichuyen = GameObject.FindGameObjectWithTag("TuongDiChuyen").GetComponent<TuongDiChuyen>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate()
    {

    }
    //Box collider có trigger nếu có va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            dichuyen.trangthai = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("Nuoc"))
        {
            dichuyen.trangthai = true;
        }

        if(collision.isTrigger == false && collision.CompareTag("TuongDiChuyen"))
        {
            tdc = dichuyen.transform.position;
            tdc.x += tuongdichuyen.tocdo*1.12f;
            dichuyen.transform.position = tdc;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("Nuoc"))
        {
            dichuyen.trangthai = false;
        }
    }
}
