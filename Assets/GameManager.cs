using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public int RunasTotales { get { return runas; } }
    public int VidasTotales { get { return vidas; } }
    public int LlavesEnPosesion { get { return llaves; } }

    public HUD hud;

    private int runas;
    
    private int vidas = 4;
    public int llaves;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Debug.Log("Mas de un Game Manager");
        }
    }
    public void SumarRunas(int runasObtenidas)
    {
        runas += runasObtenidas;
        hud.CirculoRunas(RunasTotales);
    }

    public void RestarVidas(int VidasRestantes)
    {
        vidas -= VidasRestantes;
        hud.BarraVida(VidasTotales);
    }

    public void LlavesTotales(int Llaves)
    {
        llaves = Llaves;
        hud.NumeroLlaves(LlavesEnPosesion);
    }
}
