using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MratController : MonoBehaviour
{
	//Karakterimin ziplama guc degeri
    public float jump_power = 15f;
	//Karakterimin hiz degeri
	public float speed = 1.0f;
	//Karakterimin yonu
	public float direction;
	
	//Gizli Degiskenlerim
	//Karakterim yuruyor mu bunu kontrol edecegim
	private bool _iswalking = true;
	//Karakterim yere degiyor mu bunu kontrol edecegim
	private bool _ground;
	//Karakterim zipliyor mu bunu kontrol edecegim
	private bool jump;
	//Component Rigidbody nesneme erismek icin
	private Rigidbody2D _rigidbody;
	//Component Animator nesneme erismek icin
	private Animator _animator;
	//Component SpriteRenderer nesneme erismek icin
	private SpriteRenderer _renderer;
	//Spawn Noktasi asagidakidir
	[SerializeField] Transform SpawnPoint;
	//Mrat transform
	private Transform Player_Transform;
	
	//Awake metodu oyun calisirken ilk calisan frame metottur.
	void Awake()
	{
		//Animator component'inden nesne turettim.
		_animator = GetComponent<Animator>();
	}
	
	//Oyun ilk ekranda calistiginda calisan metottur.
    void Start()
    {
        //Rigidbody component'inden nesne turettim.
		_rigidbody = GetComponent<Rigidbody2D>();
		//SpriteRenderer component'inden nesne turettim.
		_renderer = GetComponent<SpriteRenderer>();
		//Player'in trasnform nesnesini turettim
		Player_Transform = GetComponent<Transform>();
    }

	//Fizik motorunun calistigi Update metodu burasidir.
	void FixedUpdate()
	{
		//Eger karakterim hareket etmiyorsa calissin.
		if(_rigidbody.velocity != Vector2.zero){
			_iswalking=true;
		}
		else{
			_iswalking=false;
		}
		//Mrat artik X ekseninde hareket etmeye baslasin.
		_rigidbody.velocity = new Vector2(speed * direction, _rigidbody.velocity.y);
		
		//Eger karakter zipliyorsa calisacak kosul
		if(jump == true)
		{
			_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jump_power-3f*Time.deltaTime);
			jump = false;
			_animator.SetBool("_ground", true);
		}
	}
	
	//Sonsuz dongu metodu
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
		{
			//Animator'deki hiz degiskenini speed ile esitliyorum.
			_animator.SetFloat("speed", speed);
			//Eger A tusuna basilmissa yonunu -x yap ve SpriteRenderer - yone donsun.
			if(Input.GetKey(KeyCode.A))
			{
				direction = -1.0f;
				_renderer.flipX = true;
			}
			//Eger D tusuna basilmissa yonunu +x yap ve SpriteRenderer + yone donsun.
			else if(Input.GetKey(KeyCode.D))
			{
				direction = 1.0f;
				_renderer.flipX = false;
			}
		}
		//Karakter sadece yerdeyse herseyi sifir yap.
		else if(_ground ==false)
		{
			direction = 0f;
			_animator.SetFloat("speed", 0.0f);
		}
		//Eger W tusuna basilirsa karakter Y ekseninde ziplasin.
		if(Input.GetKey(KeyCode.W))
		{
			jump = true;
			_ground = false;
			_animator.SetTrigger("jump");
			_animator.SetBool("_ground", false);
		}
		
		if(EnemyStat.Player_Trigger == true)
		{
			Player_Transform.position= new Vector3(SpawnPoint.position.x,SpawnPoint.position.y,0);
			EnemyStat.Player_Trigger = false;
		}
    }
	}