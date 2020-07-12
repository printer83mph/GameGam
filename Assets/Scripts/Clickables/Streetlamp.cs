using UnityEngine;

public class Streetlamp : MonoBehaviour
{
    public bool flicked;
    public ToggleableLight[] lights;
    public Material onMaterial;
    public Material offMaterial;

    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        GetComponent<Clickable>().onClickDelegate += OnClick;
        UpdateMaterials();
    }

    void OnClick()
    {
        flicked = !flicked;
        UpdateMaterials();
        foreach (ToggleableLight l in lights)
        {
            l.ToggleLit();
        }
    }

    void UpdateMaterials()
    {
        Material[] matArray = _meshRenderer.materials;
        matArray[1] = flicked ? onMaterial : offMaterial;
        _meshRenderer.materials = matArray;
    }
}
