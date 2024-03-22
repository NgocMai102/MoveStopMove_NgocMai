using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Skin.Data
{
    public class SkinDataSO <T>: ScriptableObject
    {
        [SerializeField] private List<T> prefabs = new List<T>();

        public T GetSkin(int index)
        {
            return prefabs[index];
        }

    }
}
