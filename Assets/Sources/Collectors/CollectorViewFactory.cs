using Sources.CommandCenters;
using Unity.VisualScripting;
using UnityEngine;

namespace Sources.Collectors
{
    public class CollectorViewFactory : MonoBehaviour, ICollectorViewFactory
    {
        [SerializeField] private CollectorView _prefab;

        public ICollectorView Create(ICommandCenterView commandCenterView, Vector3 spawnPosition)
        {
            CollectorView view = Instantiate(_prefab);
            
            view.Construct(new CollectorPresenter(view, new Collector()));
            view.SetPosition(spawnPosition);

            return view;
        }
    }
}