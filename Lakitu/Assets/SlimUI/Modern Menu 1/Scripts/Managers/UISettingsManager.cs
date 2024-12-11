using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class UISettingsManager : MonoBehaviour {

		public GameObject pauseMenu;
		private bool isPaused = false;
		public DrawOnSurfaceWithRange drawScript;

		// toggle buttons

		[Header("VIDEO SETTINGS")]
		public GameObject fullscreentext;

		// sliders
		public GameObject musicSlider;
		public GameObject sfxSlider;
		public GameObject masterSlider;
		public AudioMixer myMixer;
		

		public void  Start (){

			if (pauseMenu != null) {
				pauseMenu.SetActive(false);
			}

			// check slider values
			float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f); // Default to 0.75
			float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f); // Default to 0.75
			float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f); // Default to 0.75

			musicSlider.GetComponent<Slider>().value = musicVolume;
			sfxSlider.GetComponent<Slider>().value = sfxVolume;
			masterSlider.GetComponent<Slider>().value = masterVolume;

			// Apply saved volume to AudioMixer
    		myMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
			myMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
			myMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);

			musicSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { setMusic(); });
            sfxSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { setSFX(); });
            masterSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { setMaster(); });

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
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			// Disable drawing
			if (drawScript != null)
			{
				drawScript.CanDraw = false;
			}
        }

        public void ResumeGame() {
            if (pauseMenu != null) {
                pauseMenu.SetActive(false); 
            }
            Time.timeScale = 1f; // Unfreeze the game
            isPaused = false;

			// Enable drawing
			if (drawScript != null)
			{
				drawScript.CanDraw = true;
			}
        }

		public void toTitle() {
			SceneManager.LoadScene("TitleScreen");
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

		public void setMusic() {
			float musicVolume = musicSlider.GetComponent<Slider>().value;
			PlayerPrefs.SetFloat("MusicVolume", musicVolume);
			myMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20); 
			PlayerPrefs.Save(); 
		}

		public void setSFX() {
            float sfxVolume = sfxSlider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
            myMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
            PlayerPrefs.Save();
        }

        public void setMaster() {
            float masterVolume = masterSlider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
            myMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
            PlayerPrefs.Save();
        }

	}
}