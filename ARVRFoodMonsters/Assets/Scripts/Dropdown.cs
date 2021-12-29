using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dropdown : MonoBehaviour
{
    public Text myText;
    public Text atkText;
    public Text walkText;
    public Text damagedText;

    public void ondropdown(int input)
    {
        if (input == 0)
        {
            myText.text = "English";
            atkText.text = "Attack";
            walkText.text = "Walk";
            damagedText.text = "Damage";
        }
        else if (input == 1)
        {
            myText.text = "German";
            atkText.text = "Angriff";
            walkText.text = "Laufen";
            damagedText.text = "Schaden";
        }
        else {
            myText.text = "Spanish";
            atkText.text = "Ataque";
            walkText.text = "Correr";
            damagedText.text = "Dano";
        }
       
    }
}
