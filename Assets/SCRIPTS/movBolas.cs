using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movBolas : MonoBehaviour
{
    public float velocidad = 10f;
    public float speedMulty = 1;

    public GameManager manager;
    AudioSource _audioSource;
    private Rigidbody2D _rb;
    float _lastHorizontalDirection = 1f;
    private float tiempoAtascada = 0f;

    public float timeAlive = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        LaunchBall(0);
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 2f)
        {
            speedMulty += 0.25f;
            timeAlive = 0f;
        }

    }

    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > velocidad * speedMulty)
        {
            _rb.velocity = _rb.velocity.normalized * velocidad * speedMulty;
        }

        if (Mathf.Abs(_rb.velocity.x) >= velocidad * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 1f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * velocidad;
        }
    }

    void LaunchBall(int dir)
    {
        this.transform.position = new Vector3(0, 0, 0);
        bool isRight = false;
        if (dir == 0)
        {
            if (Random.value > 0.5f)
            {
                isRight = true;
            }
        }
        else if (dir == 1)
        {
            isRight = true;
        }

        float xVelocity = -1;
        if (isRight == true)
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
            LaunchBall(1);
        }
        if (collision.gameObject.name == "rightwall")
        {
            manager.SumarPuntoP1();
            LaunchBall(-1);
        }
        _audioSource.Play();
        manager.ActualizarMarcador();

    }

}
