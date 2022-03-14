using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem // different pools, it´s a godanm pool party in here
{
    public GameObject pooledObject;
    public float amountOfObjects;
}

public class ObjectPooling : MonoBehaviour
{
    public List<ObjectPoolItem> itemsToPool; // each object in each of the pool
    public List<GameObject> AllpoolingObjects; // all objects in all pools

    void Start()
    {
        AllpoolingObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountOfObjects; i++) // the amount too spawn declared for each pool
            {
                GameObject g = Instantiate(item.pooledObject); // each pool has it´s own specifik object it´s drawing from
                g.SetActive(false);
                AllpoolingObjects.Add(g);
            }
        }
    }

    public GameObject GetObject(Vector3 pos, Quaternion rot, string tag)
    {   
        foreach (GameObject item in AllpoolingObjects)
        {
            if (!item.activeInHierarchy && item.CompareTag(tag))
            {
                item.transform.position = pos;
                item.transform.rotation = rot;
                item.SetActive(true);
                return item;                      //break; Return exits out so if the func has a return value no need for break
            }
        }
        foreach (ObjectPoolItem item in itemsToPool) // if in need of more objects in the pool. The pool is not crowded enough ^^
        {
            if (item.pooledObject.CompareTag(tag))
            {
                GameObject g = Instantiate(item.pooledObject);
                g.SetActive(false);
                AllpoolingObjects.Add(g);
                return g;
            }
        }
        return null;
    }
}
