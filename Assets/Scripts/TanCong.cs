using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanCong : MonoBehaviour {
    public float thoigiantrihoan = 0.3f;

    public bool attack = false;

    public Collider2D trigger;

    public Animator anim;

    public SoundMng sound;

    public bool tancong = false;
    // Use this for initialization

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    void Start () {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundMng>();

    }

    // Update is called once per frame
    public void TanCongJoy(bool buttonTanCong)
    {
        tancong = buttonTanCong;
    }
    void Update () {
		if(tancong == true||Input.GetKeyDown(KeyCode.F)&& !attack)
        {
            attack = true;
            trigger.enabled = true;
            thoigiantrihoan = 0.3f;
            sound.Playsound("chem");
        }

        if (attack)
        {
            if (thoigiantrihoan > 0)
            {
                thoigiantrihoan -= Time.deltaTime;
            }
            else
            {
                attack = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("TanCong", attack);
	}
}
