using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//importar librería para escenarios
using UnityEngine.SceneManagement;

public class menuOpciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Método para llamar al juego
    
    // Opción Menú 1 
    public void cargarJuego() // Nivel1
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    // Opción Menú 2
    public void cargarJuegoN2() // Nivel2
    {
        SceneManager.LoadScene("Nivel2");
    }
    
    // Opción Menú 3
    public void cerrarJuego()
    {
        {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // cierra el editor
        #else
            Application.Quit(); // cierra la aplicación instalada
        #endif
            
        }
    }
    
}
