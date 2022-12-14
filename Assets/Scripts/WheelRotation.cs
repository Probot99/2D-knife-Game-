using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 120f;
    public int numOfKnife = 5;
    public GameObject knifePrefab;
   // public GameObject cloneParent;
    bool needToRespawn;
    int knifeCount = 0;
    int scoreCount=0;
    int level1Count=5;
    int level2Count = 10;
    bool CanRotate = false;
    bool ismoveright= false;
    private float startingPosition;
    bool level2;
    bool level1;

    void Start()
    {
        needToRespawn = true;
        level2 = false;
        level1 = true;
    }

    void Update()
    {
        RotateWheel();
        RespawnKnife();
        TouchMovement();
        NextLevel();
        FinalResult();
    }
    public void RotateWheel()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
    public void DownPointer()
    {
        CanRotate = true;
    }
    public void UpPointer()
    {
        CanRotate = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        collision.transform.SetParent(this.transform);
        needToRespawn = true;
        knifeCount += 1;
        scoreCount += 1;
        ScoreIncreament();
        if (scoreCount == 5 && level1)
        {
            level2 = true;
            level1 = false;
            Debug.Log(level2);
            ScoreManager.instance.itemLeftTxt.text = "0";
        }
    }
    public void RespawnKnife()
    {
        Debug.Log("re");
        if(needToRespawn && knifeCount<numOfKnife)
        {
            GameObject obj = Instantiate(knifePrefab);
            needToRespawn = false;
        }
    }
    public void ScoreIncreament()
    {
        if(needToRespawn)
        {
            level1Count = level1Count - 1;
            ScoreManager.instance.scoreTxt.text = "Score: "+ scoreCount.ToString();
            ScoreManager.instance.itemLeftTxt.text = level1Count.ToString();

           // needToRespawn = false;
        }
    }

    public void TouchMovement()
    {
        Debug.Log(CanRotate);
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (startingPosition > touch.position.x)
                    {
                        transform.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                    }
                    else if (startingPosition < touch.position.x)
                    {
                        transform.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
                case TouchPhase.Stationary:
                    startingPosition = touch.position.x;
                    break;
            }
        }
    }
    public void NextLevel()
    {
        if(level2)
        {
            level2 = false;
            StartCoroutine(LevelSwitch());
        }
    }
    IEnumerator LevelSwitch()
    {
        yield return new WaitForSeconds(1f);
        ScoreManager.instance.NextLevelPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        ScoreManager.instance.itemLeftTxt.text = level2Count.ToString();
        ScoreManager.instance.NextLevelPanel.SetActive(false);
        ScoreManager.instance.scoreTxt.text = "Score: 0";
        scoreCount = 0;
        ScoreManager.instance.levelTxt.text = "Level2";
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("knife");
        knifeCount = 0;
        numOfKnife = 10;
        needToRespawn = true;
        level1Count = 10; //for level2
        foreach (GameObject obj in taggedObjects) 
            {
            Destroy(obj);
        }
    }
    public void FinalResult()
    {
        if(scoreCount==10 )
        {
            ScoreManager.instance.finalWinPanel.SetActive(true);
            ScoreManager.instance.finalScoreTxt.text = ScoreManager.instance.scoreTxt.text +" "+ scoreCount.ToString();
        }
    }
}
