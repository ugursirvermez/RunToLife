using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMan : EnemyStat
{
	//Buraya bir başlık ekledik
	[Header("Troll Man Settings")]
	//Burada karakterin başlayacağı kodu yazdık.
	[SerializeField] Transform destination_start;
	//Burası karakterin gideceği yer
	[SerializeField] Transform destination_end;
	//Trollman'in bulundugu ve gidecegi konumu bu degiskenlere atacagiz
	Vector3 CurrentPos;
	Vector3 TargetPos;
	
    void Start()
    {
	    Position = GetComponent<Transform>();
        Enemy_rig = GetComponent<Rigidbody2D>();
		Enemy_ren = GetComponent<SpriteRenderer>();
		Col = GetComponent<Collider2D>();
		TargetPos = destination_end.position;
		CurrentPos = destination_start.position;
    }
	
	void FixedUpdate()
	{
		CurrentPos = Position.position;
		if(CurrentPos.x == destination_start.position.x || CurrentPos.x < destination_start.position.x+0.5)
		{
			TargetPos = destination_end.position;
		}
	   else if(CurrentPos.x == destination_end.position.x || CurrentPos.x > destination_end.position.x-0.5)
		{
			TargetPos = destination_start.position;
		}
		Vector3 Distance = (TargetPos - CurrentPos).normalized;
		Enemy_rig.MovePosition(CurrentPos + Distance * Time.deltaTime*Speed);
		
	}

    void Update()
    {
        
    }
}