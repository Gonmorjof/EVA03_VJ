using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//importar librería para escenarios
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Botón interior

    public void menuPausaJuego()
    {
        SceneManager.LoadScene("MenuJuego");
    }
}
