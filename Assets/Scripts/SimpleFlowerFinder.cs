using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlowerFinder : MonoBehaviour
{
    Rigidbody rb;
    public float speed ;
    public int x = 0;

    void Awake()
    {
    speed = Random.Range(0.75f, 1.5f);
    rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(x == 0)
        {
            FindClosestHive();
        }
        else
        {
            FindClosestFlower();
        }
    }

    void FindClosestFlower()
    {
        float distanceToClosestFlower = Mathf.Infinity;
        Flower closestFlower = null;
        Flower[] allFlowers = GameObject.FindObjectsOfType<Flower>();

        foreach (Flower currentFlower in allFlowers)
        {
            float distanceToFlower = (currentFlower.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToFlower < distanceToClosestFlower)
            {
                distanceToClosestFlower = distanceToFlower;
                closestFlower = currentFlower;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, closestFlower.transform.position, speed * Time.deltaTime);
    }

    void FindClosestHive()
    {
        float distanceToClosestHive = Mathf.Infinity;
        Hive closestHive = null;
        Hive[] allHives = GameObject.FindObjectsOfType<Hive>();

        foreach (Hive currentHive in allHives)
        {
            float distanceToHive = (currentHive.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToHive < distanceToClosestHive)
            {
                distanceToClosestHive = distanceToHive;
                closestHive = currentHive;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, closestHive.transform.position, speed * Time.deltaTime);
    }



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Hive")
        {
        x++;
        }

        if (collider.gameObject.tag == "Flower")
        {
        x--;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("hitxD");
        rb.AddForce(transform.right * 20f);
        }
    }


}
