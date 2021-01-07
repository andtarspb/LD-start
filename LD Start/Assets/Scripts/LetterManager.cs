using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter
{

    public string id;
    public string text;

    Letter(string _id)
    {
        id = _id;
    }

    Letter(string _id, string _text)
    {
        id = _id;
        text = _text;
    }
}

public class LetterManager : MonoBehaviour
{
    [SerializeField]
    GameObject letterImage;

    Text letterText;

    Letter[] letters;

    public enum LetterID
    {
        testLetter,
        prisonLetter
    };

    // Start is called before the first frame update
    void Start()
    {
        letterImage.SetActive(false);
    }


    void ShowTestLetter()
    {
        
    }
   
    public void ShowLetter(string letterID)
    {
        // pause the game

        // show the letter
        // display the image
        // display required text
        
    }
}
