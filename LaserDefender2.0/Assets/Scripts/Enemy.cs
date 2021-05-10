using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4;
    private Vector3 _moveStraight = new Vector3(1, 1, 0);
    private float _randomValue = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveStraight * -1 * _speed * Time.deltaTime);

        if (GameObject.FindGameObjectWithTag("Player") == null && transform.position.y < -7.0f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y < -7.0f)
        {
            float randomX = Random.Range(-_randomValue, _randomValue);
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
        transform.position = new Vector3(Random.Range(-_randomValue, _randomValue), 8, 0);        
    }
}
