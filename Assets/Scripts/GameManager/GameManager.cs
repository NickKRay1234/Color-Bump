using UnityEngine;
using UnityEngine.UI;

namespace ColorBump.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _player, _finish, _handClickSprite;
        [SerializeField] private Text _currentLevelText, _nextLevelText;
        public static GameManager Instance { get; private set; }
        [SerializeField] private TextMesh _levelNumber;
        private float _startDistance, _updateDistance;
        [SerializeField] private Image _fill;
        private int _level;

        private void Awake()
        {
            if (Instance != null) // Singleton
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            LevelbarTextChanging();
            _startDistance = DistanceBetweenPlayerAndFinish();
        }

        private void LevelbarTextChanging()
        {
            _level = PlayerPrefs.GetInt("Level");
            _levelNumber.text = "Level " + _level;
            _nextLevelText.text = _level + 1 + "";
            _currentLevelText.text = _level + "";
        }

        private float DistanceBetweenPlayerAndFinish()
        {
            return Vector3.Distance(_player.transform.position, _finish.transform.position);
        }

        private void Update()
        {
            _updateDistance = DistanceBetweenPlayerAndFinish();
            if (_player.transform.position.z < _finish.transform.position.z)
                _fill.fillAmount = 1 - (_updateDistance / _startDistance);
        }

        public void RemoveUI()
        {
            _handClickSprite.SetActive(false);
        }
    }
}
