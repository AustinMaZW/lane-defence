using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int resource = 100;
    Text resourceText;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<Text>(); // the component with text object (not the object itself!!)
        Updatedisplay();
    }

    private void Updatedisplay()
    {
        resourceText.text = resource.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return resource >= amount; // simplified if statement together with return
    }
    public void AddResource(int amount)
    {
        resource += amount;
        Updatedisplay();
    }
    public void SpendResource(int amount)
    {
        if (resource >= amount)
        {
            resource -= amount;
            Updatedisplay();
        }
    }
}
