using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    

    [SerializeField] GameObject[] rings;

    [SerializeField] private float ringDistance = 5;
    [SerializeField] private float yPosition;

    public int numOfRings;

    //private GameManager gameManager;

    public static HelixManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        numOfRings = GameManager.instance.CurrentLevelIndex + 5;
        for (int i = 0; i < numOfRings; i++)
        {
            if(i == 0)
            {
                SpawnRings(0); ;
            }
            else
            {
                SpawnRings(Random.Range(1, rings.Length-1));
            }
        }
        SpawnRings(rings.Length - 1);
    }

    //private void SpawnRings(int index)
    //{
    //    GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPosition, transform.position.z), Quaternion.identity);
    //    yPosition -= ringDistance;
    //    newRing.transform.parent = transform;
    //}
    private void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPosition, transform.position.z), Quaternion.identity, transform);
        yPosition -= ringDistance;
    }
}