using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class TargetManager : MonoBehaviour
    {
        [SerializeField] List<Transform> spawnPoints;
        [SerializeField] Target prefabTarget;
        List<Target> targets = new List<Target>();

        private void Awake()
        {
            foreach (var sp in spawnPoints)
            {
                sp.position += Vector3.up * 2;
            }
        }

        public List<Target> SetTargets()
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

        public void RemoveAllTargets()
        {
            if (targets.Count == 0)
            {
                return;
            }
            //foreach (var tar in targets)
            //{
            //    Destroy(tar.gameObject);
            //}
            targets.Clear();
        }
    }
}