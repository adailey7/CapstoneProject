using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 1f;
    private float lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
