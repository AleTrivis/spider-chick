using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControl : MonoBehaviour
{
    float dirX, dirY, moveSpeed;
    bool left, right;

    Animator anim;

    // Inicialización de las variables.
    void Start()
    {
        right = true;
        TurnLeft();
        anim = GetComponent<Animator>();
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        dirY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        // Mueve al personaje.
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        // Condiciones para cambiar las animaciones.
        if (dirX != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        
        if (dirY != 0)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        
        // Velocidad del personaje.
        float speed = Input.GetAxisRaw("Horizontal");
        
        // Según la velocidad lo voltea a la derecha o la izquierda.
        if (speed < 0)
            TurnLeft();
        if (speed > 0)
            TurnRight();
        //anim.SetFloat("speed", Mathf.Abs(speed));
        speed = speed * Time.deltaTime * moveSpeed;
        
        // Mueve el personaje
        transform.Translate(speed, 0, 0);
    }

    // Invierte la imagen del personaje para que voltee a la izquierda.
    public void TurnLeft()
    {
        if (left)
            return;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }

    public void TurnRight()
    {
        if (right)
            return;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
    }
}
