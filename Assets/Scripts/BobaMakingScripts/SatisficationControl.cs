using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SatisficationControl : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        InvokeRepeating("decreaseSatisfication", 1.0f, 1.0f);
    }

    void decreaseSatisfication()
    {
        BobaMaking.currOrderTimeTaken += 1;
        if (BobaMaking.currOrderTimeTaken >= 30)
        {
            BobaMaking.currSatisficationLevel -= 1;
        }
        text.text = "SF: " + BobaMaking.currSatisficationLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
