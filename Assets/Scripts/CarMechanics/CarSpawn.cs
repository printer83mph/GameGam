using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public int MaximumCars;

    int totalCars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalCars < MaximumCars)
        {
            newCar = Instantiate(Car);
            WaitForSeconds(5);
        }
        
    }
}
