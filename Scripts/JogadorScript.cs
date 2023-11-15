using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorScript : MonoBehaviour
{
    //Criação da variável
    public int vida = 100;
    public int pontuacao = 0;

    public Rigidbody2D rb2D;
    public float velocidade = 5;
    bool estaNoChao = false;

    public Animator anim;
    public float tempoDarDano = 5f;
    public float tempoPassado = 0;
    float valorHorizontal;
    public AudioClip a;
    private AudioSource audioS;
    public int danoCausado = 5;

    public float forcaHorizontal = 5;
    public float forcaVertical = 5;
    public float tempoDeDestruicao = 1;

    float forcaHorizontalPadrao;
    // Use this for initialization

    bool viradoDireita = true;

    public int VidaJogador
    {
        get => vida;
        set
        {
            if (value < vida)
            {
                int aux = VidaJogador - value;
                if (aux <= 0)
                {
                    anim.SetBool("Death", true);
                }
            }
        }
    }

    private void Awake()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Start() //acontece quando o jogo inicia/quando o objeto é criado
    {
        audioS = gameObject.GetComponent<AudioSource>();
        forcaHorizontalPadrao = forcaHorizontal;
    }

    void Update() //é chamado uma vez por frame
    {
        //Movimentacao

        valorHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao == true)
        {
            anim.SetBool("jum", true);
            rb2D.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("jum", false);
        }

        if ((valorHorizontal > 0 && viradoDireita == false) || (valorHorizontal < 0 && viradoDireita == true))
        {
            Flip();
        }
        //Animacao
        if (valorHorizontal != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        /*        
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.Translate(mov * Time.deltaTime);
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Irant"))
        {
            other.gameObject.GetComponent<fire>().enabled = false;

            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            if (other.transform.position.x < transform.position.x)
                forcaHorizontal *= -1;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);


            forcaHorizontal = forcaHorizontalPadrao;
        }
    }

    private void FixedUpdate()
    {
        //rb2D.velocity = new Vector2(valorHorizontal * velocidade, valorVertical * velocidade);
        rb2D.velocity = new Vector2(valorHorizontal * velocidade, rb2D.velocity.y);
    }

    public void tirarVida(int dano)
    {
        vida -= dano;
        audioS.clip = a;
        audioS.Play();

        if (vida <= 0) //jogador morreu
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cenario"))
        {
            estaNoChao = true;
        }

        if (collision.gameObject.CompareTag("Armadilha"))
        {
            //tempoPassado = tempoDarDano + 1;
            tempoPassado = 0f;
            vida = -1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.name == "Plataforma")
        {
            this.transform.parent = collision.gameObject.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cenario"))
        {
            estaNoChao = false;
        }

        if (collision.gameObject.name == "buraco")
        {
            SceneManager.LoadScene("Fase01");
        }
        if (collision.gameObject.name == "Plataforma")
        {
            this.transform.parent = null;
        }
    }


    private void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1; // + - = - | - - = +
        transform.localScale = escala;
    }

}
