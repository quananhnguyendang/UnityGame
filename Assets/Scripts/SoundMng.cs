using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour {
    public AudioClip coins, swords, destroy;

    public AudioSource adisrc;
	// Use this for initialization
	void Start () {

        coins = Resources.Load<AudioClip>("antien");
        swords = Resources.Load<AudioClip>("chem");
        destroy = Resources.Load<AudioClip>("phahuy");

        adisrc = GetComponent<AudioSource>();
	}
	
	public void Playsound(string clip)
    {
        switch (clip)
        {
            case "antien":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 1f);
                break;
            case "chem":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 1f);
                break;
            case "phahuy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;
        }
    }
}
