using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public GameObject SpawnItem;
    public Transform endPoint;

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if(time - lastSpawnTime > 2)
        {
            GameObject newCar = Instantiate(SpawnItem, transform.position, transform.rotation);
            newCar.GetComponent<Car>().endPoint = endPoint;
            lastSpawnTime = time;
        }
    }
}
