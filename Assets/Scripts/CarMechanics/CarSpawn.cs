using Boo.Lang;
using System.Linq;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public GameObject[] spawnItems;
    public Transform endPoint;

    public TrafficLight trafficLight;

    public bool verticalTravel;

    public float carSpawnDelay = .7f;
    public float stoppingDistance;
    public float extraStoppingDistance; //the extra stopping distance added for each car stopped in front of it

    private float lastSpawnTime;
    private Transform lastCar;


    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // has it been long enough?
        float time = Time.time;
        if(time - lastSpawnTime > carSpawnDelay)
        {
            // break out if there are any cars too close
            if (lastCar != null)
            {
                //Debug.Log("The newest car is " + (Vector3.Distance(lastCar.position, transform.position)).ToString() + " from me");
                if (Vector3.Distance(lastCar.transform.position, transform.position) < extraStoppingDistance)
                {
                    return;
                }
            }

            int index = Random.Range(0, spawnItems.Length);
            GameObject newCar = Instantiate(spawnItems[index], transform.position, transform.rotation);
            Car newCarScript = newCar.GetComponent<Car>();
            newCarScript.spawner = this;

            // plop it into the cars list
            lastCar = newCar.transform;

            // set last spawn time to current
            lastSpawnTime = time;
        }
    }
}
