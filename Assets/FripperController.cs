using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);		
	}
	
	// Update is called once per frame
	void Update () {

		// タップを検出
		foreach (Touch touch in Input.touches) {

			// タップ開始
			if (touch.phase == TouchPhase.Began) {
			// 座標確認用
			// Debug.Log("x:" + touch.position.x);

				// 画面(ほぼ？)中央から左がタップされたら左フリッパーを動かす
				if (touch.position.x < 120) {
					if (tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
					}

				// 画面(ほぼ？)中央から右がタップされたら右フリッパーを動かす
				} else {
					if (tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
					}
				}
			}
			// タップ終了
			else if(touch.phase == TouchPhase.Ended) {
				SetAngle (this.defaultAngle);
			}
		}
			
		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
