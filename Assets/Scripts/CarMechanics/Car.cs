using UnityEngine;

public class Car : MonoBehaviour
{

    public Transform endPoint;

    public GameObject trafficLight;

    public float stoppingDistance;
    public float extraStoppingDistance;

    public bool isVertical;
    public float speed = 10f;

    private bool _passedTheLight;
    private bool _stoppedAtLight;

    // Start is called before the first frame update
    void Start()
    {
        _passedTheLight = false;
        _stoppedAtLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        TrafficLight tlScript = trafficLight.GetComponent<TrafficLight>();
        if (Vector3.Distance(transform.position, trafficLight.transform.position) <= stoppingDistance && !_passedTheLight)
        {
            if(tlScript.allowVertical == isVertical) //if the traffic light currently will let this car pass
            {
                _passedTheLight = true;
            }
        }
        if (Vector3.Distance(transform.position, trafficLight.transform.position) > stoppingDistance + tlScript.getStoppedCars() * extraStoppingDistance || _passedTheLight) //this time also checking if there are stopped cars to look out for
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
            _stoppedAtLight = false;
        } else
        {
            if (!_stoppedAtLight)
            {
                _stoppedAtLight = true;
                tlScript.addStoppedCar();
            }
        }
        if (transform.position == endPoint.position)
        {
            Destroy(gameObject);
        }

    }
}
