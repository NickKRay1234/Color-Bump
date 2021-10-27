using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 lastMousePos;
    public float sensitivity = 0.16f, clampDelta = 42f;
    public float bounds = 5;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);


            Vector3 moverForce = Vector3.ClampMagnitude(-vector clampDelta);
        }
    }

    




}
