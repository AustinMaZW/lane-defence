using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 5;
    [SerializeField] int damage = 1;
    float lives;
    Text livesText;
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>(); // the component with text object (not the object itself!!)
        Updatedisplay();
    }
    private void Updatedisplay()
    {
        livesText.text = lives.ToString();
    }
    public void TakeLife()
    {
       
        lives -= damage;
        Updatedisplay();

        if (lives<=0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition(); //calls HandleLoseCondition from Level controller
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
