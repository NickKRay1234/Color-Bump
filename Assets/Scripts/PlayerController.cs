using UnityEngine;


namespace ColorBump.Player
{

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 0.16f;
    [SerializeField] private float MovementRadius = 42f;
    [SerializeField] private float _bounds = 5f;
    private Vector3 _lastMousePosition;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)) // Returns true during the frame the user pressed the given mouse button.
        {
            _lastMousePosition = Input.mousePosition; // Input.mousePosition - reports the position of the mouse even when it is not inside the Game View.
        }

        if(Input.GetMouseButton(0)) // Returns whether the given mouse button is held down
        {
            Vector3 radiusOffSet = Vector3.ClampMagnitude( PointsDistanceCalculation(_lastMousePosition), MovementRadius ); // ClampMagnitude - returns a copy of vector with its magnitude clamped to maxLength.
            _rigidbody.AddForce(Vector3.forward * 2 + (-radiusOffSet * _sensitivity - _rigidbody.velocity / 5f), ForceMode.VelocityChange); // Add an instant velocity change to the rigidbody, ignoring its mass.
        }
    }

    private Vector3 PointsDistanceCalculation(Vector3 position)
    {
            Vector3 pointsDistance = position - Input.mousePosition;
            _lastMousePosition = Input.mousePosition;
            pointsDistance = new Vector3(pointsDistance.x, 0, pointsDistance.y);
            return pointsDistance;
    }

}
}


