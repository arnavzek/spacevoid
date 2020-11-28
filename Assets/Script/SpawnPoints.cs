using UnityEngine;

public class SpawnPoints : MonoBehaviour {

	private Transform[] spawnPoints;

	private int spawnAmount;

	public int enemyCount;

	public float timeBetweenWave = 1;

	public Transform[] enemyPrefab;

	public Transform[] Stuffs;

	private int index;

	void Start()
	{
		spawnPoints = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			spawnPoints[i] = transform.GetChild(i);
		}

		InvokeRepeating("SpawnAtPosition" , 0, timeBetweenWave);
		InvokeRepeating("PointsAtPosition" , 5f, Random.Range(2f, 10f));
	}

	void PointsAtPosition()
	{
		index = Random.Range(0, Stuffs.Length);


		Vector3 spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

		Instantiate(Stuffs[index], spawnLocation, Quaternion.identity);
	}

	void SpawnAtPosition()
	{
		

		if (enemyCount > 1)
		{
			spawnAmount = Random.Range(0, enemyCount);
		}
		else
		{
			spawnAmount = 1;
		}

		for (int i = 0; i < spawnAmount; i++)
		{
			index = Random.Range(0, enemyPrefab.Length);

			Vector3 spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

			Instantiate(enemyPrefab[index], spawnLocation, Quaternion.identity);
		}
	}



}
