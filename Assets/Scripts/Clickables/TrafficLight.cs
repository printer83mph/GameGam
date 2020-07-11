using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrafficLightConfig
{
    public Animator lightAnimator;
    public bool horizontal;
}

[RequireComponent(typeof(Clickable))]
public class TrafficLight : MonoBehaviour
{

    public bool allowVertical;

    public TrafficLightCrosswalk horizontalCrosswalk;
    public TrafficLightCrosswalk verticalCrosswalk;
    public TrafficLightConfig[] lightConfig;

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
        foreach (TrafficLightConfig config in lightConfig)
        {
            if (config.horizontal ^ allowVertical)
                config.lightAnimator.SetBool("green", !config.lightAnimator.GetBool("green"));
        }
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
        foreach (TrafficLightConfig config in lightConfig)
        {
            config.lightAnimator.SetBool("green", !config.lightAnimator.GetBool("green"));
        }
        Debug.Log(allowVertical ? "Now Vertical" : "Now Horizontal");
    }

}
