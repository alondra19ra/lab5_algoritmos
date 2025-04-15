using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector2 posicionInicial;
    private stack<Movimiento> pilaMovimientos; 
    public TextMeshProUGUI estadoTexto; 
    public GameObject botonDeshacer; 
    public GameObject botonSiguiente; 
    public GameObject botonAtras; 

    void Start()
    {
        pilaMovimientos = new stack<Movimiento>(); 
        posicionInicial = transform.position; 
        ActualizarEstado("Esperando acción");
        Debug.Log("Estado inicial: Esperando acción"); 
        botonDeshacer.SetActive(false); 
    }

    void Update()
    {

        Vector2 posicionAntes = transform.position;


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical).normalized;
        transform.position += (Vector3)(direccion * velocidad * Time.deltaTime);

        Vector2 posicionDespues = transform.position;

    
        if (posicionAntes != posicionDespues)
        {
            pilaMovimientos.Push(new Movimiento(posicionAntes, posicionDespues));
            ActualizarEstado("Movimiento realizado");
            Debug.Log("Movimiento realizado: " + posicionAntes + " -> " + posicionDespues); // Mostrar en consola
            botonDeshacer.SetActive(true); 
        }

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DeshacerMovimiento();
        }
    }

    public void DeshacerMovimiento()
    {
        if (pilaMovimientos.Count() > 0)
        {
            Movimiento ultimoMovimiento = pilaMovimientos.Pop();
            transform.position = ultimoMovimiento.posicionAntes;
            ActualizarEstado("Último movimiento deshecho");
            Debug.Log("Movimiento deshecho: " + ultimoMovimiento.posicionDespues + " -> " + ultimoMovimiento.posicionAntes); 
            botonSiguiente.SetActive(true); 
        }
        else
        {
            ActualizarEstado("No hay movimientos para deshacer");
            Debug.Log("No hay movimientos para deshacer."); 
        }
    }

    public void SiguienteMovimiento()
    {
       
        ActualizarEstado("Siguiente movimiento no implementado aún");
        Debug.Log("Siguiente movimiento no implementado."); 
    }

    public void AtrasMovimiento()
    {
     
        ActualizarEstado("Atras movimiento no implementado aún");
        Debug.Log("Atras movimiento no implementado."); 
    }

    void ActualizarEstado(string nuevoEstado)
    {
        if (estadoTexto != null)
        {
            estadoTexto.text = "Estado: " + nuevoEstado;
        }
    }


    public void BotonDeshacer()
    {
        DeshacerMovimiento();
    }

    public void BotonSiguiente()
    {
        SiguienteMovimiento();
    }

    public void BotonAtras()
    {
        AtrasMovimiento();
    }
}
