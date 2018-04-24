using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    private int _nextWave;

    private float _searchCountdown = 1f;

    private SpawnState _state = SpawnState.Counting;
    private float _waveCountdown;
    public Transform[] SpawnPoints;
    public float TimeBetweenWaves = 5;

    [SerializeField] private Canvas NewRoundCnvas;


    public Wave[] Waves;

    private void Start()
    {
        if (SpawnPoints.Length == 0) Debug.LogError("No Spawn Points");

        _waveCountdown = TimeBetweenWaves;
    }

    private void Update()
    {
        if (_state == SpawnState.Waiting)
            if (!EnemyIsAlive())
                WaveCompleted();
            else
                return;

        if (_waveCountdown <= 0)
        {
            if (_state != SpawnState.Spawning)
                StartCoroutine(SpawnWave(Waves[_nextWave]));
        }
        else
        {
            _waveCountdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        _state = SpawnState.Spawning;

        for (var i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1f / wave.SpawnRate);
        }

        _state = SpawnState.Waiting;
    }

    private void WaveCompleted()
    {

        _state = SpawnState.Counting;

        _waveCountdown = TimeBetweenWaves;

        if (_nextWave + 1 > Waves.Length - 1)
        {
            _nextWave = 0;
            NewRoundCnvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
            
        else
            _nextWave++;
    }

    private bool EnemyIsAlive()
    {
        _searchCountdown -= Time.deltaTime;

        if (!(_searchCountdown <= 0)) return true;
        _searchCountdown = 1;

        return GameObject.FindGameObjectWithTag("Enemy") != null;
    }

    private void SpawnEnemy(Transform enemy)
    {
        var sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }

    [Serializable]
    public class Wave
    {
        public int Count;
        public Transform Enemy;
        public string Name;
        public float SpawnRate;
    }

    private enum SpawnState
    {
        Spawning,
        Waiting,
        Counting
    }
}