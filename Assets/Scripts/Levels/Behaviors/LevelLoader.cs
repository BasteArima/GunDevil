using Levels.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Levels.Behaviors
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerMovement _player;
        [SerializeField] private TMP_Text _levelNameLabel;
        [SerializeField] private Transform _levelGrid;
        
        private Tilemap _currentLevel;
        private int _currentTilemapIndex;

        public Color CurrentForegroundColor { get; private set; }

        private void Start()
        {
            SwitchLevel(0);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (_currentTilemapIndex == _levels.Length - 1)
                    _currentTilemapIndex = 0;
                else
                    _currentTilemapIndex++;
                
                SwitchLevel(_currentTilemapIndex);
            }
        }
        
        private void SwitchLevel(int index)
        {
            var newSceneData = _levels[index];
            SetSceneData(newSceneData);
        }
        
        private void SetSceneData(LevelData data)
        {
            if (null != _currentLevel)
                Destroy(_currentLevel.gameObject);
            
            _currentLevel = Instantiate(data.LevelTilemap.Tilemap, _levelGrid);
            
            _camera.backgroundColor = data.BackgroundColor;
            _currentLevel.color = data.ForegroundColor;
            CurrentForegroundColor = data.ForegroundColor;
            _levelNameLabel.text = data.Id;

            _player.transform.position = data.LevelTilemap.SpawnPoints.Length > 0 ? data.LevelTilemap.SpawnPoints[0].position : spawnPoint.position;
        }
    }
}