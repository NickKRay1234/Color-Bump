using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ColorBump.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class ScenesTransition : MonoBehaviour
    {
        [SerializeField] private bool _finish;
        public bool Finish { get { return _finish; } set { _finish = value;} }
        [SerializeField] private GameObject _finishCollider;
        PlayerController player;

        private void Awake() => player = GetComponent<PlayerController>();

        IEnumerator LevelUp()
        {
            _finish = true;
            player.CanMove = false;
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
        }

        private void OnTriggerEnter(Collider target)
        {
            if (target.gameObject == _finishCollider)
            {
                StartCoroutine(LevelUp());
            }
        }



    }
}

