using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dialogue3Manager : MonoBehaviour
{
    public GameObject goToNextSceneBtn;
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    
    public GameObject transitionPanel;

    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;
    public GameObject optionBObject;
    string optionA = "There you go. Let me know when the promotion video is ready.";
    string optionB = "There you go. Let me know when the promotion video is ready.";
    string beginSentence = "I have talked with one of your workers the other day and I was told to ask you for the footage materials. They will be used in a promotion video, of course.";

    public GameObject continuesBtn;
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator waitABitUntilNewSceneBtn()
    {
        yield return new WaitForSeconds(3f);
        goToNextSceneBtn.SetActive(true);
    }
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc());
        if (TempStatic.hasGotFakeMaterial)
        {
            optionBObject.SetActive(true);
        }
        else
        {
            optionBObject.SetActive(false);
        }
        StartCoroutine(typeBegin());
    }


  
    IEnumerator waitABitUntilOpenPanel(string types, string answeredType)
    {
        yield return new WaitForSeconds(1f);
        if (types == "selection")
        {
            answerBtn.SetActive(false);
            if (answeredType == "")
            {
                selectionPanel0.SetActive(true);
            }
           
            transitionPanel.SetActive(false);
        }
        if (types == "selectionClose")
        {
            selectionPanel0.SetActive(false);
            
            transitionPanel.SetActive(true);
            if (answeredType == "A")
            {
                StartCoroutine(type("A"));
            }
            if (answeredType == "B")
            {
                StartCoroutine(type("B"));
            }
           

        }

        if (types == "end")
        {
            if (answeredType == "")
            {
                continuesBtn.SetActive(false);

                transitionPanel.SetActive(false);
                guidePanel.SetActive(true);
                StartCoroutine(waitABitUntilNewSceneBtn());
            }
           
        }

    }
    public void answerBtnFunc()
    {
        answerBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("selection", ""));
            
        answerBtn.GetComponent<Button>().onClick.RemoveAllListeners();
       

        
    }
    public Button optionABtn;
    public Button optionBBtn;
    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
       
        if (answeredType == "A")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "A"));
           
            TempStatic.unrealisticExpectation += 2;
            savingScript.instance.Save();
        }
        if (answeredType == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
            

        }
    }
   
    public void continueBtn()
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("end", ""));
        

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
    public void goDialogue4Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("judy"));
       
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
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn());
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
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn());
                }
            }

        }
       

    }
   
}
