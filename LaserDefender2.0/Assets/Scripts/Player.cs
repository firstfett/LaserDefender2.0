using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;

    private Vector3 _yOffset = new Vector3(0, 1.3f, 0);
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;

    private GameObject[] _enemyGameObjects;

    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI numberOfEnemiesInScene;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetButton("Fire1") && Time.time > _canFire)
        {
            FireLaser();
        }

        _enemyGameObjects = GameObject.FindGameObjectsWithTag("Enemy");

       
        textDisplay.text = "Lives = " + _lives;
        numberOfEnemiesInScene.text = "Enemies = " + _enemyGameObjects.Length;
        
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

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + _yOffset, Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;
        
        if (_lives <= 0)
        {
            textDisplay.text = "Lives = 0";
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
