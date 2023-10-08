using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public float movX, movY;
    private Rigidbody2D movFisicas;
    public bool seChoca = false;
    public int keys;
    float tiempo = 0f;
    public int vidas = 3;
    public int runas = 0;
    private bool mirandoDerecha = true;

    // Start is called before the first frame update.......................................................................................................................................................

    void Start()
    {
        movFisicas = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.....................................................................................................................................................................

    void Update()
    {
        // Declarar movimiento del jugador...
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Mover al jugador...
        Vector2 movimiento = new Vector2(movX * 3, movY * 3);
        movFisicas.velocity = movimiento;

        Orientacion();
        Chocarse(movimiento);
    }

    void Orientacion()
    {
        if(  (mirandoDerecha == true && movX < 0) || (mirandoDerecha == false && movX > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    // Cuando se Choca.......................................................................................................................................................................................

    void Chocarse(Vector2 movimiento)
    {
        if (seChoca && tiempo > 0)
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

    // Colisiones.............................................................................................................................................................................................

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
        else if (collision.gameObject.tag == "Moneda")
        {
            runas = runas + 1;
            Debug.Log("Runas: " + runas);
            Destroy(collision.gameObject);
        }

    }

}
