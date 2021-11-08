using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using ColorBump.GameManager;

namespace ColorBump.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class LosingMechanic : MonoBehaviour
    {
        private bool _gameOver = false;
        [SerializeField] private Material[] _materials;
        PlayerController _player;
        ScenesTransition _levelUp;

        private void Awake()
        {
            _levelUp = GetComponent<ScenesTransition>();
            _player = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_player.CanMove && _gameOver) ReloadLevel();
                else if (!_player.CanMove && !_levelUp.Finish) 
                {
                    GameManager.Instance.RemoveUI();
                    _player.CanMove = true;
                }
            }
        }

        private void ReloadLevel()
        {
            _gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnCollisionEnter(Collision target)
        {
            for (int i = 0; i < _materials.Length; i++)
            {
                if (target.gameObject.GetComponent<MeshRenderer>().material.color == _materials[i].color)
                    GameOver();
            }
        }

        private void GameOver()
        {
            _player.CanMove = false;
            _gameOver = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }
}
