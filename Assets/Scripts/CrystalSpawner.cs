using UnityEngine;
public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] private Transform Crystal;
    private Transform SpawnPoint;
    private float RandomFloat;
    void Start()
    {
         SpawnPoint = transform;
         RandomFloat = Random.Range(0, 1.0f);
         if (RandomFloat <= 0.2f)
         {
            Instantiate(Crystal, SpawnPoint);
         }          
    }
}
