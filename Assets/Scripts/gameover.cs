using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
	public Text Cs;
    // Start is called before the first frame update
    void Start()
    {
        Csfunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void okay()
	{
		SceneManager.LoadScene(0);
	}
	
	void Csfunction()
	{
		Cs.text = PlayerPrefs.GetInt("Score").ToString();
	}
}
