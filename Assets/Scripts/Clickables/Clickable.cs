using UnityEngine;
using System.Collections;
using System.IO;

public class Clickable : MonoBehaviour
{
    public delegate void ClickDelegate();

    public ClickDelegate onClickDelegate;

    private Texture2D cursor;

    //public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {

        // give it our own method first (to avoid null pointer exception)
        onClickDelegate += OnClick;

        cursor = new Texture2D(4, 4);//filler size. loading the image with change the size

        cursor.LoadImage(File.ReadAllBytes("Assets/Cursor/cursor.png"));

    }

    private void OnMouseEnter()
    {
        //sound.enabled = true;
        //sound.Play();
        Debug.Log("here");
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
