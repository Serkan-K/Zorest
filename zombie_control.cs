using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class zombie : MonoBehaviour
{
    private GameObject oyuncu;
    private int zombieCan = 5;
    private float mesafe;
    public GameObject kalp;
    private oyunKontrol oKontrol;
    private int ZombiePuan = 100;
    private AudioSource aSource;
    private bool zombieoldu = false;

    void Start()
    {
        oyuncu = GameObject.Find("Oyuncu");
        oKontrol = GameObject.Find("_Scripts").GetComponent<oyunKontrol>();
        aSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if (!aSource.isPlaying)
            aSource.Play();

            if (!zombieoldu)
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
            
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();

        }
    }


    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("öl");
            zombieCan--;
            if (zombieCan ==0)
            {
                zombieoldu = true;
                oKontrol.Puanarttir(ZombiePuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);

            }
        }
    }
}
