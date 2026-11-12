using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWall : MonoBehaviour
{
        public AudioSource pointScoredSound;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
            if (collision.gameObject.GetComponent<movBolas>() != null)
            {
                pointScoredSound.Play();
            }
        }
    }
