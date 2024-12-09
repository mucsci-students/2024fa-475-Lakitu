using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.ModernMenu{
	public class UISettingsManager : MonoBehaviour {

		public GameObject pauseMenu;
		private bool isPaused = false;
		// toggle buttons

		[Header("VIDEO SETTINGS")]
		public GameObject fullscreentext;

		// sliders
		public GameObject musicSlider;
		

		public void  Start (){
			pauseMenu = pauseMenu.transform.Find("Canv_Options").gameObject;

			if (pauseMenu != null) {
				pauseMenu.SetActive(false);
			}

			// check slider values
			musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");

			// check full screen
			if(Screen.fullScreen == true){
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
				fullscreentext.GetComponent<TMP_Text>().text = "off";
			}

		}

		public void Update (){
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Debug.Log("Escape key pressed");
				if (isPaused) {
					ResumeGame();
				}
				else {
					PauseGame();
				}
			}
		}

		public void PauseGame() {
            if (pauseMenu != null) {
                pauseMenu.SetActive(true); 
            }
            Time.timeScale = 0f; // Freeze the game
            isPaused = true;
        }

        public void ResumeGame() {
            if (pauseMenu != null) {
                pauseMenu.SetActive(false); 
            }
            Time.timeScale = 1f; // Unfreeze the game
            isPaused = false;
        }

		public void FullScreen (){
			Screen.fullScreen = !Screen.fullScreen;

			if(Screen.fullScreen == true){
				fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
				fullscreentext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void MusicSlider (){
			//PlayerPrefs.SetFloat("MusicVolume", sliderValue);
			PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
		}
	}
}