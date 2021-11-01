using ColorBump.Camera;
using UnityEngine;


namespace ColorBump.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _sensitivity = 0.16f;
        [SerializeField] private float MovementRadius = 42f;

        [Header("Bounds: ")]
        [SerializeField] private Transform _leftBound;
        [SerializeField] private Transform _rightBound;
        private Vector3 _lastMousePosition;
        private Rigidbody _rigidbody;
        private const int _velocityLimiter = 5;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            GetXMovementRestriction();
            GetMovementSpeedUpFromCamera();
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
                _lastMousePosition = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                Vector3 radiusOffSet = Vector3.ClampMagnitude(GetPointsDistanceCalculation(_lastMousePosition), MovementRadius);
                _rigidbody.AddForce(-radiusOffSet * _sensitivity - _rigidbody.velocity / _velocityLimiter, ForceMode.VelocityChange);
            }
            _rigidbody.velocity.Normalize();
        }


        ///<summary>
        /// The method calculates the distance between the game object and the clicked point on the screen.
        ///</summary>
        private Vector3 GetPointsDistanceCalculation(Vector3 position)
        {
            Vector3 pointsDistance = position - Input.mousePosition;
            _lastMousePosition = Input.mousePosition;
            pointsDistance = new Vector3(pointsDistance.x, 0, pointsDistance.y);
            return pointsDistance;
        }

        ///<summary>
        /// The method limits the range of motion of the game object, determined by the minimum and maximum values along the X axis.
        ///</summary>
        private Vector3 GetXMovementRestriction()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftBound.position.x, _rightBound.position.x), transform.position.y, transform.position.z);
            return transform.position;
        }

        ///<summary>
        /// The method takes speed for gameObject from the Camera speed movement.
        ///</summary>
        private Vector3 GetMovementSpeedUpFromCamera()
        {
            transform.position += CameraMovement.Instance.CameraDisplacement;
            return transform.position;
        }



    }
}


