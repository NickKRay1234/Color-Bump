using UnityEngine;
using ColorBump.Player;

namespace ColorBump.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 7f;
        public static CameraMovement Instance { get; private set; }
        private Vector3 _cameraDisplacement;
        public Vector3 CameraDisplacement { get { return _cameraDisplacement; } }

        private void Awake()
        {
            if (Instance != null) // Singleton
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            if (PlayerController.Instance.CanMove)
                transform.position += Vector3.forward * _cameraSpeed * Time.deltaTime;
            _cameraDisplacement = Vector3.forward * _cameraSpeed * Time.deltaTime;
        }
    }
}
