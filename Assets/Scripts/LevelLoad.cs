using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
	[Header("Next Load Level Index")]
    [SerializeField] int level_index=0;
	
	void OnTriggerEnter2D(Collider2D col){
	if(col.gameObject.tag == "Player")
		{
			Debug.Log("Bir sonraki level");
			SceneManager.LoadScene(level_index);
		}
	}
	
	public void BacktoMenu()
	{
		SceneManager.LoadScene(level_index);
	}
}