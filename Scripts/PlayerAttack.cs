using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float intervaloDeAtaque;
    private float proximoAtaque;
    
    public AudioClip swish;
    private AudioSource audioS;
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        {
            Atacando();
        }

    }

    void Atacando()
    {
        audioS.clip = swish;
        audioS.Play();
        anim.SetTrigger("Attack1");
        proximoAtaque = Time.time + intervaloDeAtaque;
    }

}
