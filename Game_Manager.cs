using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public int score;
    public int high_score;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI h_score_text;
    public GameObject losing_obj;

    float initial_dropping_interval;
    [SerializeField] float hardening_interval = 30f;
    float initial_interval;
    float timer = 0f;
    Piece_Mover mover;
    Piece_Rotator rot;
    Piece_Spawner sp;

    void Awake()
    {
        mover = GetComponent<Piece_Mover>();
        rot = GetComponent<Piece_Rotator>();
        sp = GetComponent<Piece_Spawner>();
    }
    void Start()
    {
        initial_dropping_interval = mover.interval;
        initial_interval = hardening_interval;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (score > high_score) high_score = score;
        if (score_text) score_text.text = $"Score: {score}";
        if (h_score_text) h_score_text.text = $"High Score: {high_score}";
        if (timer > hardening_interval) Difficulty();
        rot.enabled = !losing_obj.activeSelf;
        sp.enabled = !losing_obj.activeSelf;
        mover.enabled = !losing_obj.activeSelf;

    }
    public void Reset()
    {
        mover.interval = initial_dropping_interval;
        hardening_interval = initial_interval;
        sp.Spawn();
    }
    public void Lose_Game()
    {
        losing_obj.SetActive(true);
    }
    void Difficulty()
    {
        //here I adjust the difficulty over time;
        timer = 0f;
        hardening_interval += 10;
        mover.interval = mover.interval / 1.5f;
    }
}