using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MauUI : MonoBehaviour {

    public Sprite[] luongmau;

    public DiChuyen dichuyen;

    public Image Mau;
	// Use this for initialization
	void Start () {
        dichuyen = GameObject.FindGameObjectWithTag("Player").GetComponent<DiChuyen>();
	}
	
	// Update is called once per frame
	void Update () {
        Mau.sprite = luongmau[dichuyen.luongmauhientai];
	}
}
