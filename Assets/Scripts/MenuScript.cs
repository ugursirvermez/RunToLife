using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
	[SerializeField] GameObject loading_panel;
	[SerializeField] GameObject menu_panel;
	[SerializeField] GameObject about_panel;
	[SerializeField] Slider load_slider;
	[SerializeField] TMP_Text yuzdelik;
	bool isactive = false;
	
  public void startgame()
  {
	  StartCoroutine(SliderKodu(1));
  }   
  
  public void exit()
  {
	  Application.Quit();
  }
  
  public void aboutus()
  {
	  isactive = true;
	  if(isactive == true)
	  {
		about_panel.SetActive(isactive);  
	  }
  }
  
  public void about_back()
  {
	  isactive = false;
	  if(isactive == false)
	  {
		about_panel.SetActive(isactive);  
	  }
  }
  
  IEnumerator SliderKodu(int index)
  {
	  AsyncOperation durum = SceneManager.LoadSceneAsync(index);
	  durum.allowSceneActivation=false;
	  loading_panel.SetActive(true);
	  while(!durum.isDone)
	  {
		  float dolumsuresi = Mathf.Clamp01(durum.progress/0.9f);
		  load_slider.value = dolumsuresi;
		  yuzdelik.text = "%" + dolumsuresi * 100;
		  durum.allowSceneActivation = true;
		  yield return null;
	  }
  }
  
}