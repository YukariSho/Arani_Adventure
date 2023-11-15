using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaveJaulaScript : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().chaveJaula = true;
            Destroy(this.gameObject);
            Debug.Log("Ajude Namba");

        }
    }
}