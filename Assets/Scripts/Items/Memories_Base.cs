using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PlasticSCM.Editor.WebApi;

public class Memories_Base : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        GameManager.Instance.GetMemory();
    }
}
