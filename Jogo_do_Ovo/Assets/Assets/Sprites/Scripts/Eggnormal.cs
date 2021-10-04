using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggnormal : MonoBehaviour {

    private GameObject Jogador;
    new Rigidbody2D rigidbody2D;

    //public float minimumFall = 2f;

    private float UltimaPosicaoEmY;
    private float DistanciaDeQueda;

    public float DistanciaMaximaDeQueda = 4;

    private float VidaDoPersonagem;

    //bool grounded = false;

    //bool wasGrounded;
   // bool wasFalling;
    //float startOfFall;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Jogador = GameObject.FindWithTag("Player");
        VidaDoPersonagem = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (UltimaPosicaoEmY > Jogador.transform.position.y && rigidbody2D.velocity.y < 0)
        {
            DistanciaDeQueda += UltimaPosicaoEmY - Jogador.transform.position.y;
        }
        UltimaPosicaoEmY = Jogador.transform.position.y;
        if (DistanciaDeQueda >= DistanciaMaximaDeQueda && rigidbody2D.velocity.y < 0)
        {
            VidaDoPersonagem = 0;
            ZerarVariaveis();
        }
        if (DistanciaDeQueda < DistanciaMaximaDeQueda && rigidbody2D.velocity.y < 0)
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
            gameController.GameOver();
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

    /*private void FixedUpdate()
    {
        CheckGround();

        if (!wasFalling && isFalling) startOfFall = transform.position.y;
        if (!wasGrounded && grounded) TakeDamage();

        wasGrounded = grounded;
        wasFalling = isFalling;
    }

    void CheckGround()
        {
        grounded = Physics2D.Raycast(transform.position + Vector3.up, -Vector3.up, 1.01f);
        }

    bool isFalling { get 
        {
            return (!grounded && rigidbody2D.velocity.y < 0);
        } }

    void TakeDamage()
        {
        float fallDistance = startOfFall - transform.position.y;

        if (fallDistance > minimumFall)
        {
            Debug.Log("Player caiu " + fallDistance + " centímetros");
        }
        }*/

}  