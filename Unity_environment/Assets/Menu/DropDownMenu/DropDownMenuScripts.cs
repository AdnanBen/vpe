using Menu.SaveManager;
using Menu.Scene_Config_Menu;
using Menu.Scene_Config_Menu.CameraScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.DropDownMenu
{
	public class DropDownMenuScripts : MonoBehaviour
	{

		public GameObject sceneCamera;
		public GameObject optionalComponentContainer;
		
		public GameObject selectedCog;
		public GameObject dropDown;
	
		public GameObject sceneSettingsMenu;
		public GameObject helpMenu;
		public GameObject loadMenu;

		public GameObject saveMenu;
		public GameObject saveMenuInputText;
	

		private void ToggleMenuOnState()
		{
			dropDown.SetActive(!dropDown.activeSelf);
			selectedCog.SetActive(!selectedCog.activeSelf);
		}

		public void OnMainButton()
		{
			ToggleMenuOnState();
		}
    
		public void OnSceneSettingsButton()
		{
			ToggleMenuOnState();
			sceneSettingsMenu.SetActive(true);
		}

		public void OnHelpButton()
		{
			ToggleMenuOnState();
			helpMenu.SetActive(true);
		}

		public void OnLoadSceneButton()
		{
			ToggleMenuOnState();
			loadMenu.SetActive(true);
		}
		
		public void OnSaveSceneButton()
		{
			ToggleMenuOnState();
			saveMenu.SetActive(true);
			RotateMoveCamera.DisableMovement();
		}

		public void OnSaveMenuSaveButton()
		{
			saveMenu.SetActive(false);
			SaveUtils.SaveSceneSettings(saveMenuInputText.GetComponent<Text>().text, sceneCamera, optionalComponentContainer);
			RotateMoveCamera.EnableMovement();
		}

		public void OnSaveMenuExitButton()
		{
			saveMenu.SetActive(false);
			RotateMoveCamera.EnableMovement();
		}

		public void OnExitButton()
		{
			SceneManager.LoadScene("Welcome");
		}
		

		public void OnMultiPresentButton() {
			ToggleMenuOnState();
			Application.OpenURL("https://presentr-video-chat.herokuapp.com");
		}
	}
}
