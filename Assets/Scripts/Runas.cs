using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runas : MonoBehaviour
{
    public int valorRunas = 2;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            gameManager.SumarRunas(valorRunas);
            Destroy(this.gameObject);
        }
    }
}
