using UnityEngine;

namespace ColorBump.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 7f;
        public static CameraMovement Instance { get; private set; }
        private Vector3 _cameraDisplacement;
        public Vector3 CameraDisplacement { get {return _cameraDisplacement;}}

        private void Awake() // Singleton
        {
            if(Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            transform.position += Vector3.forward * _cameraSpeed * Time.deltaTime;
            _cameraDisplacement = Vector3.forward * _cameraSpeed * Time.deltaTime;
        }
    }
}
