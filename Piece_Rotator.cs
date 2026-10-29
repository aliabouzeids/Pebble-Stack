using UnityEngine;


public class Piece_Rotator : MonoBehaviour
{

    bool x = true;
    bool y = false;
    bool z = false;
    float rotation_degree = 90f;
    public Transform piece;

    public void Switch_Axes()
    {
        if (x)
        {
            x = false;
            y = true;
        }
        else if (y)
        {
            y = false;
            z = true;
        }
        else if (z)
        {
            z = false;
            x = true;
        }
    }

    public void Rotate_Axes()
    {
        if (!piece) return;
        Vector3 new_rotation = piece.eulerAngles;
        if (x)
        {
            new_rotation.x += rotation_degree;
            piece.eulerAngles = new_rotation;
        }
        else if (y)
        {
            new_rotation.y += rotation_degree;
            piece.eulerAngles = new_rotation;
        }
        else
        {
            new_rotation.z += rotation_degree;
            piece.eulerAngles = new_rotation;
        }
    }

}