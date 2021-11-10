using UnityEngine;

namespace ColorBump.ColorChanger
{
    public class PlayerColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _playerColor;
        public Material PlayerColor { get => _playerColor; set => _playerColor = value; }
        EnemyColorChanger _enemyColor;

        private void Start()
        {
            _enemyColor = GetComponent<EnemyColorChanger>();
            PlayerColor.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
            while (PlayerColor.color == _enemyColor.EnemyColor.color)
                PlayerColor.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));


        }


    }
}
