using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject explosionObject; // Choose explosion effect.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionObject, transform.position, Quaternion.identity, transform.parent) as GameObject;
        Destroy(gameObject);
        Destroy(explosion, 1.3f);
    }
}
