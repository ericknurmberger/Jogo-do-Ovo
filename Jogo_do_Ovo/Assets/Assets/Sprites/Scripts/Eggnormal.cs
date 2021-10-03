using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggnormal : MonoBehaviour {

    private GameObject Jogador;

    private float UltimaPosicaoEmY;
    private float DistanciaDeQueda;

    public float DistanciaMaximaDeQueda = 4;

    private float VidaDoPersonagem;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        VidaDoPersonagem = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (UltimaPosicaoEmY > Jogador.transform.position.y /*&& controlador.velocity.y < 0*/)
        {
            DistanciaDeQueda += UltimaPosicaoEmY - Jogador.transform.position.y;
        }
        UltimaPosicaoEmY = Jogador.transform.position.y;
        if (DistanciaDeQueda >= DistanciaMaximaDeQueda /*&& gameObject.isGrounded*/)
        {
            VidaDoPersonagem = 0;
            ZerarVariaveis();
        }
        if (DistanciaDeQueda < DistanciaMaximaDeQueda /*&& controlador.isGrounded*/)
        {
            ZerarVariaveis();
        }
        if (VidaDoPersonagem >= 1)
        {
            VidaDoPersonagem = 1;
        }
        else if (VidaDoPersonagem <= 0)
        {
            VidaDoPersonagem = 0;
            CrackEgg();
        }
    }

    void ZerarVariaveis()
    {
        DistanciaDeQueda = 0;
        UltimaPosicaoEmY = 0;
    }

    void CrackEgg()
    {
        Destroy(gameObject);
    }

}