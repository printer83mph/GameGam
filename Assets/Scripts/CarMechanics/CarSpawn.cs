using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public GameObject spawnItem;
    public Transform endPoint;

    public GameObject trafficLight;

    public bool verticalTravel;

    public float carSpawnDelay = .7f;
    public float stoppingDistance;
    public float extraStoppingDistance; //the extra stopping distance added for each car stopped in front of it

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
        if(time - lastSpawnTime > carSpawnDelay)
        {
            GameObject newCar = Instantiate(spawnItem, transform.position, transform.rotation);
            Car newCarScript = newCar.GetComponent<Car>();
            newCarScript.endPoint = endPoint;
            newCarScript.trafficLight = trafficLight;
            newCarScript.isVertical = verticalTravel;
            newCarScript.stoppingDistance = stoppingDistance;
            newCarScript.extraStoppingDistance = extraStoppingDistance;
            lastSpawnTime = time;
        }
    }
}
