using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;

    public  float ForcaPulo;

    public LayerMask LayerChao;

    public float DistanciaMinimaChao; 

    private bool EstaNoChao;

    private float Pontos;
    
    private float Highscore;

    public float MultiplicadorPontos = 1;

    public Text PontosText;

    public Text HighscoreText;

    public Animator AnimatorComponent;

    public AudioSource PularAudioSource;

    public AudioSource CemPontosAudioSource;

    public AudioSource FimDeJogoAudioSource;

    private void Start() 
    {
        Highscore = PlayerPrefs.GetFloat("HIGHSCORE");
        HighscoreText.text = $"HI {Mathf.FloorToInt(Highscore)}";
    }

    void Update()
    {
        Pontos += Time.deltaTime * MultiplicadorPontos;

        var PontosArredondados = Mathf.FloorToInt(Pontos);
        PontosText.text = PontosArredondados.ToString();

        if (PontosArredondados > 0 
            && PontosArredondados % 100 == 0
            && !CemPontosAudioSource.isPlaying)
        {
            CemPontosAudioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Abaixar();
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Levantar();
        }
    }

    void Pular()
    {
        if (EstaNoChao)
        {
            rb.AddForce(Vector2.up * (ForcaPulo));

            PularAudioSource.Play();
        }
    }

    void Abaixar()
    {
       AnimatorComponent.SetBool("Abaixado", true); 
    }

    void Levantar()
    {
        AnimatorComponent.SetBool("Abaixado", false);
    }

    private void FixedUpdate() 
    {
        EstaNoChao = Physics2D.Raycast(transform.position, Vector2.down, DistanciaMinimaChao, LayerChao);    
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Inimigo")) 
        {
            if (Pontos > Highscore) 
            {
                Highscore = Pontos;

                PlayerPrefs.SetFloat("HIGHSCORE", Highscore);
            }

            FimDeJogoAudioSource.Play();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
