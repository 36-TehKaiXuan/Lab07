using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (gameObject.transform.position.y < 3.5)
            {
                rb.AddForce(Vector3.up * JumpForce);
            }
            if (gameObject.transform.position.y > 3.5)
            {
                rb.velocity = Vector3.zero;
            }
            //Animation
            thisAnimation.Play();
        }
        //-4.5
        //Lose Condition by falling
        if (gameObject.transform.position.y < -4.5)
        {
            //Lose
            SceneManager.LoadScene("LoseScene");
        }
    }

    //Collision with obstacle
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Avoid")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
