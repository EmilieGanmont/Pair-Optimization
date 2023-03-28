using UnityEngine;

public class SpawnpointController : MonoBehaviour
{
    public Transform[] respawnPoints;

    private void Update()
    {
        GameObject toy = ToyObjectPool.SharedInstance.GetPooledObject();

        if(toy != null)
        {
            RespawnToy(toy);
            toy.SetActive(true);
        }
    }

    public void RespawnToy(GameObject toy)
    {
        int randSpawnPoint = Random.Range(0, respawnPoints.Length);
        toy.transform.position = respawnPoints[randSpawnPoint].position;
    }
}
