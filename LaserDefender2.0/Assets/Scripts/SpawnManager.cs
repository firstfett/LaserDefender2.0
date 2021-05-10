using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private int _numberOfEnemies = 5;
    [SerializeField]
    private float _spawnTime = 3.0f;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_numberOfEnemies > 0 && _stopSpawning == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9, 9), 8, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.AngleAxis(45f, Vector3.forward));
            newEnemy.transform.parent = _enemyContainer.transform;
            _numberOfEnemies--;
            yield return new WaitForSeconds(_spawnTime);
        }
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
