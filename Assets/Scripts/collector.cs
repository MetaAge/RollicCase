using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class collector : MonoBehaviour
{
    public int neededBalls;
    public int currentBalls;

    public bool canPass;
    public Animation anim;

    public float collectTime;

    TMP_Text collectorText;

    public GameObject gameOverScreen;


    private void Awake()
    {
        collectorText = gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        collectorText.text = "0 / " + neededBalls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentBalls++;
            collectorText.text = currentBalls + "/" + neededBalls;
            StartCoroutine(OpenGate(collectTime,other));
        }
        if (other.CompareTag("Magnet"))
        {
            other.GetComponent<TouchMovement>().reachedCollector = true;
            StartCoroutine(OpenGate(collectTime, other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            other.GetComponent<TouchMovement>().reachedCollector = false;

        }
    }

    IEnumerator OpenGate(float time,Collider other)
    {
        yield return new WaitForSeconds(time);

        if (currentBalls >= neededBalls)
        {
            canPass = true;
            anim.Play();
        }
        else

        {
            canPass = false;
            //Debug.Log(GameObject.Find("Canvas").name);
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(1).GetChild(1).gameObject.GetComponent<TMP_Text>().text = "You lose!";
            //other.GetComponent<TouchMovement>().gameOverScreen.SetActive(true);

        }

        // Code to execute after the delay
    }
}
