using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedAndroid;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        #if UNITY_EDITOR
                //this input is for pc
                if (Input.GetMouseButton(0))
                {
                    float mouseX = -Input.GetAxisRaw("Mouse X");
                    transform.Rotate(transform.position.x, mouseX * speed * Time.deltaTime, transform.position.z);
                }
        #elif UNITY_ANDROID
                //for mobile
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    float xDeltaPos = -Input.GetTouch(0).deltaPosition.x;
                    transform.Rotate(transform.position.x, xDeltaPos * speedAndroid * Time.deltaTime, transform.position.z);
                }
        #endif
    }
}