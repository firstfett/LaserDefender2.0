using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    private Vector3 _moveStraight = new Vector3(1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveStraight * -1 * _speed * Time.deltaTime);

        if (transform.position.y < -7.0f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 8f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(gameObject);
           // Destroy(other.gameObject);
        }
    }

    void SpawnEnemy()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 8, 0);
    }
}
