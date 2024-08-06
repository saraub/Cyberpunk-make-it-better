using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class judyScript : MonoBehaviour
{
    public GameObject goToNextSceneBtn;
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    public GameObject selectionPanel1;
    public GameObject transitionPanel;

    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;

    string optionA = "Hello. You look tired though?";
    string optionB = "Hi. Such a nice weather today, isn't it?";

    string optionAA = "I can help you out a bit, tommorrow at eleven?";
    string optionBB = "I brought you some coffee to get you some fresh air.";
    public GameObject continuesBtn;
    string beginSentence = "Oh, hey...Hello. I am Judy from TGames. I am one of the concept artists for the game.";
    string managerText0 = "Well actually I have been struggling quite a lot lately with my ideas.";
    string managerText = "Thanks a lot. I will see you around.";
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(0));
        StartCoroutine(typeBegin());
    }
    IEnumerator waitABitUntilNewSceneBtn()
    {
        yield return new WaitForSeconds(3f);
        goToNextSceneBtn.SetActive(true);
    }
    IEnumerator waitABitUntilOpenPanel(string types, string answeredType)
    {
        yield return new WaitForSeconds(1f);
        if (types == "selection")
        {
            answerBtn.SetActive(false);
            if (answeredType == "0")
            {
                selectionPanel0.SetActive(true);
            }
            if (answeredType == "1")
            {
                selectionPanel1.SetActive(true);
            }

            transitionPanel.SetActive(false);
        }
        if (types == "selectionClose")
        {
            selectionPanel0.SetActive(false);
            selectionPanel1.SetActive(false);
            transitionPanel.SetActive(true);
            if (answeredType == "A")
            {
                StartCoroutine(type("A"));
            }
            if (answeredType == "B")
            {
                StartCoroutine(type("B"));
            }
            if (answeredType == "AA")
            {
                StartCoroutine(type("AA"));
            }
            if (answeredType == "BB")
            {
                StartCoroutine(type("BB"));
            }


        }

        if (types == "end")
        {
            continuesBtn.SetActive(false);
            if (answeredType == "end")
            {
                
                transitionPanel.SetActive(false);
                guidePanel.SetActive(true);
                StartCoroutine(waitABitUntilNewSceneBtn());
            }
            if (answeredType == "0")
            {
                StartCoroutine(managerType("0"));
            }
            if (answeredType == "1")
            {
                StartCoroutine(managerType("1"));
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

            }
        }

    }

 
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    public void answerBtnFunc(int num)
    {
        answerBtn.GetComponent<Button>().enabled = false;
        if (num == 0)
        {
            StartCoroutine(waitABitUntilOpenPanel("selection", "0"));
           
            answerBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        if (num == 1)
        {
            StartCoroutine(waitABitUntilOpenPanel("selection", "1"));
            
        }

       
    }
    public Button optionABtn;
    public Button optionBBtn;
    public Button optionAABtn;
    public Button optionBBBtn;
    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
        
       
        if (answeredType == "A")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "A"));
           

        }
        if (answeredType == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
            

        }
    }
    public void goBackToConb1(string answeredType)
    {
        
        optionAABtn.enabled = false;
        optionBBBtn.enabled = false;

        if (answeredType == "AA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AA"));
            
        }
        if (answeredType == "BB")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "BB"));

           
        }

    }
    public void continueBtn(string type)
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        
        if (type == "end")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "end"));
           
        }
        else if(type == "other")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "0"));
            
        }
        else if (type == "other1")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "1"));
            
        }



    }
    public void goDialogue3Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
            
        
        StartCoroutine(goToNextScene("dialogue4"));

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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("other"));
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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("other"));
                }
            }

        }
        if (type == "AA")
        {
            for (int i = 0; i < optionAA.Length; i++)
            {
                myText.text += optionAA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAA.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("other1"));

                }
            }

        }
        if (type == "BB")
        {
            for (int i = 0; i < optionBB.Length; i++)
            {
                myText.text += optionBB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionBB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("other1"));

                }
            }

        }

    }
    IEnumerator managerType(string type)
    {
        headDeaprtmetnText.text = "";
        if (type == "0")
        {
            for (int i = 0; i < managerText0.Length; i++)
            {
                headDeaprtmetnText.text += managerText0[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerText0.Length - 1)
                {
                    myText.text = "...";
                    answerBtn.SetActive(true);
                    answerBtn.GetComponent<Button>().enabled = true;
                    answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(1));


                }
            }
        }
        if (type == "1")
        {
            for (int i = 0; i < managerText.Length; i++)
            {
                headDeaprtmetnText.text += managerText[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerText.Length - 1)
                {
                    myText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));


                }
            }
        }





    }
}
