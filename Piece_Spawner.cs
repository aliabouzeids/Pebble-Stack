using UnityEngine;

public class Piece_Spawner : MonoBehaviour
{
    Piece_Rotator piece_rotator;
    Piece_Mover piece_mover;
    [SerializeField] Transform sp;
    [SerializeField] GameObject[] pieces;
    [SerializeField] GameObject fx;
    void Awake()
    {
        piece_rotator = GetComponent<Piece_Rotator>();
        piece_mover = GetComponent<Piece_Mover>();
    }
    void Start() => Spawn();
    public void Spawn()
    {
        int rn = Random.Range(0, 10001);
        int index = rn % pieces.Length;

        GameObject piece = Instantiate(pieces[index], sp.position, Quaternion.identity);
        Piece p = GetComponent<Piece>() ? piece.GetComponent<Piece>() : piece.GetComponentInChildren<Piece>();
        if (p) p.spawner = this;
        else Debug.LogError("Piece_Spawner::Spawn() : couldnt Find Piece Object on current object");

        piece_rotator.piece = piece.transform;
        piece_mover.piece = piece.transform;
        if (fx) Instantiate(fx, sp.position, Quaternion.identity);
    }
}