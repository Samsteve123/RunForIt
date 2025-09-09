using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{  
    public int MaxEnemies = 5;
    public float EnemySpawnTime = 5f;
    public int LivingEnemies = 0;
    public float SpawnTimer = 20f;
    private float NextSpawn;


    [SerializeField] private GameObject[] SpawnPoints = new GameObject[5];
    private int ChosenSpawnPoint = 1;

    public GameObject GenericEnemy;
    public GameObject Player;

    void Start(){

        Player = GameObject.FindGameObjectWithTag("Player");
        NextSpawn = 5f;
    }

    void Update(){
        if(Player.GetComponent<PlayerStats>().CurrentHealth <= 0){
            GameObject.Destroy(Player);
            SceneManager.LoadScene(0);
        }

        if((LivingEnemies < MaxEnemies) && (Time.time > NextSpawn)){
            SpawnEnemy();
            NextSpawn = Time.time + SpawnTimer;
            LivingEnemies += 1;
        }
    }

    void SpawnEnemy(){
        ChosenSpawnPoint = Random.Range(0, 4);
        Object.Instantiate(GenericEnemy, SpawnPoints[ChosenSpawnPoint].transform.position, Quaternion.identity );
    }
}
