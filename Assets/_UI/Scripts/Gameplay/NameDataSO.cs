using System.Collections.Generic;
using UnityEngine;

namespace _UI.Scripts.Gameplay
{
    [CreateAssetMenu(fileName = "NameDataSO", menuName = "NameDataSO")]

    public class NameDataSO : ScriptableObject
    {
        [SerializeField] List<string> names = new List<string>();

        public string GetRandomName()
        {
            return names[Random.Range(0, names.Count)];
        }
    }
}

