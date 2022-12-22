using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlFox : MonoBehaviour

{
    

    public float velocidad = 12f;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;

    public float saltoMax;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private float saltosDiferente;
    private Animator animator;
    
    
    private void Start()
    { 
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosDiferente = saltoMax;
        animator = GetComponent<Animator>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        ProcesarMov();
        ProcesarSalto();
       
        
        

        
    }

    bool estaSuelo()
    {
       RaycastHit2D raycastHit =   Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),
                                    0f, Vector2.down, 0.2f, capaSuelo);

       return raycastHit.collider != null;

    }

    void ProcesarSalto()
    {
        if (estaSuelo())
        {
            saltosDiferente = saltoMax;
        }
            
        
        if (Input.GetKeyDown(KeyCode.Space) && saltosDiferente > 0 )
        {
            saltosDiferente = saltosDiferente - 1;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            AudioManager.Instance.ReproducirSonido(sonidoSalto);
        }
    }

    void ProcesarMov()
    {
        //movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetBool("estaCorriendo", true);
        }
        else
        {
            animator.SetBool("estaCorriendo", false);
        }
        
        
        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);

        GestionOrientacion(inputMovimiento);
    }

    void GestionOrientacion(float inputMovimiento)
    {
        
        if(mirandoDerecha == true && inputMovimiento < 0  || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    // invocacion de colisiones con cajas de interrogaciones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // tag Respawn --------> respawn 
        if (collision.gameObject.CompareTag("Respawn"))
        {
            transform.position = new Vector3(-59,4,0);
        }
        
        // tag VelocidadSube ------> aumenta velocidad a 60
        if (collision.gameObject.CompareTag("VelocidadSube"))
        {
            velocidad = 60f;
        }
        
        // tag VelocidadBaja -------> disminuye velocidad a 1
        if (collision.gameObject.CompareTag("VelocidadBaja"))
        {
            velocidad = 1f;
        }
        
        // tag VelocidadNormal -------> velocidad del inicio
        if (collision.gameObject.CompareTag("VelocidadNormal"))
        {
            velocidad = 12f;
        }
        
        // tag Finish -------> Ganaste!!!!
        if (collision.gameObject.CompareTag("Finish"))
        {
            transform.position = new Vector3(-50,51,0); 
        }
        
    }
    
    
}

