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

    void Update()
    {
        Pontos += Time.deltaTime * MultiplicadorPontos;

        PontosText.text = "Pontos: " + Mathf.FloorToInt(Pontos).ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
    }

    void Pular()
    {
        if (EstaNoChao)
        {
            rb.AddForce(Vector2.up * (ForcaPulo));
        }
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
