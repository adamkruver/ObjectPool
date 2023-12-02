
using Sources.Collectors;
using Sources.ObjectPool;
using Unity.VisualScripting;
using UnityEngine;

namespace Sources.Crystals
{
    public class CrystalViewFactory
    {
        private readonly CrystalView _prefab;
        private readonly IObjectPool _objectPool;

        public CrystalViewFactory(CrystalView prefab, IObjectPool objectPool)
        {
            _prefab = prefab;
            _objectPool = objectPool;
        }

        public CrystalView Create()
        {
            var view = Object.Instantiate(_prefab);
            view.AddComponent<PoolableObject>().SetPool(_objectPool);
            
            return view;
        }
    }
}