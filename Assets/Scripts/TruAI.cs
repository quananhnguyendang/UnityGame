using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruAI : MonoBehaviour {

    public int mautru = 80;
    public float phamvi;
    public float phamvutruchuyendong;
    public float chuky;
    public float tocdodan = 5;
    public float thoigianban;

    public bool trangthai = false;
    public bool huongphai = true;

    public GameObject dan;
    public Transform target;
    public Animator anim;
    public Transform vitribantrai, vitribanphai;

    public SoundMng sound;

    // Use this for initialization

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start () {

        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMng>();

    }

    // Update is called once per frame
    void Update () {

        KiemTraPhamViChuyenDong();
        anim.SetBool("TrangThai", trangthai);
        anim.SetBool("HuongPhai", huongphai);

        if (target.transform.position.x > transform.position.x)
        {
            huongphai = true;
        }

        if (target.transform.position.x < transform.position.x)
        {
            huongphai = false;
        }

        if (mautru <= 0)
        {
            sound.Playsound("phahuy");
            Destroy(gameObject);
        }


    }

    void KiemTraPhamViChuyenDong()
    {
        phamvi = Vector2.Distance(transform.position, target.transform.position);

        if (phamvi < phamvutruchuyendong)
        {
            trangthai = true;
        }
        if (phamvi > phamvutruchuyendong)
        {
            trangthai = false;
        }
    }

    public void TruTanCong(bool tancongphai)
    {
        thoigianban += Time.deltaTime;

        if(thoigianban >= chuky)
        {
            Vector2 huongdan = target.transform.position - transform.position;

            huongdan.Normalize();

            if (tancongphai)
            {
                GameObject DanClone;
                DanClone = Instantiate(dan, vitribanphai.transform.position, vitribanphai.transform.rotation) as GameObject;
                DanClone.GetComponent<Rigidbody2D>().velocity = huongdan * tocdodan;

                thoigianban = 0;
            }

            if (!tancongphai)
            {
                GameObject DanClone;
                DanClone = Instantiate(dan, vitribantrai.transform.position, vitribantrai.transform.rotation) as GameObject;
                DanClone.GetComponent<Rigidbody2D>().velocity = huongdan * tocdodan;

                thoigianban = 0;
            }
        }

    }

    public void Damge(int satthuong)
    {
        mautru -= satthuong;
        gameObject.GetComponent<Animation>().Play("TruCanhBao");
    }
}
