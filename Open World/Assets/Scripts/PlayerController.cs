using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

    public Animator anim;
    public GameObject spawner;
    public GameObject cubePrefab;

    bool alive = true;
    public int health = 5;
    int mainScore = 0;

    int highScore = 0;
    public Text score;
    public Text Hscore;
    public Toggle unlimHealth;
    public Image[] healthbar;

    void Start()
    {
        LoadPlayer();
        score.text = "Score:" + "0";
        
    }

    void Update()
    {
        if(health <= 0 && unlimHealth.isOn == false)
        {
            alive = false;
            StartCoroutine(RiseFromTheDead());
        }
       

        if(alive == true)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 2.0f;
            if(Input.GetKeyDown(KeyCode.Q))
            {
    //            SaveSystem.SavePlayer(this);
            }
            anim.SetFloat("Horizontal", (x * 10));
            anim.SetFloat("Vertical", (z * 10));
            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            score.text = "Score: " + mainScore.ToString();

            if(highScore >= mainScore)
            {
                Hscore.text = "Score: " + highScore.ToString();
            }
            else
            {
                Hscore.text = "Score: " + mainScore.ToString();
            }
        }
        else
        {
            SavePlayer();
             anim.SetBool("Dead", true);
        }

       

    }

    public bool GetAlive()
    {
        return alive;
    }
    public void TakeHealth(int h)
    {
         
        health -= h;
       healthbar[health].gameObject.SetActive(false);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        transform.position = pos;
        highScore = data.highscore;
    }

    public void SavePlayer ()
    {
        Debug.Log("prepare to save");
        PlayerData data = SaveSystem.LoadPlayer();
        if(mainScore >= data.highscore)
        {
            SaveSystem.SavePlayer(this, mainScore);
        }
        else
        {
            SaveSystem.SavePlayer(this, data.highscore);
        }
        
    }

    public void AddScore(int score)
    {
        mainScore += score;

    }

    IEnumerator RiseFromTheDead()
    {
        yield return new WaitForSeconds(4f);
       Application.LoadLevel(Application.loadedLevel);
    }
    void OnDestroy()
    {
        SavePlayer();
    }


}
