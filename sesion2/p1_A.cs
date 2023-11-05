using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_A : MonoBehaviour
{
    public delegate void CollisionHandler();
    public static event CollisionHandler MovSilla;
    public static event CollisionHandler DefaultSilla;

    public string zombieTag = "zombie"; // Etiqueta del zombie
    public float speed = 10f; // Velocidad de movimiento
    private GameObject zombie;
    private GameObject pizarra;
    public string pizarraTag = "pizarra";
    public string sillaTag = "silla"; // Etiqueta del zombie
    public string macetaTag = "maceta"; // Etiqueta del zombie
    public int cont = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag(zombieTag);
        pizarra = GameObject.FindGameObjectWithTag(pizarraTag);
   
    }

    // Update is called once per frame
      void Update()
    {

        // SESION 2
        // He mejorado el codigo para que el movimiento solo sea cuando se pulsan las teclas, ya que el anterior
        // siempre iba hacia adelante y no paraba

        float movimientoHorizontal = Input.GetAxis("AD");
        float movimientoVertical = Input.GetAxis("WS");

        // Calcula la dirección de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        movimiento.Normalize(); // Normaliza el vector para evitar movimientos más rápidos en diagonales


        // Si se registra algun movimiento del zombie
        if (movimiento != Vector3.zero)
        {
            // Rota el Zombie para mirar en la dirección del movimiento
            transform.forward = movimiento;
            // Mueve el Zombie hacia adelante en la dirección actual
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.T)) { 
            int randomPointIndex = Random.Range(0, 10); 
            transform.position = new Vector3(randomPointIndex,randomPointIndex,randomPointIndex);}

        float distance = Vector3.Distance(zombie.transform.position, pizarra.transform.position);

        if(distance < 2){
            MoverMacetas_Sillas();
        }

    }
    void MoverMacetas_Sillas(){
        GameObject[] group_macetas = GameObject.FindGameObjectsWithTag(macetaTag);

        // SESION 2
        // He cambiado el codigo haciendo todo lo que conlleva movimientos con las sillas
        // se haga desde un script aparte para asi poder almacenar la posición incial
        // de las sillas y sea más sencillo para el ejercicio 7 obtener la posición incial.
        
        MovSilla();

        Debug.Log("Maceta en movimiento");

        foreach (GameObject maceta in group_macetas)
        {
            int randomPointIndex = Random.Range(0, 10); 
            maceta.transform.position = new Vector3(randomPointIndex,randomPointIndex,randomPointIndex);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // SESION 2
        // He decido modificar esta parte ya que al recargar la escena no se movian la arañas, tras intentarlo 
        // no bhe conseguido moverlas, pero creo que el codigo es correcto.

        if (collision.gameObject.CompareTag("silla")){ //aqui habia un error con el tag
        
            Debug.Log("COLISION SILLA");
            GameObject[] group_arañas = GameObject.FindGameObjectsWithTag("araña");
            Debug.Log(group_arañas.Length);

            foreach (GameObject araña in group_arañas)
            {
                araña.transform.position = Vector3.Lerp(araña.transform.position, transform.position, speed * Time.deltaTime);          
            }
        
            
        }

        if (collision.gameObject.CompareTag("maceta")){
            cont++;

            if(cont==3){
                Debug.Log("Movimiento arañas cama");
                Debug.Log("Movimiento sillas puerta");

            }

    }
    }
}

