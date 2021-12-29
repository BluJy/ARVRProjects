using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target1Found : MonoBehaviour
{
    public Text nameText;

    public void changeName() 
    {
        nameText.text = "Chili";
    }
    
}
