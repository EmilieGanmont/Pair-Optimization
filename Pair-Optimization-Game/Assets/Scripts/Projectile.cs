using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    //Note: Set up object pooling here later -Emilie
    

    private Rigidbody2D rg2D;
    [SerializeField] private float speed = 1f;

    [SerializeField] private float lifespan = 2f;

    void Start()
    {
        rg2D = GetComponent<Rigidbody2D>();
        
        StartCoroutine(SelfDestruct());
    }
    void FixedUpdate()
    {
        rg2D.AddForce(transform.up * speed);

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
