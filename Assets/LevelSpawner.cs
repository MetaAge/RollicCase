using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levels;
    public float spawnDinstance;


    private void Awake()
    {
       for(int i = 0; i < levels.Length; i++)
        {
            GameObject.Instantiate(levels[i], new Vector3(0, 0, spawnDinstance * i+1), Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       // GameObject.Instantiate(levels[1], new Vector3(0, 0, spawnDinstance), Quaternion.identity);
      //  GameObject.Instantiate(levels[0], new Vector3(0, 0, spawnDinstance *2 ), Quaternion.identity);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
