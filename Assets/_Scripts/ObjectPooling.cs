using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool 
    {
        public GameObject prefab;
        public int size;
    }
    public Pool[] pools;
    private Dictionary<GameObject,Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    
    void Start()
    {
        foreach (var pool in pools)
        {
            Queue<GameObject> objQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objQueue.Enqueue(obj);
            }
            poolDictionary.Add(pool.prefab,objQueue);
        }
        
    }

    
    void Update()
    {
        
    }

    public GameObject GetObject(GameObject prefab)
    {
        if (poolDictionary.ContainsKey(prefab) && poolDictionary[prefab].Count > 0)
        {
            GameObject obj = poolDictionary[prefab].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject prefab, GameObject obj)
    {
        obj.SetActive(false);
        if (poolDictionary.ContainsKey(prefab) && poolDictionary[prefab].Count < pools[1].size)
        {
            poolDictionary[prefab].Enqueue(obj);
        }
    }
    
}
