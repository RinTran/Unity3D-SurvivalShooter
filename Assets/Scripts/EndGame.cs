using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		//text = GetComponent <Text> ();
		string yourScore = PlayerPrefs.GetString ("score");
		text.text = yourScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
