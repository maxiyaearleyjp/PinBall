using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour {
	static int total_score = 0;
	private int score = 0;

	// 得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {

		//シーン中のGameOverTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text> ().text = "Score:0";

		// タグによって点数を変える
		if (tag == "SmallStarTag") {
			this.score = 10;
		} else if (tag == "LargeStarTag") {
			this.score = 20;
		}else if(tag == "SmallCloudTag") {
			this.score = 30;
		}else if(tag == "LargeCloudTag") {
			this.score = 50;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		total_score += this.score;
		this.scoreText.GetComponent<Text> ().text = "Score:" + total_score;
	}

}
