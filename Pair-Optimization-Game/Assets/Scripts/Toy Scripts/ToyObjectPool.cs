using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyObjectPool : MonoBehaviour
{
    public static ToyObjectPool SharedInstance;
    public List<GameObject> pooledObjects;


    public GameObject objectToPool;
    public GameObject coinToPool; 

    public int amountToPool;
    public int coinAmountToPool;


    public Transform[] respawnPoints;


    private void Awake()
    {
        SharedInstance = this; 
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tempToy;

        for (int i = 0; i < coinAmountToPool; i++) //Initial spawn of toys
        {

            int randSpawnPoint = Random.Range(0, respawnPoints.Length);
            new WaitForSeconds(1);
            tempToy = Instantiate(coinToPool, respawnPoints[randSpawnPoint].transform.position, Quaternion.identity);
            tempToy.SetActive(true);
            pooledObjects.Add(tempToy);
        }

        for (int i =0; i< amountToPool; i++) //Initial spawn of coins
        {

            int randSpawnPoint = Random.Range(0, respawnPoints.Length);
            new WaitForSeconds(1);
            tempToy = Instantiate(objectToPool, respawnPoints[randSpawnPoint].transform.position, Quaternion.identity);
            tempToy.SetActive(true);
            pooledObjects.Add(tempToy);
        }
    }

    
    public GameObject GetPooledObject()
    {
        for(int i=0; i< amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

}
