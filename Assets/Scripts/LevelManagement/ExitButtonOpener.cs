using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonOpener : MonoBehaviour
{

    public GameObject menu;

    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        _isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            _isActive = !_isActive;
            menu.SetActive(_isActive);
        }
    }
}
