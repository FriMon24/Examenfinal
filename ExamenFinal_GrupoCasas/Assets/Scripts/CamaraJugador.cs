using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    public GameObject InicioJugador;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = InicioJugador.transform.position.x;
        transform.position = position;
    }
}
