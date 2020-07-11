using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Transform endPoint;

    public GameObject trafficLight;

    public float stoppingDistance;
    public float extraStoppingDistance;

    public bool isVertical;

    private float speed;

    private bool passedTheLight;
    private bool stoppedAtLight;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        passedTheLight = false;
        stoppedAtLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        TrafficLight tlScript = trafficLight.GetComponent<TrafficLight>();
        if (Vector3.Distance(transform.position, trafficLight.transform.position) <= stoppingDistance && !passedTheLight)
        {
            if(tlScript.allowVertical == isVertical) //if the traffic light currently will let this car pass
            {
                passedTheLight = true;
            }
        }
        if (Vector3.Distance(transform.position, trafficLight.transform.position) > stoppingDistance + tlScript.getStoppedCars() * extraStoppingDistance || passedTheLight) //this time also checking if there are stopped cars to look out for
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
            stoppedAtLight = false;
        } else
        {
            if (!stoppedAtLight)
            {
                stoppedAtLight = true;
                tlScript.addStoppedCar();
            }
        }
        if (transform.position == endPoint.position)
        {
            Destroy(gameObject);
        }

    }
}
