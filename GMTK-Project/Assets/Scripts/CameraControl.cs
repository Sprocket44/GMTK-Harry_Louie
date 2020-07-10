using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform cam;


    private float mouseX;
    private float mouseY;

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;

    public Vector2 smoothVelocity;

    public Vector2 mouseLook;

    public float minAngle;
    public float maxAngle;

    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        MoveCamera();
    }

    void HandleInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        Vector2 mouseDelta = new Vector2(mouseX, mouseY);
        Vector2 mouseSmooth = new Vector2(sensitivity * smoothing, sensitivity * smoothing);
        mouseDelta = Vector2.Scale(mouseDelta, mouseSmooth);

        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, mouseDelta.x, 1f / smoothing);
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, mouseDelta.y, 1f / smoothing);

        mouseLook += smoothVelocity;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minAngle, maxAngle);

    }

    void MoveCamera()
    {
        cam.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
