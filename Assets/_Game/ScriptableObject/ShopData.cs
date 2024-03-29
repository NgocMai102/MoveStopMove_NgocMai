using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game.UI.Scripts.Shop;
using _Game.Utils;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/ShopData", order = 1)]

public class ShopData : ScriptableObject
{
    public ShopItemData<HatType> hats;
    public ShopItemData<PantsType> pants;
    public ShopItemData<AccessoryType> accessories;
    //public ShopItemDatas<SkinType> skins;
}

[System.Serializable]
public class ShopItemData<T> where T : System.Enum
{
    // [SerializeField] List<ShopItemData<T>> ts;
    // public List<ShopItemData<T>> Ts => ts;
    //
    // public ShopItemData<T> GetHat(T t)
    // {
    //     return ts.Single(q => q.type.Equals(t));
    // }
}

// [System.Serializable]
// public class ShopItemData <T> : ShopItemData where T : System.Enum 
// {
//     public T type;
// }
//
// public class ShopItemData
// {
//     public Sprite icon;
//     public int cost;
//     public int ads;
// }