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

    public float MultiplicadorPontos = 1;

    public Text PontosText;

    public Animator AnimatorComponent;

    void Update()
    {
        Pontos += Time.deltaTime * MultiplicadorPontos;

        PontosText.text = "Pontuação: " + Mathf.FloorToInt(Pontos).ToString();

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
