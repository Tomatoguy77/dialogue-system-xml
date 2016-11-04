using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour {
    [SerializeField]
    private Text textUI;

    public void ChangeText(string buttonText)
    {
        textUI.text = buttonText;
    }


	
}
