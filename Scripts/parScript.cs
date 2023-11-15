using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parScript : MonoBehaviour
{
    public int vida = 15;
    public AudioClip irandie;
    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        vida = 15;
    }

    // Update is called once per frame
    public void RecebendoDano(int danoRecebido)
    {
        vida -= danoRecebido;
        if (vida <= 0)
        {
            audioS.clip = irandie;
            audioS.Play();
            Destroy(this.gameObject);
        }
    }

    private void OntriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "arma")
        {
            RecebendoDano(collision.gameObject.transform.parent.GetComponent<JogadorScript>().danoCausado);
        }
    }
}
