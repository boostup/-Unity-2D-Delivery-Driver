using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300;
    [SerializeField] float moveSpeed = 20;
    [SerializeField] float slowSpeed = 10;
    [SerializeField] float normalSpeed = 20;
    [SerializeField] float boostSpeed = 30;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
        }
        if (other.tag == "Bump")
        {
            moveSpeed = slowSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (moveSpeed > slowSpeed) moveSpeed = normalSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }
}
