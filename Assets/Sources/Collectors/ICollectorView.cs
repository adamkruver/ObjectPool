
using Sources.Crystals;
using UnityEngine;

namespace Sources.Collectors
{
    public interface ICollectorView
    {
        void Destroy();
        void SetPosition(Vector3 position);
        void Collect(ICrystalView crystal);
        Vector3 Position { get; }
        void SetCommandCenter(CommandCenter commandCenter);
    }
}