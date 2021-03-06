﻿using UnityEngine;

public class Car : MonoBehaviour
{
    public CarSpawn spawner;
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
        if (_passedTheLight)
        {
            MoveTowardsEnd();
            CheckDespawn();
            return;
        }

        // if light is green
        if (LightAllowsTravel())
        {
            _stoppedAtLight = false;
            // if close enough to traffic light
            if (Vector3.Distance(transform.position, spawner.trafficLight.transform.position) < spawner.stoppingDistance)
            {
                // we've passed the light
                _passedTheLight = true;
                MoveTowardsEnd();
            } else
            {
                MoveTowardsEnd();
            }
        }
        // if light is red and we're not past the light
        else
        {
            // if close enough to other stopped cars
            if (Vector3.Distance(transform.position, spawner.trafficLight.transform.position) < GetStoppedCarsDistance())
            {
                // dont move and set stopped at light to true
                if (!_stoppedAtLight)
                {
                    _stoppedAtLight = true;
                    spawner.AddStoppedCar();
                }
            }
            // if we're not there yet
            else
            {
                MoveTowardsEnd();
            }
        }

    }

    float GetStoppedCarsDistance() => spawner.stoppingDistance + spawner.GetStoppedCars * spawner.extraStoppingDistance;

    private bool LightAllowsTravel()
    {
        return ( spawner.trafficLight.inYellow() ? false : spawner.trafficLight.allowVertical == spawner.verticalTravel);
    }
    void MoveTowardsEnd()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawner.endPoint.position, speed * Time.deltaTime);
    }
    void CheckDespawn()
    {
        // despawn if at end
        if (transform.position == spawner.endPoint.position)
        {
            Destroy(gameObject);
        }
    }
}
