using System.Collections.Generic;
using UnityEngine;

public class dGameObjectPool
{
    public GameObject Prefab { get; set; }

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int lastUsedIndex = 0;

    public dGameObjectPool(GameObject prefab)
    {
        Prefab = prefab;
    }

    private GameObject InstantiateSingle()
    {
        var instantiate = GameObject.Instantiate(Prefab);
        instantiate.SetActive(false);
        pooledObjects.Add(instantiate);
        return instantiate;
    }

    /// <summary>
    /// instantiates a number of objects regardless of the number of pooled objects
    /// </summary>
    /// <param name="amount"></param>
    public void ForceSpawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            InstantiateSingle();
        }
    }

    /// <summary>
    /// instantiates a number of objects, but only up to a specific amount
    /// </summary>
    /// <param name="amount"></param>
    public void Ensure(int amount)
    {
        int amountToSpawn = amount - pooledObjects.Count;
        for (int i = 0; i < amountToSpawn; i++)
        {
            InstantiateSingle();
        }
    }

    /// <summary>
    /// Clears the entire pool and destroys all objects
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            GameObject.Destroy(pooledObjects[i]);
        }
        pooledObjects.Clear();
        lastUsedIndex = 0;
    }

    /// <summary>
    /// Get a single object from the pool. Spawns a new one if needed.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject Get(Vector3 position, Quaternion rotation)
    {
        GameObject obj = null;


        //NOTE(mgodskesen):do a circular loop around the object pool, starting at the index we used last time
        int i = 1;
        while (i < pooledObjects.Count)
        {
            int index = (lastUsedIndex + i) % pooledObjects.Count;

            if (pooledObjects[index] == null)
            {
                //NOTE(mgodskesen):removing might be slow as RemoveAt is O(n), but the number of objects should never be thar large.
                pooledObjects.RemoveAt(index);
                continue;
            }
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                obj = pooledObjects[index];

                //NOTE(mgodskesen):save the last used index to reduce the number of checks next time we need an object
                lastUsedIndex = index;
                break;
            }
            i++;
        }

        if (obj == null)
        {
            lastUsedIndex = 0;
            obj = InstantiateSingle();
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        return obj;
    }


}