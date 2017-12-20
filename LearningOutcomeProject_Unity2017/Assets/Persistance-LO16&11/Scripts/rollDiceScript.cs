using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class rollDiceScript : MonoBehaviour {
	//UI
	public Text scoreText;
	public Text highScore;

	private bool flag = false;

	//Player object and playerScript
	GameObject player;
	playerScript ps;

	//List of scores(string name and float number paired together)
	List<Score> ScoreList = new List<Score>();

	//saving and loading variables
	string path;

	void Start () {
		//Here, I'm finding the player object and grabbing the playerScript.
		player = GameObject.Find ("Player");
		ps = player.GetComponent<playerScript> ();

		path = Application.streamingAssetsPath + Path.DirectorySeparatorChar + "File.txt";
	}

	void Update () {
		if (flag == false) {//to be cut off when true
			//Sorting the list of Score class based on the float number
			ScoreList.Sort((a, b) => a.number.CompareTo(b.number));
			ScoreList.Reverse ();
			var j = ScoreList.Count;
			if (ScoreList.Count > 10) {
				j = 10;
			}
			for (int i = 0; i < j; i++) {
				//for every score we add it to the highScore UI text
				highScore.text += (i+1).ToString() + ". " + ScoreList [i].number + "\t" + ScoreList [i].name + "\n";
			}
			//then we cut it off by setting flag to true, when the for loop is done
			flag = true;
		}
		}
	public void Save(){
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream saveFile = new FileStream (path,FileMode.Create);
			bf.Serialize (saveFile, ScoreList);
			saveFile.Close ();
		}

	}
	private List<Score> Load(){
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (path, FileMode.Open);
			List<Score> data = bf.Deserialize (stream) as List<Score>;
				stream.Close ();
				return data;
			}
	public void LoadScores(){
		ScoreList.Clear ();
		ScoreList = Load ();
		reset ();
	}

public void generateScore(){
		//generate a random number from 1 to 100
		float number = UnityEngine.Random .Range(1, 100);
		//set the scoreText UI to the just generated number
		scoreText.text = number.ToString();
		//add the current playerName and the just generated number to a new Score class
		//add the new Score to the ScoresList
		ScoreList.Add(new Score(number, ps.playerName));
		reset ();
}
	private void reset(){
		//reset the flag to false so it updates the score list in Update()
		flag = false;
		//actually reset the highScore UI text so it just doesn't duplicate it over the last one
		//since we're resetting the entire score board
		highScore.text = "High scores:\n";
	}
}
[System.Serializable]
public class Score
{
	public float number;
	public string name;
	public Score(float nu, string na){
		number = nu;
		name = na;
	}
	public float CompareTo(Score Other){
		return number.CompareTo (Other.number);
	}
}