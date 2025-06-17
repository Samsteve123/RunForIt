using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

[CreateAssetMenu(fileName = "NewDash", menuName = "Equipment/Dash Equipment")]
public class DashEquipment : Equipment
{
    public float speedMultiplier = 1f;
    public float dashMultiplier = 2f;

    public override void Equip(GameObject player)
    {
        var stats = player.GetComponent<PlayerStats>();
        var movement = player.GetComponent<Movement>();
        movement.hasDash = true;
        stats.MoveSpeed *= speedMultiplier;
        stats.DashSpeed *= dashMultiplier;
    }

    public override void Unequip(GameObject player)
    {
        var stats = player.GetComponent<PlayerStats>();
        var movement = player.GetComponent<Movement>();
        movement.hasDash = false;
        stats.MoveSpeed = stats.BaseMoveSpeed;
        stats.DashSpeed = stats.BaseDashSpeed;
    }
}