using UnityEngine;

namespace Sources.Crystals
{
    public interface ICrystalView
    {
        Vector3 Position { get; }
        
        void Destroy();
    }
}