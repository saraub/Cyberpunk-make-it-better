using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dialogue5Manager : MonoBehaviour
{
    public GameObject goToNextSceneBtn;
    public GameObject phoneScreen;
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    public GameObject selectionPanel1;
    public GameObject transitionPanel;

    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;
    string reply = "It looks like it's too late. She doesn't want to delay the game release.";

    string optionA = "Give me a moment, I will call the sales manager.";
    string optionB = "No worries, we will keep the situation under control.";

    string optionAA = "Better not, it would ruin our marketing campaign. We should now focus on selling as many copies as possible.";
    string optionAB = "Yes, it is important. I will take care of it. But you don’t have to record the gameplay, just send the game to our marketing team.";
    public GameObject continuesBtn;
    string beginSentence = "The game is worse than I expected. I am afraid that we should delay the release if possible.";
    string managerText = "Well then, maybe we publish some real gameplays for the people, so that they would know what to expect from the actual game at least?";
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(0));
        StartCoroutine(typeBegin());
    }
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
            else if(answeredType == "1")
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
            if (answeredType == "AB")
            {
                StartCoroutine(type("AB"));
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
            if (answeredType == "call")
            {
                StartCoroutine(callTime());
            }

            if (answeredType == "man")
            {
                StartCoroutine(managerType());
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
    IEnumerator callTime()
    {
        phoneScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        phoneScreen.SetActive(false);
        StartCoroutine(type("reply"));
    }
    public Button optionABtn;
    public Button optionBBtn;
    public Button optionAABtn;
    public Button optionABBtn;
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
            TempStatic.cyberP = 2;
            savingScript.instance.Save();
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
            

        }
    }
    public void goBackToConb1(string answeredType)
    {
       
        optionAABtn.enabled = false;
        optionABBtn.enabled = false;

        
        if (answeredType == "AA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AA"));
            TempStatic.cyberP = 2;
            savingScript.instance.Save();
            
            
        }
        if (answeredType == "AB")
        {
            TempStatic.cyberP = 1;
            savingScript.instance.Save();
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AB"));
            
        }

    }
    public void continueBtn(string type)
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        if (type == "end")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "end"));
           
        }
        if (type == "call")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "call"));
           
        }
        if (type == "others")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "man"));
           
        }



    }
    public void goDialogue3Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("release"));
        


    }
    IEnumerator type(string type)
    {
        myText.text = "";
        if (type == "reply")
        {
            for (int i = 0; i < reply.Length; i++)
            {
                myText.text += reply[i];
                yield return new WaitForSeconds(waitTime);
                if (i == reply.Length - 1)
                {
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("others"));

                }
            }

        }
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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("call"));

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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));
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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));

                }
            }

        }
        if (type == "AB")
        {
            for (int i = 0; i < optionAB.Length; i++)
            {
                myText.text += optionAB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));

                }
            }

        }

    }
    IEnumerator managerType()
    {
        headDeaprtmetnText.text = "";

        for (int i = 0; i < managerText.Length; i++)
        {
            headDeaprtmetnText.text += managerText[i];
            yield return new WaitForSeconds(waitTime);
            if (i == managerText.Length - 1)
            {
                myText.text = "...";
                answerBtn.SetActive(true);
                answerBtn.GetComponent<Button>().enabled = true;
                answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(1));


            }
        }




    }
}
