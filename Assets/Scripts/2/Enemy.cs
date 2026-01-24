using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Initialize(EnemyType type, Vector3 position);
    public abstract void SetConfig(EnemySettings settings);

    public abstract string GetName();
    public abstract string GetStat();
}
