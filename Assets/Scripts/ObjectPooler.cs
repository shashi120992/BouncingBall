using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<int, Queue<GameObject>> poolDictionary;
    [System.Serializable]
    public class pool
    {
        public string tag;
        public int tagNo;
        public GameObject preFab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<pool> pools;

    private void Start()
    {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();
        foreach(pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i< pool.size; i++)
            {
                GameObject obj =  Instantiate(pool.preFab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tagNo, objectPool);
        }
    }

    public GameObject spawnFromPool(int tagNo, Vector3 pos, Quaternion rotation) 
    {
        if (!poolDictionary.ContainsKey(tagNo))
        {
            Debug.LogWarning("Pool With TagNo" + tag + "does'nt exist");
            return null; 
        }
        
        GameObject objectToSpawn = poolDictionary[tagNo].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rotation;

        //IobjectPooler pooledObject = objectToSpawn.GetComponent<IobjectPooler>();

        //if(pooledObject != null)
        //{
          //  pooledObject.onObjectSpawn();
       // }

        poolDictionary[tagNo].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
