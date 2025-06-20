using System.ComponentModel;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int MaxHealth = 10;
    public int CurrentHealth = 10;
    public float BaseMoveSpeed = 30f;
    public float BaseDashSpeed = 0f;

    public float MoveSpeed { get; set; }
    public float DashSpeed { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxHealth = 10;
        CurrentHealth = 10;
        MoveSpeed = BaseMoveSpeed;
        DashSpeed = BaseDashSpeed;
    }

}
