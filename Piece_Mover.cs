using UnityEngine;


public class Piece_Mover : MonoBehaviour
{
    [SerializeField] Transform[] slots;
    int index = 0;
    public Transform piece;
    public float interval = 1f;
    [SerializeField] float move_amount = 3f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0f;
            Move_Down();
        }
    }
    void Move_Down()
    {
        if (!piece) return;
        piece.position -= new Vector3(0f, move_amount, 0f);
    }
    public void Switch_Slot()
    {
        if (!piece) return;
        index = index == slots.Length - 1 ? 0 : index + 1;
        var pos = piece.position;
        pos.x = slots[index].position.x;
        pos.z = slots[index].position.z;
        piece.position = pos;
    }
}