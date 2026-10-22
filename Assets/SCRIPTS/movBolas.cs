using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movBolas : MonoBehaviour
{
    public float velocidad = 10f;
    public GameManager manager;
    private Rigidbody2D _rb;
    private float tiempoAtascada = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        LaunchBall();

    }

    void FixedUpdate()
    {

        _rb.velocity = _rb.velocity.normalized * velocidad;

    }

    void LaunchBall()
    {
        bool isRight = false;
        if (Random.value > 0.5f)
        {
            isRight = true;
        }
        float xVelocity = -1;
        if (isRight = true)
        {
            xVelocity = 1;
        }
        float yVelocity = Random.Range(-1f, 1f);
        _rb.velocity = new Vector2(xVelocity * velocidad, yVelocity * velocidad);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "leftwall")
        {
            manager.SumarPuntoP2();
        }
        if (collision.gameObject.name == "rightwall")
        {
            manager.SumarPuntoP1();
        }

    }

}
