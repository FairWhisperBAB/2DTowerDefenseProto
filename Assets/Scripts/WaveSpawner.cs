using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Transform enemyPrefab;

    public float timeBetweenWaves = 5f;
    private float countDown = 5f;
    public float spawnInterval = 0.5f;

    [SerializeField] private TextMeshProUGUI waveCountdownTxt;

    [SerializeField] private TextMeshProUGUI waveCounterTxt;

    private int waveIndex = 0;

    private void Update()
    {
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);

        waveCountdownTxt.text = string.Format("{0:00.00}", countDown);

        waveCounterTxt.text = "Wave: " + GameStats.waves.ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        GameStats.waves++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
