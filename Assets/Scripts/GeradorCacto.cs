using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCacto : MonoBehaviour
{
    public GameObject[] CactoPrefabs;

    public float DelayInicial;

    public float DelayEntreCactos;

    private void Start()
    {
        InvokeRepeating("GerarCacto", DelayInicial, DelayEntreCactos);
    }

    private void GerarCacto()
    {
        var QuantidadeCactos = CactoPrefabs.Length;
        var IndiceAleatorio = Random.Range(0, QuantidadeCactos);
        var CactoPrefab = CactoPrefabs[IndiceAleatorio];
        Instantiate(CactoPrefab, transform.position, Quaternion.identity);     
    }
}
