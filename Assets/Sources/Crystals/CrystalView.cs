using Sources.Collectors;
using UnityEngine;

namespace Sources.Crystals
{
    public class CrystalView : MonoBehaviour ,ICrystalView
    {
        public Vector3 Position => transform.position;
        
        public void SetPosition(Vector3 position) => 
            transform.position = position;

        public void Destroy()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);
                
                return;
            }
            
            poolableObject.ReturnToPool();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}