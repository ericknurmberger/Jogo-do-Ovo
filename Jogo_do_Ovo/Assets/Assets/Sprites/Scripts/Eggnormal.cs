using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggnormal : MonoBehaviour {

    private GameObject Jogador;
    new Rigidbody2D rigidbody2D;

    private float UltimaPosicaoEmY;
    private float DistanciaDeQueda;

    public float DistanciaMaximaDeQueda = 4;

    private float VidaDoPersonagem;

    public bool isArmored;
    public GameObject normalEgg;
    public GameObject armoredEgg;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Armor"))
        {
            Debug.Log("pegou armadura");
            isArmored = true;
            normalEgg.SetActive(!isArmored);
            armoredEgg.SetActive(isArmored);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {
            if (DistanciaDeQueda > DistanciaMaximaDeQueda && isArmored == false)
            {
                VidaDoPersonagem = 0;
            }
            ZerarVariaveis();
            if (DistanciaDeQueda > DistanciaMaximaDeQueda && isArmored == true)
            {
                isArmored = !isArmored;
                normalEgg.SetActive(isArmored);
                armoredEgg.SetActive(!isArmored);
            }
            ZerarVariaveis();
        }

        if (collision.collider.CompareTag("Nest"))
        {
            gameController.LevelClear();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DistanciaMaximaDeQueda);
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