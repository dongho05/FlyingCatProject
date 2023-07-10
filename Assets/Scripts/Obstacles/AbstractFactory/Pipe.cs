using UnityEngine;

public abstract class Pipe : MonoBehaviour
{
    public enum PipeType
    {
        Short,
        Medium,
        Long
    }
    public abstract PipeType GetEnemyType();
}
