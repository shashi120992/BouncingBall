using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour//, IobjectPooler
{
	public GameObject platformPrefab;

	public int numberOfPlatforms = 200;
	public float levelWidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;
	ObjectPooler objectPooler;

    // Use this for initialization
    public void Start()
    {
		objectPooler = ObjectPooler.Instance;
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			int randomInt = Random.Range(1, 6);
			//Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			objectPooler.spawnFromPool(randomInt, spawnPosition, Quaternion.identity);
		}
	}
    /*
	onObjectSpawn()
	{
		objectPooler = ObjectPooler.Instance;
		Vector3 spawnPosition = new Vector3();

		for (int i = 0; i < numberOfPlatforms; i++)
		{
			spawnPosition.y += Random.Range(minY, maxY);
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			int randomInt = Random.Range(1, 6);
			//Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
			objectPooler.spawnFromPool("Blue", spawnPosition, Quaternion.identity);
		}
	}
	*/
}
