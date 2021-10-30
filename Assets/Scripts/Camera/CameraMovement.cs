using UnityEngine;

namespace ColorBump.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 7f;
        public Vector3 camVel;


        private void Update()
        {
            transform.position += Vector3.forward * _cameraSpeed * Time.deltaTime;
            camVel = Vector3.forward * _cameraSpeed * Time.deltaTime;
        }
    }
}
