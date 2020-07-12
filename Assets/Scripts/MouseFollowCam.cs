using UnityEngine;

public class MouseFollowCam : MonoBehaviour
{

    public float trackInfluence;

    private Quaternion _initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        _initialRotation = transform.localRotation;
    }

    private void Update()
    {
        float mouseX = (Input.mousePosition.x / Screen.width - .5f) * trackInfluence;
        float mouseY = (Input.mousePosition.y / Screen.height - .5f) * trackInfluence;
        Quaternion desiredRotationAddition = Quaternion.Euler(-mouseY, mouseX, 0);

        transform.localRotation = _initialRotation * desiredRotationAddition;
    }

}
