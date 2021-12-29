using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public GameObject Eggy;
    public GameObject Chili;

    public void sliderchanged(float input) {
        Eggy.gameObject.transform.localScale = new Vector3(input, input, input);
        Chili.gameObject.transform.localScale = new Vector3(input, input, input);
    }
}
