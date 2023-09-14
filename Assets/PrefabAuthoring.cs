using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PrefabAuthoring : MonoBehaviour
{
    public GameObject Prefab;

    public class PrefabAuthoringBaker : Baker<PrefabAuthoring>
    {
        public override void Bake(PrefabAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity,
                new PrefabComponentData { Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic) });
        }
    }
}

public struct PrefabComponentData : IComponentData
{
    public Entity Prefab;
}
