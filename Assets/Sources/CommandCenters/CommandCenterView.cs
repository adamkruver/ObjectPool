using System.Collections.Generic;
using System.Linq;
using Sources.Collectors;
using Sources.CommandCenters;
using Sources.Common;
using Sources.Crystals;
using UnityEngine;

public class CommandCenterView : PresentableView<CommandCenterPresenter>, ICommandCenterView
{
    [SerializeField] private CollectorViewFactory _collectorFactory;
    
    public ICollectorViewFactory CollectorFactory => _collectorFactory;
    
    public Vector3 Position => transform.position; 

    public ICrystalView[] Targets => FindObjectsOfType<CrystalView>().Cast<ICrystalView>().ToArray();

    public void CreateCollector() => 
        Presenter.CreateCollector();

    public void SendCollector() => 
        Presenter.SendCollector();
}