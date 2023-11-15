using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAVE : MonoBehaviour
{ 
   public AudioClip otcha;
   private AudioSource audioS;
  
    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.clip = otcha;
            audioS.Play();
            FindObjectOfType<GameManager>().possuiChave = true;
            Destroy(this.gameObject);
            Debug.Log("Agora você ganhou mais força");

        }
    }
}