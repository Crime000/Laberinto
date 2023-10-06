using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public float movX, movY;
    Rigidbody2D movFisicas;
    public bool seChoca = false;
    public float keys;
    float tiempo = 0f;
    public int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
        movFisicas = GetComponent<Rigidbody2D>();

        movFisicas.AddForce(Vector2.up * 1, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 movimiento = new Vector2(movX * 3, movY * 3);
        movFisicas.velocity = movimiento;

        if(seChoca && tiempo > 0)
        {
            // contar...
            Vector2 parado = new Vector2(0, 0);
            movFisicas.velocity = parado;
            tiempo = tiempo - Time.fixedDeltaTime;
        }
        else if (seChoca && tiempo == 0)
        {
            seChoca = false;
            movFisicas.velocity = movimiento;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Paredes")
        {
            tiempo = 2f;
            seChoca = true;
        }
        else if (collision.gameObject.tag == "Llaves")
        {
            keys = keys + 1;
            Debug.Log("Llaves: " + keys);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Puerta" && keys >= 1)
        {
            keys = keys - 1;
            Debug.Log("Llaves: " + keys);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Puerta" && keys < 1)
        {
            Debug.Log("No tienes llaves");
        }
        else if (collision.gameObject.tag == "Tesoro")
        {
            Debug.Log("Todo tuyo, no olvides pagar tus impuestos");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Trampa")
        {
            tiempo = 2f;
            seChoca = true;
            vidas = vidas - 1;
            Debug.Log("Te quedan: " + vidas);
        }

    }
}
