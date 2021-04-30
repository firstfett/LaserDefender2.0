using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float _speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticleInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticleInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.65f, 1f), 0);

        if (transform.position.x < -10.95f)
        {
            transform.position = new Vector3(10.95f, transform.position.y, 0);
        }
        else if (transform.position.x > 10.95f)
        {
            transform.position = new Vector3(-10.95f, transform.position.y, 0);
        }
    }
}
