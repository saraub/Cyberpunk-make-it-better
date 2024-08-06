using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dialogue1Manager : MonoBehaviour
{
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    public GameObject selectionPanel1;
    public GameObject transitionPanel;
    public GameObject goToNextSceneBtn;
    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;

    string optionA = "They need more time than we have expected. The game has to be delayed to make sure everything works perfectly.";
    string optionB = "They should complete the game on time. We put so much effort in advertising and wasting it could be quite expensive. People would lose their interest if it takes too long.";
    string optionC = "Maybe you should ask the developers. If they really still need so much time, we shouldn’t ignore it and hope that they can make it faster.";

    string managerTextA = "I’m not sure. We already put some money to get people interested. If they start getting bored with our promotions, we couldn’t sell enough copies. I’m afraid that we lose a few important contracts after we announce such a big delay.";
    string managerTextB = "You are right, delaying is not a good idea.";
    string managerTextC = "It makes sense. I will ask them exactly how much time they need.";

    string optionAA = "I understand. Two years of delay would be too much. We have to release the game soon and improve the quality later with patches.";
    string optionAB = "You can’t just ignore this problem. We’ve got so many fans because of the last game. Losing our reputation would be much worse for the company than losing the contracts.";
    public GameObject continuesBtn;
    string beginSentence = "I heard that the development team requested to change our time schedule. They want two years longer to finish the game, did you hear that!? We have announced the game quite long time ago and I don't think we should keep people waiting.";
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(0));
        StartCoroutine(typeBegin());
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
            if (answeredType == "C")
            {
                StartCoroutine(type("C"));
            }
            if (answeredType == "AA")
            {
                StartCoroutine(typeSecond("AA"));
            }
            if (answeredType == "AB")
            {
                StartCoroutine(typeSecond("AB"));
            }

        }
        if (types == "continue")
        {
            continuesBtn.SetActive(false);
           
            if (answeredType == "A")
            {
                StartCoroutine(managerType("A"));
            }
            if (answeredType == "B")
            {
                StartCoroutine(managerType("B"));
            }
            if (answeredType == "C")
            {
                StartCoroutine(managerType("C"));
            }
            

        }
        if (types == "end")
        {
            continuesBtn.SetActive(false);
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
   
    public void answerBtnFunc(int num)
    {
       
        if (num == 0)
        {
            answerBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("selection","0"));
            
            answerBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        if (num == 1)
        {
            answerBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("selection", "1"));
        }

       
    }
    public Button optionABtn;
    public Button optionBBtn;
    public Button optionCBtn;
    public Button optionAABtn;
    public Button optionABBtn;
    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
        optionCBtn.enabled = false;
        
       
        if (answeredType == "A")
        {

            StartCoroutine(waitABitUntilOpenPanel( "selectionClose", "A"));
           
           
        }
        if (answeredType == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
            
           
        }
        if (answeredType == "C")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "C"));
           
            TempStatic.withDelay = true;
            savingScript.instance.Save();
        }
    }
    public void goBackToConb1(string answeredType)
    {
        
        optionAABtn.enabled = false;
        optionABBtn.enabled = false;

        if (answeredType == "AA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AA"));
           
            
        }
        if (answeredType == "AB")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AB"));
            
            TempStatic.withDelay = true;
            savingScript.instance.Save();
        }
       
    }
    public void continueBtn(string type)
    {
        continuesBtn.GetComponent<Button>().enabled = false;
       
        if (type == "A")
        {
            StartCoroutine(waitABitUntilOpenPanel("continue", "A"));
        }
        if (type == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("continue", "B"));
        }
        if (type == "C")
        {
            StartCoroutine(waitABitUntilOpenPanel("continue", "C"));
        }
        if (type == "end")
        {
            StartCoroutine(waitABitUntilOpenPanel("end",""));
            
        }

    }
    IEnumerator managerType(string type)
    {
        headDeaprtmetnText.text = "";
        if (type == "A")
        {
            for (int i = 0; i < managerTextA.Length; i++)
            {
                headDeaprtmetnText.text += managerTextA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerTextA.Length - 1)
                {
                    myText.text = "...";
                    answerBtn.SetActive(true);
                    answerBtn.GetComponent<Button>().enabled = true;
                    answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(1));


                }
            }

        }
        if (type == "B")
        {
            for (int i = 0; i < managerTextB.Length; i++)
            {
                headDeaprtmetnText.text += managerTextB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerTextB.Length - 1)
                {
                    myText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));

                }
            }

        }
        if (type == "C")
        {
            for (int i = 0; i < managerTextC.Length; i++)
            {
                headDeaprtmetnText.text += managerTextC[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerTextC.Length - 1)
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
    public void goDialogue1Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("dialogue2"));
        
    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("A"));

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
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("B"));
                }
            }

        }
        if (type == "C")
        {
            for (int i = 0; i < optionC.Length; i++)
            {
                myText.text += optionC[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionC.Length - 1)
                {
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("C"));
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
    IEnumerator typeSecond(string type)
    {
        myText.text = "";
        if (type == "AA")
        {
            for (int i = 0; i < optionAA.Length; i++)
            {
                myText.text += optionAA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAA.Length - 1)
                {
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
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));
                }
            }

        }
       

    }
}
