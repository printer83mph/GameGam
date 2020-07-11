using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class TrafficLight : MonoBehaviour
{

    public bool allowVertical;

    private int stoppedCars; //the number of cars currently stopped at the light
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
        stoppedCars = 0;
    }

    void OnClick()
    {
        allowVertical = !allowVertical;
        stoppedCars = 0; //previously stopped cars will now move on
        Debug.Log(allowVertical ? "Now Vertical" : "Now Horizontal");
    }

    public int getStoppedCars()
    {
        return stoppedCars;
    }

    public void addStoppedCar()
    {
        stoppedCars++;
        Debug.Log(stoppedCars);
    }

}
