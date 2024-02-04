using UnityEngine;
using UnityEngine.Tilemaps;

namespace Levels.Scriptables
{
    [CreateAssetMenu(menuName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private Color _foregroundColor;
        [SerializeField] private LevelTilemap _levelTilemap;
        
        public string Id => _id;
        public Color BackgroundColor => _backgroundColor;
        public Color ForegroundColor => _foregroundColor;
        public LevelTilemap LevelTilemap => _levelTilemap;
    }
}