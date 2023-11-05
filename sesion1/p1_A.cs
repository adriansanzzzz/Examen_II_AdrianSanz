using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_A : MonoBehaviour
{
    public string zombieTag = "zombie"; // Etiqueta del zombie
    public float speed = 0.5f; // Velocidad de movimiento
    private GameObject zombie;
    private GameObject pizarra;
    public string pizarraTag = "pizarra";
    public string sillaTag = "silla"; // Etiqueta del zombie
    public string macetaTag = "maceta"; // Etiqueta del zombie


    public Rigidbody araña1;
    public Rigidbody araña2;
    public Rigidbody araña3;



    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag(zombieTag);
        pizarra = GameObject.FindGameObjectWithTag(pizarraTag);

        araña1 = GetComponent<Rigidbody>();
        araña2 = GetComponent<Rigidbody>();
        araña3 = GetComponent<Rigidbody>();

        
   
    }

    // Update is called once per frame
      void Update()
    {
        float horizontalInput = Input.GetAxis("AD");
        transform.Rotate(0, horizontalInput, 0);

        // Obtener la dirección hacia adelante 
        Vector3 forwardDirection = transform.forward;

        // Dibuja una línea de depuración para visualizar la dirección hacia adelante
        Debug.DrawRay(transform.position, forwardDirection, Color.green);

        // Mover el hacia adelante en función de la dirección hacia adelante
        transform.Translate(forwardDirection * speed * Time.deltaTime, Space.World);


        if (Input.GetKey(KeyCode.T)) { 
            int randomPointIndex = Random.Range(0, 10); 
            transform.position = new Vector3(randomPointIndex,randomPointIndex,randomPointIndex);}

        float distance = Vector3.Distance(zombie.transform.position, pizarra.transform.position);

        if(distance < 4){
            MoverMacetas_Sillas();
        }

    }
    void MoverMacetas_Sillas(){
        GameObject[] group_sillas = GameObject.FindGameObjectsWithTag(sillaTag);
        GameObject[] group_macetas = GameObject.FindGameObjectsWithTag(macetaTag);

        foreach (GameObject silla in group_sillas)
        {   
            Vector3 zombiepos = zombie.transform.position;
            Vector3 sillapos= silla.transform.position;
            Vector3 distanca = new Vector3(0,0,5);


            Vector3 directionzombie = zombiepos - sillapos;

            silla.transform.Translate(directionzombie + distanca);

        }

        foreach (GameObject maceta in group_macetas)
        {
            int randomPointIndex = Random.Range(0, 10); 
            maceta.transform.position = new Vector3(randomPointIndex,randomPointIndex,randomPointIndex);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(zombieTag))
        {
            Vector3 newPosition1 = Vector3.MoveTowards(araña1.position,transform.position , speed * Time.deltaTime);
            araña1.MovePosition(newPosition1);
            Vector3 newPosition2 = Vector3.MoveTowards(araña2.position,transform.position , speed * Time.deltaTime);
            araña2.MovePosition(newPosition2);
            Vector3 newPosition3 = Vector3.MoveTowards(araña3.position,transform.position , speed * Time.deltaTime);
            araña3.MovePosition(newPosition3);

        }
    }
}
