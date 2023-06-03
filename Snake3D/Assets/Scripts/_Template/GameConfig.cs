using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "TDSM/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public float DistanceBetweenTails;
    public float TailSpeed;
    public GameObject TailPrefab;
    public GameObject ApplePrefab;
}
