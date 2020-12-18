using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;

    public  float ForcaPulo;

    public LayerMask LayerChao;

    public float DistanciaMinimaChao = 1; 

    private bool EstaNoChao; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
