using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour {
    public int diem = 0;
    public int diemcao = 0;

    public Text DiemText;
    public Text Diemcao;
    public Text input;
	// Use this for initialization
	void Start () {

        Diemcao.text = ("Điểm Cao: " + PlayerPrefs.GetInt("diemcao"));
        diemcao = PlayerPrefs.GetInt("diemcao", 0);

        if (PlayerPrefs.HasKey("diem"))
        {
            Scene sce = SceneManager.GetActiveScene();
            if (sce.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("diem");
                diem = 0;
            }

            else
            {
                diem = PlayerPrefs.GetInt("diem");
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        DiemText.text = ("Điểm: " + diem);
	}
}
