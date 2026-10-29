using UnityEngine;

public class UI_Buttons : MonoBehaviour
{
    Game_Manager game_manager;
    [SerializeField] GameObject[] to_deactivate;
    [SerializeField] GameObject[] to_activate;
    void Awake()
    {
        game_manager = FindAnyObjectByType<Game_Manager>();

    }

    public void Retry()
    {
        foreach (GameObject obj in to_deactivate)
        {
            if (obj.activeSelf) obj.SetActive(false);
        }
        foreach (GameObject obj in to_activate)
        {
            if (!obj.activeSelf) obj.SetActive(true);
        }
        game_manager.score = 0;
        game_manager.losing_obj.SetActive(false);
        game_manager.Reset();
    }
    public void Exit() => Application.Quit();
}