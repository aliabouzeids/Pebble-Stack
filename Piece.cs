using UnityEngine;


public class Piece : MonoBehaviour
{
    public Piece_Spawner spawner;
    public GameObject arriving_sound;
    public int score = 2;
    Game_Manager game_manager;
    void Awake()
    {
        game_manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Finish_Line>())
        {
            Instantiate(arriving_sound, transform.position, arriving_sound.transform.rotation);
            game_manager.score += score;
            if (spawner) spawner.Spawn();
            if (transform.parent) Destroy(transform.parent.gameObject);
            else Destroy(gameObject);
        }
        else
        {
            game_manager.Lose_Game();
            Destroy_Deactivate dd = gameObject.AddComponent<Destroy_Deactivate>();
            dd.time_interval = 1f;
        }
    }

}