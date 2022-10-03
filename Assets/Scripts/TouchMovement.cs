using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TouchMovement : MonoBehaviour
{
    public GameObject startScreen;
    public bool started;

    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;

    public Vector3 startTouchingPosition;

    public float leftBorder;
    public float rightBorder;

    public bool reachedCollector;
    public bool canMove = true;


    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public GameObject nextLevelButton;
    public GameObject restartLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        Vector3 deltaPosition = transform.forward * forwardSpeed;
        
        
        if (Input.touchCount > 0 && !reachedCollector && canMove)
        {

            if(startTouchingPosition == Vector3.zero)
            {
                GetStartTouchingPosition();
            }
            else
            {
                Vector3 touchPosition = Input.GetTouch(0).position;

                
                    if (touchPosition.x > startTouchingPosition.x && transform.position.x < rightBorder)
                        deltaPosition += transform.right * sideSpeed;
                    else if(touchPosition.x <= startTouchingPosition.x && transform.position.x > leftBorder  )
                        deltaPosition -= transform.right * sideSpeed;
                
                
            }
            
            
        }
        else
        {
            // deltaPosition = sideSpeed;
            startTouchingPosition = Vector3.zero;
        }
        if (started && !reachedCollector && canMove)
        {
            transform.position += deltaPosition * Time.deltaTime;
        }
    }

    void GetStartTouchingPosition()
    {
        started= true;
        startScreen.SetActive(false);
        startTouchingPosition = Input.GetTouch(0).position;
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            if (other.GetComponent<collector>().canPass)
            {
                canMove = true;
                reachedCollector = false;
            }
        }
        if (other.CompareTag("Finisher"))
        {

            canMove = false;
            reachedCollector = true;
            gameOverScreen.SetActive(true);
            gameOverText.text = "You win!";
            nextLevelButton.SetActive(true);
            restartLevelButton.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finisher"))
        {
            canMove = false;
            reachedCollector = true;
        }
    }

    public void NextLevel()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 6);
        reachedCollector = false;
        canMove = true;
        gameOverScreen.SetActive(false);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
