using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Esta cosilla es para modificar el rango de la velocidad en el inspector.
    [Range(1, 10)]
    public float jumpVelocity;

    // Update is called once per frame
    void Update()
    {
        // Al presionar el espacio
        if (Input.GetButtonDown("Jump"))
        {
            //Agrega velocidad para saltar.
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }
}
