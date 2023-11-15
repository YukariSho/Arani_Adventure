using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public int danoCausado = 15;
    public float tempoDarDano = 0f;
    public float tempoPassado = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //tempoPassado = tempoDarDano + 1;
            tempoPassado = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tempoPassado += Time.deltaTime;

            if (tempoPassado > tempoDarDano)
            {
                collision.gameObject.GetComponent<JogadorScript>().tirarVida(danoCausado);
                tempoPassado = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }


}
