using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public delegate void ClickDelegate();

    public ClickDelegate onClickDelegate;

    // Start is called before the first frame update
    void Start()
    {
        // give it our own method first (to avoid null pointer exception)
        onClickDelegate += OnClick;
    }

    private void OnMouseDown()
    {
        onClickDelegate();
    }

    void OnClick()
    {
        // keep track of last click?? idk
    }

}
