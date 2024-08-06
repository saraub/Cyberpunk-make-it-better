using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class dialogue0Manager : MonoBehaviour
{
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel;
    public GameObject transitionPanel;
    public GameObject goToNextSceneBtn;
    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;
    public GameObject optionBObject;
    string optionA = "Nice, can you send me some screenshots and footage from the game?";
    string optionB = "I was expecting a better design. Send me some screenshots and footage where the game looks nice.";
    public GameObject continuesBtn;
    string beginSentence = "I wanted to show you the current state of the development.";
    void Start()
    {
        StartCoroutine(typeBegin());
        if (TempStatic.gameArtP < 10)
        {
            optionBObject.SetActive(true);
        }
        else
        {
            optionBObject.SetActive(false);
           
        }
    }
    IEnumerator waitABitUntilOpenPanel(string types,string answeredType)
    {
        yield return new WaitForSeconds(1f);
        if (types == "selection")
        {
            selectionPanel.SetActive(true);
            transitionPanel.SetActive(false);
            answerBtn.SetActive(false);
        }
        if (types == "selectionClose")
        {
            selectionPanel.SetActive(false);
            transitionPanel.SetActive(true);
            if (answeredType == "A")
            {
                StartCoroutine(type("A"));

            }
            if (answeredType == "B")
            {
                StartCoroutine(type("B"));
                TempStatic.hasGotFakeMaterial = true;
                savingScript.instance.Save();
            }
        }
        if (types == "end")
        {
            transitionPanel.SetActive(false);
            guidePanel.SetActive(true);
            StartCoroutine(waitABitUntilNewSceneBtn());
        }

    }
    IEnumerator waitABitUntilNewSceneBtn()
    {
        yield return new WaitForSeconds(3f);
        goToNextSceneBtn.SetActive(true);
    }

    void Update()
    {

    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    public void answerBtnFunc()
    {
        answerBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("selection",""));
        
        
    }
    public Button optionABtn;
    public Button optionBBtn;
    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("selectionClose",answeredType));
        
       
    }
    public void continueBtn()
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("end",""));
        
       
    }
    public void goDialogue1Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("dialogue1"));
        
    }
    IEnumerator type(string type)
    {
        myText.text = "";
        if (type == "A")
        {
            for (int i = 0; i < optionA.Length; i++)
            {
                myText.text += optionA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionA.Length - 1)
                {
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (type == "B")
        {
            for (int i = 0; i < optionB.Length; i++)
            {
                myText.text += optionB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionB.Length - 1)
                {
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                }
            }

        }


    }
    IEnumerator typeBegin()
    {
        headDeaprtmetnText.text = "";
        for (int i = 0; i < beginSentence.Length; i++)
        {
            headDeaprtmetnText.text += beginSentence[i];
            yield return new WaitForSeconds(waitTime);
            if (i == beginSentence.Length - 1)
            {
                answerBtn.SetActive(true);
                answerBtn.GetComponent<Button>().enabled = true;
            }
        }

    }
}
