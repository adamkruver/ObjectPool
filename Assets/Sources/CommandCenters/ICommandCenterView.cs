using Sources.Crystals;
using UnityEngine;

namespace Sources.CommandCenters
{
    public interface ICommandCenterView
    {
        ICollectorViewFactory CollectorFactory { get; }

        Vector3 Position { get; }
        ICrystalView[] Targets { get; }
    }
}