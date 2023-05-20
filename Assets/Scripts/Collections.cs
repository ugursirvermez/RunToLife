using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Collections : MonoBehaviour
{
	[SerializeField] int player_health=3;
	[SerializeField] int coins=0;
	[SerializeField] TMP_Text health_text;
	[SerializeField] TMP_Text coin_text;
	
	public int Player_Health
	{
		get => player_health;
		set => player_health = value;
	}
	
	public int Coins
	{
		get => coins;
		set => coins = value;
	}
	
    void Start()
    {
        
    }
	
	public void OnTriggerEnter2D(Collider2D Col)
	{
		if(Col.gameObject.tag == "coin")
		{
			Debug.Log("Altın Toplandı");
			coins = coins + 10;
			coin_text.text = coins.ToString();
			// coins +=10;
			//Col.gameObject.SetActive(false);
			Destroy(Col.gameObject);
		}
	}
    void Update()
    {
        if(EnemyStat.Player_Trigger == true)
		{
			player_health = player_health - 1;
			health_text.text = player_health.ToString();
			if(player_health == 0)
			{
				SceneManager.LoadScene(4);
				Debug.Log("KAYBETTIN");
			}
		}
    }
}
