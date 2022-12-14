using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootKnife : MonoBehaviour
{
    Rigidbody2D rb;
    public float forwardForce = 200f;
    public GameObject knife;
    void Start()
    {
        rb = knife.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KnifeShoot()
    {
        Debug.Log("1");
        rb.AddForce(Vector2.up*forwardForce);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "knife")
        {
            ScoreManager.instance.GameOverPanel.SetActive(true);
            ScoreManager.instance.finalScoreTxt.text= ScoreManager.instance.scoreTxt.text;
        }
    }
}
