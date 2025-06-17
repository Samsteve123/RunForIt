using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Equipment currentDash;

    public DashEquipment dashToEquip;
    
    public DashEquipment equippedDash;

    void Start()
    {
        GetComponent<EquipmentManager>().EquipDash(dashToEquip);
    }

    public void Equip(Equipment newEquipment)
    {
        if (newEquipment is DashEquipment)
        {
            currentDash?.Unequip(gameObject);
            currentDash = newEquipment;
            currentDash.Equip(gameObject);
        }

    }

      public void EquipDash(DashEquipment newDash)
    {
        if (equippedDash != null)
        {
            equippedDash.Unequip(gameObject);
        }

        equippedDash = newDash;
        equippedDash.Equip(gameObject);
    }

}