using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    public float movX, movY;
    private Rigidbody2D movFisicas;
    public bool seChoca = false;
    private bool mirandoDerecha = true;


    public int keys;
    public int vidas = 4;
    public int perdidaVidas = 1;


    float tiempo = 0f;
    public GameManager gameManager;
    
    
    private Animator animator;
    public Sprite Muerto;
    public Color azul;
    public Color Base;
    private SpriteRenderer personaje;

    // Start is called before the first frame update.......................................................................................................................................................

    void Start()
    {
        movFisicas = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
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
        // Mover al jugador................................................................................................................................................................................
        Vector2 movimiento = new Vector2(movX * 3, movY * 3);
        movFisicas.velocity = movimiento;


        //Animaciones de movimiento........................................................................................................................................................................
        if (movX == 0 && movY == 0 && vidas > 0)
        {
            animator.SetBool("Walking", false);
        }
        else if(movX != 0 || movY != 0 && vidas > 0)
        {
            animator.SetBool("Walking", true);
        }

        Orientacion();
        Chocarse(movimiento);
        Salud();
    }

    //Muerte del personaje.................................................................................................................................................................................
    void Salud()
    {
        if(vidas == 0)
        {
            movFisicas.velocity = new Vector2(0, 0);
            animator.SetBool("isDead", true);
        }
    }

    // Cambiar la orientacion del personaje.................................................................................................................................................................
    void Orientacion()
    {
        if(  (mirandoDerecha == true && movX < 0 && vidas > 0) || (mirandoDerecha == false && movX > 0 && vidas > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Cuando se Choca.......................................................................................................................................................................................

    void Chocarse(Vector2 movimiento)
    {
        if (seChoca && tiempo > 0 && vidas > 0)
        {
            // contar...
            Vector2 parado = new Vector2(0, 0);
            movFisicas.velocity = parado;
            personaje = GetComponent<SpriteRenderer>();
            personaje.color = azul;
            tiempo = tiempo - Time.fixedDeltaTime;
        }
        else if (seChoca && tiempo == 0)
        {
            seChoca = false;
            movFisicas.velocity = movimiento;
        }
        else
        {
            personaje = GetComponent<SpriteRenderer>();
            personaje.color = Base;
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
            Destroy(collision.gameObject);
            gameManager.LlavesTotales(keys);
        }
        else if (collision.gameObject.tag == "Puerta" && keys >= 1)
        {
            keys = keys - 1;
            Destroy(collision.gameObject);
            gameManager.LlavesTotales(keys);
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
            vidas -= 1;
            gameManager.RestarVidas(perdidaVidas);
        }
        else if (collision.gameObject.tag == "Enemigo")
        {
            tiempo = 2f;
            seChoca = true;
            vidas -= 1;
            gameManager.RestarVidas(perdidaVidas);
        }

    }

}
