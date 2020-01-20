using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
	public Text hs;
    // Start is called before the first frame update
    void Start()
    {
        HSfunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Play()
	{
		SceneManager.LoadScene(1);
	}
	
	void HSfunction()
	{
		hs.text = PlayerPrefs.GetInt("Highscore").ToString();
	}
}
