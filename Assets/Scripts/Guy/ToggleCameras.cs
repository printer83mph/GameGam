using System;
using UnityEngine;

[Serializable]
public class CameraConfig
{
    public Transform cameraPos;
    public IdlePoint switchPoint;
}

[RequireComponent(typeof(GuyMovement))]
public class ToggleCameras : MonoBehaviour
{

    public CameraConfig[] camConfigs;
    public Transform _camera;

    private GuyMovement _mover;
    private Transform _targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        _mover = GetComponent<GuyMovement>();
        _targetTransform = camConfigs[0].cameraPos;
        foreach (CameraConfig i in camConfigs)
        {
            i.cameraPos.GetComponent<Camera>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_mover.isMoving())
        {
            foreach (CameraConfig config in camConfigs)
            {
                if (config.switchPoint == _mover.location) _targetTransform = config.cameraPos;
            }
        }

        _camera.position = MathUtil.Damp(_camera.position, _targetTransform.position, 3f, Time.deltaTime);
        _camera.rotation = MathUtil.Damp(_camera.rotation, _targetTransform.rotation, 2f, Time.deltaTime);
    }
}
