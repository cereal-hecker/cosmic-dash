using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class initialRun : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float HorizontalSpeed = 3.0f;
    public float rightLimit = 5.5f;
    public float leftLimit = 5.5f;
    // void Start()
    // {
    //     if press
    // }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     transform.Translate(Vector3.up * jumpHeight, Space.World);
        // }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime * -1, Space.World);
            }
        }
        // if (Input.GetKey(KeyCode.KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        // {
        //     transform.Translate(Vector3.forward * -1 * playerSpeed * Time.deltaTime, Space.World);
        // }
        // if (Input.GetKey(KeyCode.KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        // {
        //     transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);
        // }

    }
}
