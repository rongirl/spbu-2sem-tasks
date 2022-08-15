using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public int floorCount = 0;
    public Text floorCountText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {  
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position - transform.right * speed * Time.deltaTime);
        } 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TeleportUp")
        {
            float positionX = (6.2f - transform.position.x) * 2;
            float positionZ = (-12.15f - transform.position.z) * 2;
            transform.position += new Vector3(positionX, 16.87f, positionZ);
            transform.Rotate(0, 180f, 0, Space.Self);
            floorCount++;
            floorCountText.text = floorCount.ToString();
        }

        if (collision.gameObject.tag == "TeleportDown" && floorCount > 0)
        {
            float positionX = (6.2f - transform.position.x) * 2;
            float positionZ = (-12.15f - transform.position.z) * 2;
            transform.position += new Vector3(positionX, -16.87f, positionZ);
            transform.Rotate(0, 180f, 0, Space.Self);
            floorCount--;
            floorCountText.text = floorCount.ToString();
        }
    }
}