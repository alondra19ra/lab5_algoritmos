using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento
{
    public Vector2 posicionAntes { get; set; }
    public Vector2 posicionDespues { get; set; }

    public Movimiento(Vector2 posicionAntes, Vector2 posicionDespues)
    {
        this.posicionAntes = posicionAntes;
        this.posicionDespues = posicionDespues;
    }
}