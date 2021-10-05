using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSwitch : MonoBehaviour
{
    public bool isArmored;
    public GameObject normalEgg;
    public GameObject armoredEgg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Armor"))
        {
            Debug.Log("trocou");
            isArmored = true;
            normalEgg.SetActive(!isArmored);
            armoredEgg.SetActive(isArmored);
        }
    }



    }
