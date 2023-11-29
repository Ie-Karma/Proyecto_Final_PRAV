using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] enemyPrefabs; // Prefabs de los enemigos
	public Player player;
	public int maxDelay = 5;
	public int minDelay = 1;

	private void Start()
	{
		StartCoroutine(SpawnEnemies());
	}

	private IEnumerator SpawnEnemies()
	{
		while (true)
		{
			int playerLevel = player.level;
			int numEnemies = Mathf.Clamp(playerLevel, 1, 5);
			float spawnDelay = Mathf.Max(maxDelay - playerLevel, minDelay);

			for (int i = 0; i < numEnemies; i++)
			{
				Transform spawnPoint = GetRandomSpawnPoint();
				GameObject enemyPrefab = GetRandomEnemyPrefab();

				// Spawnear el enemigo en el punto de spawn
				Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
			}

			yield return new WaitForSeconds(spawnDelay);
		}
	}

	private Transform GetRandomSpawnPoint()
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);
		return spawnPoints[randomIndex];
	}

	private GameObject GetRandomEnemyPrefab()
	{
		// Obtener un prefab de enemigo aleatorio del array
		int randomIndex = Random.Range(0, enemyPrefabs.Length);
		return enemyPrefabs[randomIndex];
	}
}
