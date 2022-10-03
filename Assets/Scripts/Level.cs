using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject[] LevelObjects;
    public Color groundColor;


    public GameObject[] collectors;
    public int firstCollectorCount;
    public int secondCollectorCount;
    public int thirdCollectorCount;
    // Start is called before the first frame update
    void Start()
    {
        GiveRandomLevelColor();
        SpawnBalls();
        AssignCollectorCounts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GiveRandomLevelColor()
    {
        /* Color groundColor = new Color(
                   Random.Range(0f, 1f),
                   Random.Range(0f, 1f),
                   Random.Range(0f, 1f)
               );*/
        foreach (Transform part in gameObject.transform)
        {
            MeshRenderer partMaterial = part.transform.GetChild(1).GetComponent<MeshRenderer>();

            partMaterial.material.color = groundColor;
        }

    }

    void SpawnBalls()
    {
        foreach (Transform part in gameObject.transform)
        {
            int i = Random.Range(0, LevelObjects.Length);
            GameObject balls = GameObject.Instantiate(LevelObjects[i], part);
        }
    }

    void AssignCollectorCounts()
    {
        collectors[0].GetComponent<collector>().neededBalls = firstCollectorCount;
        collectors[1].GetComponent<collector>().neededBalls = secondCollectorCount;
        collectors[2].GetComponent<collector>().neededBalls = thirdCollectorCount;
    }
}
