using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI Llaves;
    public Image circuloRunas;
    public Image Vida;
    public Sprite Vida3, Vida2, Vida1, Vida0;
    public Sprite Runa2, Runa4, Runa6, Runa8;
    public GameObject Farol1, Farol2, Farol3, Farol4;
    public Sprite Encendido1, Encendido2, Encendido3, Encendido4;
    public Light luz1, luz2, luz3, luz4;

    void Update()
    {
        
    }

    public void NumeroLlaves(int LlavesTotales)
    {
        Llaves.text = LlavesTotales.ToString();
    }

    public void CirculoRunas(int totalRunas)
    {
        if (totalRunas == 2)
        {
            circuloRunas.sprite = Runa2;
            Farol1.GetComponent<SpriteRenderer>().sprite = Encendido1;
            luz1.enabled = true;
        }
        else if (totalRunas == 4)
        {
            circuloRunas.sprite = Runa4;
            Farol2.GetComponent<SpriteRenderer>().sprite = Encendido2;
            luz2.enabled = true;
        }
        else if (totalRunas == 6)
        {
            circuloRunas.sprite = Runa6;
            Farol3.GetComponent<SpriteRenderer>().sprite = Encendido3;
            luz3.enabled = true;
        }
        else if (totalRunas == 8)
        {
            circuloRunas.sprite = Runa8;
            Farol4.GetComponent<SpriteRenderer>().sprite = Encendido4;
            luz4.enabled = true;
        }
    }

    public void BarraVida(int vidasTotales)
    {
        if (vidasTotales == 3)
        {
            Vida.sprite = Vida3;
        }
        else if (vidasTotales == 2)
        {
            Vida.sprite = Vida2;
        }
        else if (vidasTotales == 1)
        {
            Vida.sprite = Vida1;
        }
        else if (vidasTotales == 0)
        {
            Vida.sprite = Vida0;
        }
    }
}
