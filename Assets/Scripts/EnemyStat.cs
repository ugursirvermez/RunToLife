using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
	[Header("Basic Enemy Settings")]
    [SerializeField] int health=100;
	[SerializeField] int speed=5;
	[SerializeField] Transform position;
	[SerializeField] Rigidbody2D enemy_rig;
	[SerializeField] SpriteRenderer enemy_ren;
	[SerializeField] Collider2D col;
	private static bool player_trigger=false;
	
	#region kapsullerim
	public int Health{
		get => health;
		set => health = value;
	}
	
	public int Speed{
		get => speed;
		set => speed = value;
	}
	
	public Transform Position{
		get => position;
		set => position = value;
	}
	
	public Rigidbody2D Enemy_rig{
		get => enemy_rig;
		set => enemy_rig = value;
	}
	
	public SpriteRenderer Enemy_ren{
		get => enemy_ren;
		set => enemy_ren = value;
	}
	
	public Collider2D Col{
		get => col;
		set => col = value;
	}
	
	public static bool Player_Trigger
	{
		get => player_trigger;
		set => player_trigger = value;
	}
	
	#endregion
	
    void Start()
    {
		position = GetComponent<Transform>();
        enemy_rig = GetComponent<Rigidbody2D>();
		enemy_ren = GetComponent<SpriteRenderer>();
		col = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
		{
			Debug.Log("Kahrolsun Dusman");
			//Col.gameObject.SetActive(false);
			//Destroy(col.gameObject);
			player_trigger=true;
		}
	}
}
