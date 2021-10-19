using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    //Jump
    public int JumpForce;
    private Rigidbody rb;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        //Jump
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Make the bird "Fly"
            //transform.position += transform.up * JumpForce * Time.deltaTime;
            rb.AddForce(Vector3.up * JumpForce);

            //Animation
            thisAnimation.Play();
        }
            
    }
}
