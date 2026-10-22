using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;//velocidad de las palas
    public float topheight;//Límite superior 
    public float botheight;//Límite inferior
    public bool useArrowKeys = false;//Si da True, se usan los Arrow keys; sino, se usa W 'y' S.

    void Update()
    {
        
        movePaddle();

    }
    void movePaddle()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, constrainPaddle(), transform.position.z);
    }

    float constrainPaddle()
    {
        float nuevaY = this.gameObject.transform.position.y + (paddleDirection() * moveSpeed * Time.deltaTime);
        if (nuevaY > topheight)
        {
            nuevaY = topheight;
        }
        if (nuevaY < botheight)
        {
            nuevaY = botheight;
        }
        return nuevaY;
    }

    float paddleDirection()
    {
        float direccion = 0f;

        if (useArrowKeys == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direccion = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direccion = -1;
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                direccion = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direccion = -1;
            }
        }
        return direccion;

    }

}
