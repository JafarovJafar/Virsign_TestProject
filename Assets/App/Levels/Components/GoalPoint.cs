using System;
using System.Collections.Generic;
using Shafir.EventBus;
using UnityEngine;
using Zenject;

namespace Virsign
{
    public class GoalPoint : MonoBehaviour
    {
        public IReadOnlyList<SpawnData> SpawnData => spawnDatas;

        [Inject] private ShafirEventBus _eventBus;

        [SerializeField] private SpawnData[] spawnDatas;

        private void Start()
        {
            _eventBus.Publish(new GoalPointAppeared(this));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            
            foreach (var spawnData in spawnDatas)
            {
                var bounds = spawnData.Prefab.Bounds;
                Gizmos.DrawCube(bounds.center + spawnData.GoalPos, bounds.size);
            }
        }
    }

    [Serializable]
    public class SpawnData
    {
        public Cubik Prefab;
        public Vector3 GoalPos;
    }
}