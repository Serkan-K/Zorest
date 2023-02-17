using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunKontrol : MonoBehaviour
{
    public GameObject zombie;
    private float zamanSayaci;
    private float olusumSuresi = 10f;
    public Text scoreText;
    private int score;


    void Start()
    {
        
    }

    
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(185f, 300f), 31f, Random.Range(200f, 307f));
            Instantiate(zombie, pos, Quaternion.identity);
            zamanSayaci = olusumSuresi;
        }
    }

    public void Puanarttir(int p)
    {
        score += p;
        scoreText.text = "" + score;

    }


    public void OyunBitti()
    {
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("GameOver");

    }

}
