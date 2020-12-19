using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCacto : MonoBehaviour
{
    public GameObject CactoPrefab;

    public float DelayInicial;

    public float DelayEntreCactos;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GerarCacto", DelayInicial, DelayEntreCactos);
    }

    // Update is called once per frame
    private void GerarCacto()
    {
        Instantiate(CactoPrefab);     
    }
}
