using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine; 

public class Canvas1 : MonoBehaviour
{

    public GameManager gameManager;

    public TextMeshProUGUI puntos;
    

    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }
}
