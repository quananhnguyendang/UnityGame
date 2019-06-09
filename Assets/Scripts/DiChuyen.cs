using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiChuyen : MonoBehaviour {
    public float tocdo = 50f;
    public float tocdomax = 3;
    public float lucnhay = 220f;
    public float lucnhaylonnhat = 4;

    public bool trangthai = true;
    public bool trangthai2 = true;

    public bool nhayhailan = false;

    public Rigidbody2D rigid;

    public Animator anim;

    public GameMaster gm;

    public SoundMng sound;



    public int luongmauhientai;
    public int luongmautoida=5;

    public float h=0;

    public bool jump=false;

	// Use this for initialization
	void Start () {


        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        luongmauhientai = luongmautoida;

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMng>();


        
        
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("TrangThai", trangthai);
        anim.SetFloat("TocDo", Mathf.Abs(rigid.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space) ||jump == true)
        {
            if (trangthai)
            {
                nhayhailan = true;
                trangthai = false;
                rigid.AddForce(Vector2.up * lucnhay);
            }
            else
            {
                if (nhayhailan)
                {
                    nhayhailan = false;
                    rigid.velocity = new Vector2(rigid.velocity.x, 0);
                    rigid.AddForce(Vector2.up * lucnhay * 0.8f);
                    //StartCoroutine(Djump());
                }
            }
        }
		
	}
    public void MoveButton(float buttonInput)
    {
        h = buttonInput;
    }

     void FixedUpdate()
    {
        //MoveButton(h);
         h = Input.GetAxis("Horizontal");
        rigid.AddForce((Vector2.right) * tocdo * h);
        
        if (rigid.velocity.x > tocdomax)
        {
            rigid.velocity = new Vector2(tocdomax, rigid.velocity.y);
        }

        if(rigid.velocity.x < -tocdomax)
        {
            rigid.velocity = new Vector2(-tocdomax, rigid.velocity.y);
        }


        if (rigid.velocity.y > lucnhaylonnhat)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, lucnhaylonnhat);
        }

        if (rigid.velocity.y < -lucnhaylonnhat)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -lucnhaylonnhat);
        }

        if (h > 0 && !trangthai2)
        {
            DoiHuong();
        }

        if (h < 0 && trangthai2)
        {
            DoiHuong();
        }

        //MaSat
        if (trangthai)
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 0.7f, rigid.velocity.y);
        }

        if (luongmauhientai <= 0)
        {
            HetMau();
        }
    }

    void DoiHuong()
    {
        Vector3 doihuong;
        trangthai2 = !trangthai2;
        doihuong = transform.localScale;
        doihuong.x *= -1;
        transform.localScale = doihuong;
    }

    void HetMau()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (PlayerPrefs.GetInt("diemcao") < gm.diem)
        {
            PlayerPrefs.SetInt("diemcao", gm.diem);
        }

    }

    public void VaCham(int satthuong)
    {
        luongmauhientai -= satthuong;
        //tuongduong
        //luongmauhientai = luongmauhientai - satthuong;

        gameObject.GetComponent<Animation>().Play("CanhBao");

        
    }

    public void DayLuiKhiVaCham(float lucday, Vector2 daylui)
    {
        rigid.velocity = new Vector2(0, 0);
        rigid.AddForce(new Vector2(daylui.x * -100, daylui.y + lucday));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Tien"))
        {
            sound.Playsound("antien");
            Destroy(col.gameObject);
            gm.diem += 3;
        }
        if (col.CompareTag("Giay"))
        {
            Destroy(col.gameObject);
            tocdomax = 4;
            tocdo = 60f;
            StartCoroutine(demnguoc(2));
        }
        if (col.CompareTag("Mau"))
        {           
            Destroy(col.gameObject);
            luongmauhientai += 1;
            
        }
    }

    IEnumerator demnguoc(float thoigiandemnguoc)
    {
        yield return new WaitForSeconds(thoigiandemnguoc);
        tocdomax = 3f;
        tocdo = 50f;
        yield return 0;
    }
    public IEnumerator Djump()
    {
        yield return new WaitForSeconds(0.4f);
        if (nhayhailan && jump == true)
        {
            nhayhailan = false;
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * lucnhay * 0.8f);
        }
        
    }
    public void jumpJoy(bool jumpj)
    {
        jump = jumpj;
    }
}

