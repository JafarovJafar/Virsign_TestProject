using System;
using System.Collections.Generic;
using Shafir.EventBus;
using Shafir.MonoPool;
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

            foreach (var spawnData in spawnDatas)
            {
                var cubik = ShafirMonoPool.Get(spawnData.Prefab);
                var finalPos = transform.position + spawnData.GoalPos;
                cubik.AppearTo(finalPos);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;

            if (spawnDatas == null)
                return;

            foreach (var spawnData in spawnDatas)
            {
                var bounds = spawnData.Prefab.Bounds;
                var finalPos = transform.position;
                finalPos += bounds.center;
                finalPos += spawnData.GoalPos;
                Gizmos.DrawWireCube(finalPos, bounds.size);
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