using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_B : MonoBehaviour
{
    private GameObject zombie;

    public delegate void CollisionHandler();
    public static event CollisionHandler MovSilla;
    public static event CollisionHandler DefaultSilla;


    private float distance = 0.5f;  // Debes declarar 'distance' como una variable de tipo float
    private float posicion;

    private Vector3 pos_inicial;

    public float distanciaMinima = 5;
    // Start is called before the first frame update
    void Start()
    {
        pos_inicial=transform.position;
        zombie = GameObject.FindGameObjectWithTag("zombie");
        p1_A.MovSilla += MovimientoSilla;
        controladorvr.DefaultSilla += Movimientoalprincipio;
    }

    void MovimientoSilla()
    {
        Debug.Log("Silla en movimiento");

        float distanciaSillaZombie = Vector3.Distance(zombie.transform.position, transform.position);

            if (distanciaSillaZombie > distanciaMinima)
            {
                Vector3 direccion = zombie.transform.position - transform.position;
                transform.position += direccion.normalized;
            }
        
    }

    void Movimientoalprincipio(){

        Debug.Log("Restaurando posición de sillas a la incial");
        transform.position = pos_inicial;

    }
}
