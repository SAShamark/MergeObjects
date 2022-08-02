using System.Collections;
using Object;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private ObjectExample _gameObject;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;
    private Vector3 _startPointPosition;

    private void Start()
    {
        _startPointPosition = _spawnPoint.position;
        StartCoroutine(Spawn(10));
    }

    private IEnumerator Spawn(int objectCount)
    {
        for (int i = 0; i < objectCount; i++)
        {
            var objectExample = Instantiate(_gameObject, _spawnPoint);
            objectExample.transform.SetParent(_container);
            ChangeSpawnPosition();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ChangeSpawnPosition()
    {
        if (_spawnPoint.position.x > -4 && _spawnPoint.position.x < 4 &&
            _spawnPoint.position.y > 1 && _spawnPoint.position.y < 13.5f)
        {
            var position = _spawnPoint.position;
            position = new Vector3(position.x + Random.Range(-1, 1), position.y, position.z + Random.Range(-1, 1));
            _spawnPoint.position = position;
        }
        else
        {
            _spawnPoint.position = _startPointPosition;
        }
    }
}