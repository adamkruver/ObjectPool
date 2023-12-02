using System;
using System.Collections.Generic;
using Sources.Collectors;
using Sources.Crystals;
using UnityEngine;

public class CommandCenter
{
    public event Action<int> CollectorsCountChanged;

    private Queue<ICollectorView> _collectors = new Queue<ICollectorView>();

    public void AddCollector(ICollectorView collector)
    {
        _collectors.Enqueue(collector);

        CollectorsCountChanged?.Invoke(_collectors.Count);
    }

    public void SendCollector(ICrystalView crystal)
    {
        if(_collectors.Count == 0)
            return;
        
        ICollectorView collector = _collectors.Dequeue();
        
        collector.Collect(crystal);
        collector.SetCommandCenter(this);
        CollectorsCountChanged?.Invoke(_collectors.Count);
    }
}