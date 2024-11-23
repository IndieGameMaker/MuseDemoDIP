using UnityEngine;

[CreateAssetMenu(fileName = "ZombieDataSO", menuName = "Scriptable Objects/ZombieDataSO")]
public class ZombieDataSO : ScriptableObject
{
    public const string PLAYER_TAG = "Player";
    public float traceDistance = 10.0f;
    public float attackDistance = 2.0f;
}
