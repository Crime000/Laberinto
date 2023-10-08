using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Rigidbody2D fisicas;
    public GameObject PuntoA;
    public GameObject PuntoB;
    public float velocidad;
    private Transform posicionActual;
    private Animator muerte;
    BoxCollider2D colision;

    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        posicionActual = PuntoB.transform;
        muerte = GetComponent<Animator>();
        colision = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicion = posicionActual.position - transform.position;
        if(posicionActual == PuntoB.transform)
        {
            fisicas.velocity = new Vector2(velocidad, 0);
        }
        else
        {
            fisicas.velocity = new Vector2(-velocidad, 0);
        }

        if(Vector2.Distance(transform.position, posicionActual.position) < 0.5f && posicionActual == PuntoB.transform)
        {
            girar();
            posicionActual = PuntoA.transform;
        }
        else if (Vector2.Distance(transform.position, posicionActual.position) < 0.5f && posicionActual == PuntoA.transform)
        {
            girar();
            posicionActual = PuntoB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Jugador")
        {
            velocidad = 0;
            muerte.SetBool("seMuere", true);
        }
    }

    private void girar()
    {
        Vector3 ubicar = transform.localScale;
        ubicar.x *= -1;
        transform.localScale = ubicar;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PuntoA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PuntoB.transform.position, 0.5f);
        Gizmos.DrawLine(PuntoA.transform.position, PuntoB.transform.position);
    }
}
