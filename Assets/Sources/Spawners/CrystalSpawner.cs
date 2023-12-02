using System;
using Cysharp.Threading.Tasks;
using Sources.Crystals;
using Sources.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Spawners
{
    public class CrystalSpawner : MonoBehaviour
    {
        [SerializeField] private CrystalView _prefab;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private float _spawnRadius = 5f;
        
        private IObjectPool _objectPool;
        private CrystalViewFactory _factory;

        private void Awake()
        {
            _objectPool = new ObjectPool<CrystalView>();
            _factory = new CrystalViewFactory(_prefab, _objectPool);
        }

        private async void Start()
        {
            while (true)
            {
                Spawn();    
                await UniTask.Delay(TimeSpan.FromSeconds(_spawnInterval));
            }
        }

        private void Spawn()
        {
            var crystal = _objectPool.Get<CrystalView>() ?? _factory.Create();
            
            crystal.SetPosition(GetSpawnPosition());
            crystal.Show();
        }

        private Vector3 GetSpawnPosition()
        {
            float angle = Random.Range(0, 360);
            
            return transform.position + Quaternion.Euler(Vector3.up * angle)* Vector3.forward * _spawnRadius;
        }
    }
}