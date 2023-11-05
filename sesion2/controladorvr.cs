//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class controladorvr : MonoBehaviour
{

    public string sillaTag = "silla"; 
    public string zombieTag = "silla"; 
    private GameObject zombie;


    public delegate void CollisionHandler();
    public float speed = 10f; // Velocidad de movimiento

    public static event CollisionHandler DefaultSilla;

    public Renderer _myRenderer;

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        zombie = GameObject.FindGameObjectWithTag(zombieTag);


    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        //SESION 2
        //Mismo codigo que el de mover las arañas hacia el zombie pero al reves.

        Debug.Log("Has mirado a la pizarra");

        Debug.Log("Arañas se van a otro lado");
         GameObject[] group_arañas = GameObject.FindGameObjectsWithTag("araña");
            foreach (GameObject araña in group_arañas)
            {
                Vector3 fuera = new Vector3(4,4,4);
                araña.transform.position = Vector3.Lerp(araña.transform.position, fuera, speed * Time.deltaTime);          


            }
        

        //SESION 2
        //
        DefaultSilla();
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        Debug.Log("Has dejado de mirar a la pizarra");

    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    
}
