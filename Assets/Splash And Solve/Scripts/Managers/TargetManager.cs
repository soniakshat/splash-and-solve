using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    enum TargetType
    {
        Static,
        Moving
    }

    public class TargetManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private Target prefabTarget;
        [SerializeField] private TargetType targetType;
        private List<Target> targets = new List<Target>();
        

        private void Awake()
        {
            foreach (var sp in spawnPoints)
            {
                sp.position += Vector3.up * 2;
            }
        }

        public List<Target> SetStaticTargets()
        {
            List<Transform> selectedTransforms = spawnPoints.GetRandomElements(4);

            if (targets.Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    Target tar = Instantiate(prefabTarget, selectedTransforms[i]);
                    targets.Add(tar);
                }
            }

            for (int i = 0; i < 4; i++)
            {
                targets[i].transform.position = selectedTransforms[i].position;
            }

            return targets;
        }

        public void RemoveStaticTargets()
        {
            if (targets.Count == 0)
            {
                return;
            }
            targets.Clear();
        }
    }
}