using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{

    public float windForce;
    public bool direction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigidbody2D = collision.GetComponent<Rigidbody2D>();
            Vector2 force;
            if (direction)
            {
                force = new Vector2(windForce, 0f);
            }
            else
            {
                force = new Vector2(windForce * -1f, 0f);
            }
            rigidbody2D.AddForce(force);
        }
    }
}
