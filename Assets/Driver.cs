using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float slowSpeed = 2;
    [SerializeField] float boostSpeed = 10;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
        Debug.Log("Bumped! Slowing...");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, 0.1f);
            Debug.Log("Booost! " + moveSpeed + " speed.");
        }
    }
}
