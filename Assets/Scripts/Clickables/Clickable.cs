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

    private void OnMouseEnter()
    {
        Debug.Log("entered");
    }

    void OnMouseDown()
    {
        onClickDelegate();
    }

    void OnClick()
    {
        // keep track of last click?? idk
    }

}
