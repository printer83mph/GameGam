using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class LightSwitch : MonoBehaviour
{

    public bool flicked;
    public ToggleableLight[] lights;
    public Mesh onMesh;
    public Mesh offMesh;

    private MeshFilter _meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        GetComponent<Clickable>().onClickDelegate += OnClick;
        SetMesh();
    }

    void OnClick()
    {
        flicked = !flicked;
        SetMesh();
        foreach (ToggleableLight l in lights)
        {
            l.ToggleLit();
        }
    }

    void SetMesh()
    {
        _meshFilter.mesh = flicked ? onMesh : offMesh;
    }
}
