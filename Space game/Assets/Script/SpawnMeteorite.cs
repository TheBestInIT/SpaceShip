using UnityEngine;
using UnityEngine.Animations;

public class SpawnMeteorite : MonoBehaviour
{
    
    [SerializeField] private GameObject _meeteoritePrefab;
    private int i;
    public float time = 2;

    [SerializeField]
    private GameObject parent; 
    void Start()
    {
        InvokeRepeating("SpawnMeteore", 0f, time);
    }

    private void SpawnMeteore()
    {
        
        float randomNumber = Random.Range(-4.5f, 4.5f);
        int randomVelocity = Random.Range(3, 8);
        if (i < 8)
        {
            randomVelocity = 3;
        }

        GameObject newObject = Instantiate(_meeteoritePrefab, new Vector2(randomNumber, 10), Quaternion.identity);
        newObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * randomVelocity;
        newObject.transform.parent = parent.transform;
        i++;
    }
}
