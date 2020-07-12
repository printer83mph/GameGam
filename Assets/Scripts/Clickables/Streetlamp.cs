using UnityEngine;

public class Streetlamp : MonoBehaviour
{
    public bool flicked;
    public ToggleableLight[] lights;
    public MeshRenderer meshRenderer;
    public Material onMaterial;
    public Material offMaterial;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
        UpdateMaterials(flicked);
    }

    void OnClick()
    {
        flicked = !flicked;
        bool lightOn = false;
        foreach (ToggleableLight l in lights)
        {
            lightOn = l.ToggleLit();
        }
        UpdateMaterials(lightOn);
    }

    void UpdateMaterials(bool lightOn)
    {
        Material[] matArray = meshRenderer.materials;
        matArray[1] = lightOn ? onMaterial : offMaterial;
        meshRenderer.materials = matArray;
    }
}
