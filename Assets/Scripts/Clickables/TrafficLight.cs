using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class TrafficLight : MonoBehaviour
{

    public bool allowVertical;

    public TrafficLightCrosswalk horizontalCrosswalk;
    public TrafficLightCrosswalk verticalCrosswalk;

    private List<CarSpawn> _spawners;

    private void Awake()
    {
        _spawners = new List<CarSpawn>();
    }

    public void AddSpawner(CarSpawn spawner)
    {
        _spawners.Add(spawner);
    }

    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        allowVertical = !allowVertical;
        foreach (CarSpawn spawner in _spawners)
        {
            spawner.ResetStoppedCars();
        }
        horizontalCrosswalk.changeLight();
        verticalCrosswalk.changeLight();
        Debug.Log(allowVertical ? "Now Vertical" : "Now Horizontal");
    }

}
