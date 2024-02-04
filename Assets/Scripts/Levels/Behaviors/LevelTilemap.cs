using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class LevelTilemap : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Tilemap _tilemap;

    public Transform[] SpawnPoints => _spawnPoints;
    public Tilemap Tilemap => _tilemap;

    private void OnValidate()
    {
        _tilemap = GetComponent<Tilemap>();
    }
}
