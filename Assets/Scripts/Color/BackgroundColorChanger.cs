using UnityEngine;

namespace ColorBump.ColorChanger
{
    public class BackgroundColorChanger : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _background;
        PlayerColorChanger _player;
        private void Start()
        {
            _player = GetComponent<PlayerColorChanger>();
            _background.GetComponent<SpriteRenderer>().color = _player.PlayerColor.color;
        }
    }
}
