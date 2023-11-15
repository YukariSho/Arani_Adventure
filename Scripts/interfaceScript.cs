using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interfaceScript : MonoBehaviour
{
    public JogadorScript refJogador;
    Slider barraDeVida;

    private void Awake()
    {
        refJogador = GameObject.Find("Jogador").GetComponent<JogadorScript>();
        barraDeVida = this.transform.GetChild(1).gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        barraDeVida.maxValue = refJogador.VidaJogador;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.value = refJogador.VidaJogador;
    }
}
