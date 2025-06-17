using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public Rigidbody2D body;
   public GameObject Player;
   public GameObject pauseSystem;

   float horizontal;
   float vertical;
   float moveLimiter = 0.7f;
   float MoveSpeed;

   public float dashSpeed = 30f;
   public float dashDuration = 0.2f;
   public float dashCooldown = 1f;
   public bool hasDash = false;

   private float dashTime;
   private float dashCooldownTime;
   private bool isDashing = false;
   private Vector2 dashDirection;


   private int UpperBoundX = 245;
   private int UpperBoundY = 245;
   private int LowerBoundX = -245;
   private int LowerBoundY = -245;

   void Start ()
   {
      pauseSystem = GameObject.FindGameObjectWithTag("GameManager");
      Player = GameObject.FindGameObjectWithTag("Player");
      MoveSpeed = Player.GetComponent<PlayerStats>().BaseMoveSpeed;
      body = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
      if (pauseSystem.GetComponent<PauseSystem>().GetIsPaused()){ return; }

      if (hasDash && Input.GetKeyDown(KeyCode.Space) && Time.time >= dashCooldownTime && (horizontal != 0 || vertical != 0))
      {
         isDashing = true;
         dashTime = Time.time + dashDuration;
         dashCooldownTime = Time.time + dashCooldown;
         dashDirection = new Vector2(horizontal, vertical).normalized;
      }

      horizontal = Input.GetAxisRaw("Horizontal");
      vertical = Input.GetAxisRaw("Vertical");

      if(gameObject.transform.position.x < LowerBoundX){
         gameObject.transform.position = new Vector2(LowerBoundX, transform.position.y);
      }
      if(gameObject.transform.position.x > UpperBoundX){
         gameObject.transform.position = new Vector2(UpperBoundX, transform.position.y);
      }
      if(gameObject.transform.position.y < LowerBoundY){
         gameObject.transform.position = new Vector2(transform.position.x, LowerBoundY);
      }
      if(gameObject.transform.position.y > UpperBoundY){
         gameObject.transform.position = new Vector2(transform.position.x, UpperBoundY);
      }
   }

   void FixedUpdate()
   {
      if (isDashing)
      {
         body.linearVelocity = dashDirection * (MoveSpeed + dashSpeed);

         if (Time.time >= dashTime)
         {
            isDashing = false;
         }
      }
      else
      {
         if (horizontal != 0 && vertical != 0)
         {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
         }

         body.linearVelocity = new Vector2(horizontal * MoveSpeed, vertical * MoveSpeed);
      }
   }
}
