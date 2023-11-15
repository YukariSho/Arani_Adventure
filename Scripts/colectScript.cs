using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colectScript : MonoBehaviour
{
    public Text scoreTxt;
    private int score;
    public AudioClip ori;
    private AudioSource audioS;

    private void Start()
    {
        score = 0;
        audioS = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        scoreTxt.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coletaveis") == true)
        {
            audioS.clip = ori;
            audioS.Play();
            score = score + 1;
            Destroy(col.gameObject);
        }
    }
}
