using UnityEngine;
using ColorBump.Player;

namespace ColorBump.ObjectsMovement
{
    public class XaxisMovement : MonoBehaviour
    {
        [SerializeField] private float _speed, _distance;
        [SerializeField] private bool _right, _dontMove;
        private float _minX, _maxX;
        private bool _stop;

        private void Start()
        {
            _maxX = transform.position.x + _distance;
            _minX = transform.position.x - _distance;
        }



        private void Update()
        {
            if(!_stop && !_dontMove)
            {
                if(_right)
                {
                    transform.position += Vector3.right * _speed * Time.deltaTime;
                    transform.Rotate(0.0f, 2.5f, 0.0f, Space.World);
                    if(transform.position.x >= _maxX)
                    _right = false;
                }
                else
                {
                    transform.position += Vector3.left * _speed * Time.deltaTime;
                    transform.Rotate(0.0f, -2.5f, 0.0f, Space.World);
                    if(transform.position.x <= _minX)
                    _right = true;
                }
            }
        }

        private void OnCollisionEnter(Collision target) 
        {
            if(target.gameObject == PlayerController.Instance.gameObject)
            {
                _stop = true;
                GetComponent<Rigidbody>().freezeRotation = false;
            }
        }
    }
}

