using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // los dos textos del canvas
    public TextMeshProUGUI pointLeft;
    public TextMeshProUGUI pointRight;

    // Las 2 variables numéricas: los puntos de cada jugador
    public int puntosP1 = 0;
    public int puntosP2 = 0;


    void Start()
    {
        ActualizarMarcador();
    }

    // Llama a esta función cuando el jugador 1 marque un punto
    public void SumarPuntoP1()
    {
        puntosP1++;
        ActualizarMarcador();
    }

    // Llama a esta función cuando el jugador 2 marque un punto
    public void SumarPuntoP2()
    {
        puntosP2++;
        ActualizarMarcador();
    }

    // Pasa los números a texto y los muestra en pantalla
    void ActualizarMarcador()
    {
        pointLeft.text = "" + puntosP1;
        pointRight.text = "" + puntosP2;

        Debug.Log("Marcador: " + puntosP1 + " | " + puntosP2);
    }

}
