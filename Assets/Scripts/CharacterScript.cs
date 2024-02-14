﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private float speed = 10f;
    private float playerVelocityY; // вертикальна компонента швидкості
    private float gravityValue = -9.80f;
    private float jumpHeight = 1.0f;
    private bool groundedPlayer;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        playerVelocityY = 0f;

    }
    void Update()
    {
       groundedPlayer = _characterController.isGrounded;
        if (groundedPlayer && playerVelocityY < 0)
        {
            playerVelocityY = 0f;
        }

        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        if (Mathf.Abs(dx) > 0 && Mathf.Abs(dy) > 0)
        {
            dx *= 0.707f; // /= Mathf.Sqrt(2f);
            dy *= 0.707f; // /= Mathf.Sqrt(2f);
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocityY += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        // Camera.main.transform.forward - має нахил, иому для .Move має піднімальний ефект
        Vector3 horizontalForward = Camera.main.transform.forward;
        horizontalForward.y = 0;
        horizontalForward = horizontalForward.normalized;

        playerVelocityY += gravityValue * Time.deltaTime;

        _characterController.Move(Time.deltaTime *
            (speed * (dx * Camera.main.transform.right + dy * horizontalForward) +
            playerVelocityY * Vector3.up));
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter: " + other.gameObject.name);
        if (other.CompareTag("Floor"))
        {
            groundedPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit: " + other.gameObject.name);
        if (other.CompareTag("Floor"))
        {
            groundedPlayer = false;
        }
    }
}
