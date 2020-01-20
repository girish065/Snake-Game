using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{
	public int MaxLength;
	public int currLength;
	public int xBound;
	public int yBound;
	public int zBound;
	public int Score;
	public GameObject foodPrefab;
	public GameObject currfood;
	public GameObject food2Prefab;
	public GameObject currfood2;
	public GameObject snakePrefab;
	public snake head;
	public snake tail;
	public int NESW;
	public Vector3 nextPos;
	public Text scoreText;
	
	void OnEnable()
	{
		snake.hit += hit;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimerInvoke", 0, 0.3f);
		Foodfunction();
		Foodfunction2(); 
    }
	
	void OnDisable()
	{
		snake.hit -= hit;
	}

    // Update is called once per frame
    void Update()
    {
        ComChangeD();
    }
	
	void TimerInvoke()
	{
		Movement();
		if(currLength >= MaxLength)
		{
			TailFunction();
		}else
		{
			currLength++;
		}
	}
	
	void Movement()
	{
		GameObject temp;
		nextPos = head.transform.position;
		
		switch(NESW)
		{
			case 0:
			 
			 nextPos = new Vector3(nextPos.x, nextPos.y + 0.5f, nextPos.z);
			 
			break;
			
			case 1:
			
			 nextPos = new Vector3(nextPos.x + 0.5f, nextPos.y, nextPos.z);
			
			break;
			
			case 2:
			
			 nextPos = new Vector3(nextPos.x, nextPos.y - 0.5f, nextPos.z);
			
			break;
			
			case 3:
			
			 nextPos = new Vector3(nextPos.x - 0.5f, nextPos.y, nextPos.z);
			
			break;
		}
		
		temp = (GameObject)Instantiate(snakePrefab, nextPos, transform.rotation);
		head.Setnext(temp.GetComponent<snake>());
		head = temp.GetComponent<snake>();
		
		return;
		
	}
	void ComChangeD()
	{
		if(NESW != 2 && Input.GetKeyDown(KeyCode.UpArrow))
		{
			NESW = 0;
		}
		if(NESW != 3 && Input.GetKeyDown(KeyCode.RightArrow))
		{
			NESW = 1;
		}
		if(NESW != 0 && Input.GetKeyDown(KeyCode.DownArrow))
		{
			NESW = 2;
		}
		if(NESW != 1 && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			NESW = 3;
		}
	}
	
	void TailFunction()
	{
		snake tempSnake = tail;
		tail = tail.Getnext();
		tempSnake.RemoveTail();
	}
	
	void Foodfunction()
	{
		int xPos = Random.Range(-xBound, xBound);
		int yPos = Random.Range(-yBound, yBound);
		int zPos = Random.Range(-zBound, zBound);
		
		currfood = (GameObject)Instantiate(foodPrefab, new Vector3(xPos, yPos, zPos),transform.rotation);
		StartCoroutine(CheckRender(currfood));
	}
	
	void Foodfunction2()
	{
		int x1Pos = Random.Range(-xBound, xBound);
		int y1Pos = Random.Range(-yBound, yBound);
		int z1Pos = Random.Range(-zBound, zBound);
		
		currfood2 = (GameObject)Instantiate(food2Prefab, new Vector3(x1Pos, y1Pos, z1Pos),transform.rotation);
		StartCoroutine(CheckRender(currfood2));
	}
	
	IEnumerator CheckRender(GameObject IN)
	{
		yield return new WaitForEndOfFrame();
		if(IN.GetComponent<Renderer>().isVisible == false)
		{
			if(IN.tag == "food" || IN.tag == "food2")
			{
				Destroy(IN);
				Foodfunction();
				Foodfunction2();
			}
		}
	}
	
	void hit(string WhatWasSent)
	{
		if(WhatWasSent == "food")
		{
			Foodfunction();
			MaxLength++;
			Score+= 20;
			scoreText.text = Score.ToString();
			int temp = PlayerPrefs.GetInt("Highscore");
			if(Score > temp)
			{
				PlayerPrefs.SetInt("Highscore", Score);
			}
		}

		if(WhatWasSent == "food2")
		{
			Score =0;
			Foodfunction2();
			MaxLength++;
			Score+= 15;
			scoreText.text = Score.ToString();
			int temp = PlayerPrefs.GetInt("Highscore");
			if(Score > temp)
			{
				PlayerPrefs.SetInt("Highscore", Score);
			}
		}
		
		if(WhatWasSent == "snake")
		{
			CancelInvoke("TimerInvoke");
			Exit();
		}
		if(WhatWasSent == "cube")
		{
			CancelInvoke("TimerInvoke");
			Exit();
		}
	}
	
	public void Exit()
	{
		SceneManager.LoadScene(2);
	}
	
}
