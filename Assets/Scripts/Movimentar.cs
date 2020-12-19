using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public Vector2 Direcao;

    public float Velocidade;

    private void Update()
    {
        transform.Translate(Direcao * Velocidade * Time.deltaTime);
    }
}
