using Boo.Lang;
using System.Linq;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public GameObject[] carObjects;
    public Transform endPoint;

    public TrafficLight trafficLight;

    public bool verticalTravel;

    public float carSpawnDelay = .7f;
    public float stoppingDistance;
    public float extraStoppingDistance; //the extra stopping distance added for each car stopped in front of it

    private float _lastSpawnTime;
    private int _stoppedCars;
    private Transform _lastCar;


    // Start is called before the first frame update
    void Start()
    {
        _lastSpawnTime = Time.time;
        trafficLight.AddSpawner(this);
    }

    // Update is called once per frame
    void Update()
    {
        // has it been long enough?
        float time = Time.time;
        if(time - _lastSpawnTime > carSpawnDelay)
        {
            // break out if there are any cars too close
            if (_lastCar != null)
            {
                //Debug.Log("The newest car is " + (Vector3.Distance(lastCar.position, transform.position)).ToString() + " from me");
                if (Vector3.Distance(_lastCar.transform.position, transform.position) < extraStoppingDistance)
                {
                    return;
                }
            }

            int index = Random.Range(0, carObjects.Length);
            GameObject newCar = Instantiate(carObjects[index], transform.position, transform.rotation);
            Car newCarScript = newCar.GetComponent<Car>();
            newCarScript.spawner = this;

            // plop it into the cars list
            _lastCar = newCar.transform;

            // set last spawn time to current
            _lastSpawnTime = time;
        }
    }

    public void AddStoppedCar()
    {
        _stoppedCars++;
    }

    public void ResetStoppedCars()
    {
        _stoppedCars = 0;
    }

    public int GetStoppedCars => _stoppedCars;
}
