using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Text waveCountdownText;

    // префаб врага
    public Transform enemyPrefab;

    // префаб стартовой позиции
    public Transform spawnPoint;

    //  задержка между волнами
    public float timeBetweemWaves = 5f;

    // таймер волну
    private float countdown = 2f;

    // номер волны
    private int waveIndex = 0;

    private void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnerWave());
            countdown = timeBetweemWaves;
        }

        countdown -= Time.deltaTime;


        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }


    IEnumerator SpawnerWave()
    {
        
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy(); // создаем врага

            yield return new WaitForSeconds(0.25f); // делаем паузу перед новой итерацией цикла
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

}
