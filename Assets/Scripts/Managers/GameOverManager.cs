using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public Text text;

	//string score;
	
	//public float restartDelay;

	//float restartTimer;
    //Animator anim;


    void Awake()
    {
        //anim = GetComponent<Animator>();
		//text = GetComponent<Text> ();
		//score = "Score: 0";
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
			PlayerPrefs.SetString("score",text.text);
            //anim.SetTrigger("GameOver");
			Application.LoadLevel("EndLevel");
			//restartTimer += Time.deltaTime;
			//if (restartTimer >= restartDelay)
			//	Application.LoadLevel(Application.loadedLevel);
        }
    }
}
