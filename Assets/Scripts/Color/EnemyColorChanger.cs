using UnityEngine;

namespace ColorBump.ColorChanger
{
    public class EnemyColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _enemyColor;

        public Material EnemyColor { get => _enemyColor; set => _enemyColor = value; }

        private void Start()
        {
            EnemyColor.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
        }
    }
}
