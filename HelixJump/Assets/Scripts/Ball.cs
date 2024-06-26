using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bounceForce;
    //private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);

        string tagName = other.transform.tag;
        if (tagName == "Unsafe")
        {
            //gameManager.GameOver();
            GameManager.instance.GameOver();
        }
        if (tagName == "Last")
        {
            //gameManager.LevelWin();
            GameManager.instance.LevelWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tagName = other.transform.tag;

        Ring ring = other.GetComponent<Ring>();
        if (ring!=null) 
        {
            //gameManager.numOfPassingRings++;
            //gameManager.SetProgressBar();
            GameManager.instance.numOfPassingRings++;
            GameManager.instance.SetProgressBar();

            ring.ExplodeRings();
        }
    }
}