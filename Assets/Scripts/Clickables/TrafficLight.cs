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

    public float yellowDuration;
    private float _lastResetTime;
    private bool _yellow;

    private void Awake()
    {
        _spawners = new List<CarSpawn>();
        _lastResetTime = Time.time;
        _yellow = false;
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

    private void Update()
    {
        if (!_yellow) return;
        if (_lastResetTime + yellowDuration < Time.time)
        {
            _yellow = false;
        }
    }

    void OnClick()
    {
        _lastResetTime = Time.time;
        _yellow = true;

        allowVertical = !allowVertical;

        horizontalCrosswalk.changeLight();
        verticalCrosswalk.changeLight();
        foreach (TrafficLightConfig config in lightConfig)
        {
            config.lightAnimator.SetBool("green", !config.lightAnimator.GetBool("green"));
        }
        Debug.Log(allowVertical ? "Now Vertical" : "Now Horizontal");
    }

    public bool inYellow()
    {
        return  _yellow;
    }

    private void ResetStoppedCars()
    {
        foreach (CarSpawn spawner in _spawners)
        {
            spawner.ResetStoppedCars();
        }
    }

}
