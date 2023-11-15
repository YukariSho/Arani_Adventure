using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetilInimigo : MonoBehaviour
{
    public int danoCausado;
    // Start is called before the first frame update
    void Start()
    {
        danoCausado = 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<JogadorScript>().tirarVida(danoCausado);
        }
    }


}
