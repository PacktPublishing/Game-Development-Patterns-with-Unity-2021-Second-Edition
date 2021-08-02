using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public Text radioLabel;
    private float channel = 108.7f;

	void Start ()
    {
        this.radioLabel.text = this.channel.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        this.ChangeDial(scroll);
    }

    void ChangeDial(float level)
    {
        this.channel = this.channel - level;
        this.radioLabel.text = this.channel.ToString("###0.0") + " FM";
    }
}
