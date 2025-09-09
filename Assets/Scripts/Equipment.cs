using UnityEngine;

public abstract class Equipment : ScriptableObject
{
    public string equipmentName;
    public Sprite icon;

    public abstract void Equip(GameObject player);
    public abstract void Unequip(GameObject player);
}
