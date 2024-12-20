using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InitialRun : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float laneDistance = 3.0f; 
    public float laneSwitchSpeed = 5.0f; 

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private Vector3 targetPosition;

    // private Animator playerAnimator; // Animator for controlling animations

    public GameObject playerObject;
    public bool isJumping = false;
    public bool comingDown = false;

    void Start()
    {
        targetPosition = transform.position; 
    }

    void Update()
    {
        // Move player forward
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        // Handle lane switching
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0) currentLane--;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 2) currentLane++;
        }

        // Set target position for lane switching
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);

        // Smoothly move to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * laneSwitchSpeed);

        // Handle Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) // Jump on Spacebar
        {
            // Jump();
            if (isJumping == false)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }

        // Handle Roll
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) // Roll on Left Control
        {
            // Roll();
        }

        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * 3 * Time.deltaTime, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * -3 * Time.deltaTime, Space.World);
            }
        }
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }
}
