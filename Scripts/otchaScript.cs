using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otchaScript : MonoBehaviour
{
    public AudioClip rock;
    private AudioSource audioS;
    // Start is called before the first frame update
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
            audioS.clip = rock;
            audioS.Play();
            if (FindObjectOfType<GameManager>().possuiChave == true)
            {
                Destroy(this.gameObject);
            }
            else
            {

                Debug.Log("Você precisa de mais força para conseguir arrastar!");
            }
        }
    }
}
