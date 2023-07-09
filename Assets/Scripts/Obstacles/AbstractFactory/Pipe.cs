using UnityEngine;

public abstract class Pipe : MonoBehaviour
{
    public float pHeight;
    public float pWidth;
    public enum PipeType
    {
        Short,
        Medium,
        Long
    }
    public abstract PipeType GetEnemyType();
    public abstract void Initialize();
}
