﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour {
	public float letterPause; //lenght of pause

	string speach1 ;	
	string speach2 ;

	public Text text1;
	public Text text2 ;

	public static int comingSceneNo;
	public static string sceneToLoad;

	private int tabTimesOnTheScreen;
	private bool blockCoroutine;

	public GameObject background_panel;
	public Sprite endSprite;

	void Start () {

		if (comingSceneNo == 0) {
			sceneToLoad = "Bedroom Final";
		}

		if(sceneToLoad.Equals("Bedroom Final") ){ //if coming from splash screen going to bedroom
			speach1 = "Anna:\nThat was a shitty thing you did last night, you know that right?\n";
			speach2 = "Me:\nFuck you. I will become famous and go to the capital. \nI will leave you and this sad place behind.";
		}

		else if (sceneToLoad.Equals("mall") ) { // if coming from bedroom going to mall
			speach1 = "Anna:\nHow is it going, I see that you are still here?";
            speach2 = "Me:\nI am growing stronger now. Soon everybody will know my name.\n";

		}
		else if (sceneToLoad.Equals("Nightclub")) { // if coming from mall going to nightclub

			speach1 = "Anna:\nEverybody is talking about you, I can't believe you actually made it.";
            speach2 = "Me:\nI have only just begun, soon I am ready to leave you all.\n";
		}
		else if(GUIBedroom.gameEnded && sceneToLoad.Equals("Splash") ){ //if coming from night club to game ending
			background_panel.GetComponent<Image>().sprite = endSprite;
			speach1 = "Me:\nGoodbye Anna, I am leaving to the capital now.\n I hope we will never meet again.\n";
			speach2 = "Anna:\nYou will not be missed.";

		}



		tabTimesOnTheScreen = 0;
		StartCoroutine (StartTyping1());
	}


	IEnumerator StartTyping1()
	{
		text1.text = "";
		foreach (char letter in speach1.ToCharArray())
		{
			text1.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
		tabTimesOnTheScreen++;
		blockCoroutine = false;
	}

	IEnumerator StartTyping2()
	{
		blockCoroutine = true;
		text1.text = " ";
		text2.text = " ";
		foreach (char letter in speach2.ToCharArray())
		{
			text2.text += letter;
			yield return new WaitForSeconds(letterPause);
		}
		tabTimesOnTheScreen++;

	}


	public void LoadTheScene(){

		if (tabTimesOnTheScreen == 1 && !blockCoroutine) {
			StartCoroutine (StartTyping2 ());

		} else if (tabTimesOnTheScreen == 2) {
			SceneManager.LoadScene (sceneToLoad);
		}

	}
}
