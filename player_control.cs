using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncukontrol : MonoBehaviour
{
    public AudioClip atisSesi, olmeSesi, canSesi, yaralanmaSes;
    public Transform mermipos;
    public GameObject mermi;
    public GameObject patlama;
    public Image Canbar;
    private float CanDeger = 100f;
    public oyunKontrol oKontrol;
    private AudioSource atSource;


    
    void Start()
    {
        atSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            atSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate(mermi, mermipos.position, mermipos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermipos.position, mermipos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermipos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("zombi"))
        {
            atSource.PlayOneShot(yaralanmaSes, 1f);
            Debug.Log("öldün");
            CanDeger -= 10f;
            float x = CanDeger / 100f;
            Canbar.fillAmount = x;
            Canbar.color = Color.Lerp(Color.red, Color.green, x);

            if (CanDeger <= 0)
            {
                atSource.PlayOneShot(olmeSesi, 1f);
                oKontrol.OyunBitti();
            }
            
        }
    }


    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag.Equals("kalp"))
        {
            atSource.PlayOneShot(canSesi, 1f);
            CanDeger += 25f;
            float x = CanDeger / 100f;
            Canbar.fillAmount = x;
            Canbar.color = Color.Lerp(Color.red, Color.green, x);

        }

    }
}
