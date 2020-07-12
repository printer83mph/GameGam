using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class LightTransitioner : MonoBehaviour
{
    public bool spherecast = true;
    public Transform mainCamera;
    RaycastHit hit;

    private ColorAdjustments _colorAdjustments;

    void Start()
    {
        Volume volume = gameObject.GetComponent<Volume>();
        _colorAdjustments = gameObject.GetComponent<ColorAdjustments>();
        Debug.Log(_colorAdjustments.colorFilter);
    }
    void Update()
    {
        if (spherecast)
        {
            if (Physics.SphereCast(mainCamera.position, 0.1f, mainCamera.forward, out hit, 10f))
            {

            }
        }
    }
}