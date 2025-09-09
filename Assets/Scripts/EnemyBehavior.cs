using UnityEditor.SearchService;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D body;
    public Transform PlayerPosition;
    public float MoveSpeed;
    //int MaxDist = 10;
    private int MinDist = 0;

    private Collider2D HitBoxCollider;
    public GameObject GameManager;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
       Player = GameObject.FindGameObjectWithTag("Player");
       PlayerPosition = Player.transform;
       GameManager = GameObject.FindGameObjectWithTag("GameManager");
       HitBoxCollider = GetComponent<Collider2D>();
    }

    public void FixedUpdate()
    {
        float dist = Vector2.Distance(PlayerPosition.position, transform.position);
        if (dist >= MinDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, MoveSpeed * Time.fixedDeltaTime);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<PlayerStats>().TakeDamage(1);
        Debug.Log("OUCH");
    }
}
