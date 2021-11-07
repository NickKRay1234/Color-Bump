using UnityEngine;

namespace ColorBump.Background
{
    public class BackgroundColorChanger : MonoBehaviour
    {
        [SerializeField] private Material _mainColor;
        [SerializeField] private Material _enemyColor;
        private Color _randomColor;
        private void Start()
        {
            _randomColor = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
            GetComponent<SpriteRenderer>().color = _randomColor;
            _mainColor.color = _randomColor;
            _enemyColor.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));

            // Colors can be identicaly.
        }
    }
}
