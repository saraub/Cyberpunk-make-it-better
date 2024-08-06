using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class releaseManager : MonoBehaviour
{
    public List<GameObject> humans = new List<GameObject>();
    public TextMeshProUGUI advicceText;
    public GameObject specialJudyContinueBtn;
    public GameObject salesSelectionPanel0;
    public GameObject SNSSelectionPanel0;
    public GameObject coworkerSelectionPanel0;
    public GameObject judySelectionPanel0;

    public GameObject transitionSales;
    public GameObject transitionSNS;
    public GameObject transitionAreaCoworker;
    public GameObject transitionAreaJudy;

    public GameObject answerBtnSales;
    public GameObject answerBtnSNS;
    public GameObject answerBtnCoworker;
    public GameObject answerBtnJudy;

    public GameObject continueBtnSales;
    public GameObject continueBtnSNS;
    public GameObject continueBtnJudy;
    public GameObject continueBtnCoworker;

    public GameObject endGameBtn;
    public GameObject speakArea;
    bool isJudyAngry;
    string[] judySpecialSentencesAngry = { "It could have been better. We didn't have time and we had to throw some ideas away.", "I wish I could have just skipped 'this party' and go home." };
    string[] judySpecialSentencesHappy = { "Yeah totally. Thanks for delaying the release of the game. I am sure it was necessary for the best result. Anyways I can finally have some free time. I should go traveling maybe to...","Haha, that sounds awesome!","Haha you wanna come along?","...I wasn't serious. I am travelling with my girlfriend. okay… it was nice meeting you again, bye!",
};


    string[] meSpecialSentencesAngry = { "Oh..well..How do you like the party then?","","" };
    string[] meSpecialSentencesHappy = { "Maybe South Africa?", "Are you travelling by yourself?", "Sure! I have always wanted to visit there!" };

    public TextMeshProUGUI salesTextArea;
    public TextMeshProUGUI sNSTextArea;
    public TextMeshProUGUI judyTextArea;
    public TextMeshProUGUI coworkerTextArea;

    public TextMeshProUGUI myTextAreaSales;
    public TextMeshProUGUI myTextAreaSNS;
    public TextMeshProUGUI myTextAreaJudy;
    public TextMeshProUGUI myTextAreaCoworker;

    public GameObject goBackBtnSales;
    public GameObject goBackBtnSNS;
    public GameObject goBackBtnJudy;
    public GameObject goBackBtnCoworker;


    int spedicalJudyCounter;
    int copyNum;
    public float waitTime;
    string meSay = "";
    string salesMangerSay = "";
    string socialMediaSay = "";
    string judySay = "";
    string coworkerSay = "";
    
    bool hasTalkedWithSales;
    bool hasTalkedWithSocialMedia;
    bool hasTalkedWithJudy;
    bool hasTalkedWithCoworker;
   
    void makeHumansDisapper()
    {
        foreach(GameObject g in humans)
        {
            g.SetActive(false);
        }
    }

   
    void calCoworker()
    {
        if (TempStatic.withDelay == false)
        {
            if (TempStatic.gameArt == "amazing")
            {
                TempStatic.gameArt = "good";
                
            }
            if (TempStatic.gameArt == "good")
            {
                TempStatic.gameArt = "ok";
                
            }
            if (TempStatic.gameArt == "ok")
            {
                TempStatic.gameArt = "poor";
                
            }
            if (TempStatic.programming == "amazing")
            {
                TempStatic.programming = "good";
                
            }
            if (TempStatic.programming == "good")
            {
                TempStatic.programming = "ok";
                
            }
            if (TempStatic.programming == "ok")
            {
                TempStatic.programming = "poor";

            }
            if (TempStatic.narrativeWriting == "amazing")
            {
                TempStatic.narrativeWriting = "good";
            }
            if (TempStatic.narrativeWriting == "good")
            {
                TempStatic.narrativeWriting = "ok";
            }
            if (TempStatic.narrativeWriting == "ok")
            {
                TempStatic.narrativeWriting = "poor";
            }
        }

        coworkerSay ="Okay so the game art is rated at [ "+"" + TempStatic.gameArt +""+ "  ]. System design scores at the range of [ " +""+ TempStatic.programming+"" + " ]. Last category of narrative writing has the score equivalent to [ " +""+ TempStatic.narrativeWriting+""+ " ].";
    }
    void calJudy()
    {
        
        if (TempStatic.withDelay)
        {
            isJudyAngry = false;
            judySay = judySpecialSentencesHappy[0];
        }
        else
        {
          

            isJudyAngry = true;
            judySay = judySpecialSentencesAngry[0];
        }
        
    }
   
    public void answerBtnSalesFunc()
    {
        answerBtnSales.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("sales","open"));
        
    }
    public void answerBtnSNSFunc()
    {
        answerBtnSNS.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("SNS", "open"));

    }
    public void answerBtnJudyFunc()
    {
        answerBtnJudy.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("judy", "open"));

    }
    public void answerBtnCoworkerFunc()
    {
        answerBtnCoworker.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("coworker", "open"));

    }
    public void specialJudyContinueBtnFunc()
    {
        if (spedicalJudyCounter == 0)
        {
            specialJudyContinueBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("judy", "0"));
        }
        else if(spedicalJudyCounter == 1)
        {
            specialJudyContinueBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("judy", "1"));
        }
        else if (spedicalJudyCounter == 2)
        {
            specialJudyContinueBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("judy", "2"));
        }
        else if (spedicalJudyCounter == 3)
        {
            specialJudyContinueBtn.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("judy", "2"));
        }



    }
   
    public void continueBtnFunc(string whichTheme)
    {
        if (whichTheme == "sales")
        {
            continueBtnSales.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("continue", "sales"));

           
        }
        if (whichTheme == "SNS")
        {
            continueBtnSNS.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("continue", "SNS"));

            
            
        }
        if (whichTheme == "judy")
        {
            continueBtnJudy.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("continue", "judy"));

            
            
        }

        if (whichTheme == "coworker")
        {
            continueBtnCoworker.GetComponent<Button>().enabled = false;
            StartCoroutine(waitABitUntilOpenPanel("continue", "coworker"));

            
            
        }
    }
    public Button optionASales;
    public Button optionBSales;
    public Button optionASNS;
    public Button optionBSNS;
    public Button optionAJudy;
    public Button optionBJudy;
    public Button optionACo;
    public Button optionBCo;

    public Button salesBtn;
    public Button SNSBtn;
    public Button JudyBtn;
    public Button coBtn;
    public void EndConvSNS(string types)
    {
        optionASNS.enabled = false;
        optionBSNS.enabled = false;
        if (types == "A")
        {
           
            StartCoroutine(waitABitUntilOpenPanel("SNS", "A"));
        }
        if (types == "B")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("SNS", "B"));
        }
    }
    public void EndConvJudy(string types)
    {
        optionAJudy.enabled = false;
        optionBJudy.enabled = false;
        if (types == "A")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("judy", "A"));
        }
        if (types == "B")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("judy", "B"));
        }
    }
    public void EndConvCoworker(string types)
    {
        optionACo.enabled = false;
        optionBCo.enabled = false;
        if (types == "A")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("coworker", "A"));
        }
        if (types == "B")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("coworker", "B"));
        }
    }
    public void EndConvBtnFUncSales(string types)
    {
        optionASales.enabled = false;
        optionBSales.enabled = false;
        if (types == "A")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("sales", "A"));
        }
        if (types == "B")
        {
            
            StartCoroutine(waitABitUntilOpenPanel("sales", "B"));
        }
      
    }
    public void salesMangerBtnFunc()
    {
        salesBtn.enabled = false;
        coBtn.enabled = false;
        SNSBtn.enabled = false;
        JudyBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("sales","begin"));
       
    }
    public void cowarkerBtnFunc()
    {
        salesBtn.enabled = false;
        coBtn.enabled = false;
        SNSBtn.enabled = false;
        JudyBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("coworker", "begin"));

    }
    public void socialMediaMangerBtnFunc()
    {
        salesBtn.enabled = false;
        coBtn.enabled = false;
        SNSBtn.enabled = false;
        JudyBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("SNS", "begin"));
        
    }
    public void judyBtnFunc()
    {
        salesBtn.enabled = false;
        coBtn.enabled = false;
        SNSBtn.enabled = false;
        JudyBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("judy", "begin"));

    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    void calCopyNumber()
    {
        copyNum = 7 + (1 * TempStatic.unrealisticExpectation);
        if (TempStatic.hasLostRetailer)
        {
            copyNum -= 3;
        }
        if (TempStatic.cyberP == 1)
        {
            copyNum -= (TempStatic.unrealisticExpectation - (TempStatic.bigPoint * 2 / 3));
        }
        salesMangerSay = "So we have sold about " + copyNum + " million copies of the game so far.";
    }
    void calPlayersReaction()
    {
       
        if (TempStatic.cyberP == 1 && TempStatic.unrealisticExpectation > 2)
        { 
            socialMediaSay = "Well, people are quite disappointed with the quality of the game, but seems like they do respect us for being fair and showing the game as it is before the release."; 
        }
        if (TempStatic.cyberP == 2 && TempStatic.unrealisticExpectation > 2)
        {
            socialMediaSay = "Well, people are upset that the game is worse than expected. And since we didn’t reveal it before the release, seems like they feel betrayed and lost interest in our company."; 
        }
        if (TempStatic.cyberP == 0 && TempStatic.bigPoint < 4||TempStatic.cyberP==1&&TempStatic.unrealisticExpectation<=2||TempStatic.cyberP==2&&TempStatic.unrealisticExpectation<=2)
        {
            socialMediaSay = "Well, people started betting that the game would win the “Worst Game Award” and they are disappointed, because they loved our last game. But this time it seems like we did something quite wrong.";
        }
        if (TempStatic.cyberP == 0 && TempStatic.bigPoint >= 4 && TempStatic.unrealisticExpectation >= 5)
        {
            socialMediaSay = "Well, people say that the game wasn’t worth waiting, because they were told it would be special. But with some delay it was quite average."; 
        }
        if (TempStatic.cyberP == 0 && TempStatic.bigPoint >= 4 && TempStatic.unrealisticExpectation < 5)
        {
            socialMediaSay = "Well, some people are just commenting that the game was delayed. Seems like media is not much interested."; 
        }
    }




    
    public void goBackBtnFunc(string type)
    {
        if (type == "sales")
        {
            hasTalkedWithSales = true;
        }
        if (type == "SNS")
        {
            hasTalkedWithSocialMedia = true;
        }
        if (type == "judy")
        {
            hasTalkedWithJudy = true;
        }
        if (type == "coworker")
        {
            hasTalkedWithCoworker = true;
        }
        
        StartCoroutine(waitABitUntilOpenPanel("close",""));
       
    }
    public void endGameBtnFunc()
    {
       
        endGameBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("menu"));

    }
    IEnumerator typeBegin(string type)
    {
        if (type == "sales")
        {
            salesTextArea.text = "";
            for (int i = 0; i < salesMangerSay.Length; i++)
            {
                salesTextArea.text += salesMangerSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == salesMangerSay.Length - 1)
                {
                    answerBtnSales.SetActive(true);

                }
            }
        }
        if (type == "SNS")
        {
            sNSTextArea.text = "";
            for (int i = 0; i < socialMediaSay.Length; i++)
            {
                sNSTextArea.text += socialMediaSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == socialMediaSay.Length - 1)
                {
                    answerBtnSNS.SetActive(true);

                }
            }
        }
        if (type == "judy")
        {
            judyTextArea.text = "";
            for (int i = 0; i < judySay.Length; i++)
            {
                judyTextArea.text += judySay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == judySay.Length - 1)
                {
                    answerBtnJudy.SetActive(true);

                }
            }
        }
        if (type == "coworker")
        {
            coworkerTextArea.text = "";
            for (int i = 0; i < coworkerSay.Length; i++)
            {
                coworkerTextArea.text += coworkerSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == coworkerSay.Length - 1)
                {
                    answerBtnCoworker.SetActive(true);

                }
            }
        }


    }
    IEnumerator waitABitUntilOpenPanel(string types, string answeredType)
    {
        yield return new WaitForSeconds(1f);
        if (types == "continue")
        {
            
            if (answeredType == "sales")
            {
                continueBtnSales.SetActive(false);
                calCopyNumber();
                StartCoroutine(type("sales"));
            }
            if (answeredType == "SNS")
            {
                continueBtnSNS.SetActive(false);
                calPlayersReaction();
                StartCoroutine(type("SNS"));
            }
            if (answeredType == "judy")
            {
                continueBtnJudy.SetActive(false);
                calJudy();
                StartCoroutine(type("judy"));
            }
            if (answeredType == "coworker")
            {
                continueBtnCoworker.SetActive(false);
                calCoworker();
                StartCoroutine(type("coworker"));
            }
        }
        if (types == "sales")
        {
            if (answeredType == "begin")
            {
                transitionSales.SetActive(true);
                speakArea.SetActive(false);
                salesMangerSay = "How are you? We have some data about the sales.";
                StartCoroutine(typeBegin("sales"));
            }
            if (answeredType == "open")
            {
                answerBtnSales.SetActive(false);
                transitionSales.SetActive(false);
                salesSelectionPanel0.SetActive(true);
               
            }
            if (answeredType == "A")
            {
               
                transitionSales.SetActive(true);
                salesSelectionPanel0.SetActive(false);
                meSay = "I am fine, how are the sales going?";
                StartCoroutine(myType("sales"));
            }
            if (answeredType == "B")
            {

                transitionSales.SetActive(true);
                salesSelectionPanel0.SetActive(false);
                meSay = "I am feeling great. Let me see.";
                StartCoroutine(myType("sales"));
            }

        }
        if (types == "SNS")
        {
            if (answeredType == "begin")
            {
                transitionSNS.SetActive(true);
                speakArea.SetActive(false);
                socialMediaSay = "Hey. I wanted to show you how the public is reacting to the game.";
                StartCoroutine(typeBegin("SNS"));
            }
            if (answeredType == "open")
            {
                answerBtnSNS.SetActive(false);
                transitionSNS.SetActive(false);
                SNSSelectionPanel0.SetActive(true);

            }
            if (answeredType == "A")
            {

                transitionSNS.SetActive(true);
                SNSSelectionPanel0.SetActive(false);
                meSay = "Ah you want to make me feel even better, sure give me some good news!";
                StartCoroutine(myType("SNS"));
            }
            if (answeredType == "B")
            {

                transitionSNS.SetActive(true);
                SNSSelectionPanel0.SetActive(false);
                meSay = "Sure. I am curious how they are reacting.";
                StartCoroutine(myType("SNS"));
            }

        }
        if (types == "judy")
        {

            if (answeredType == "begin")
            {
                transitionAreaJudy.SetActive(true);
                speakArea.SetActive(false);
                judySay = ".......ah..what's up?";
                StartCoroutine(typeBegin("judy"));
            }
            if (answeredType == "open")
            {
                answerBtnJudy.SetActive(false);
                transitionAreaJudy.SetActive(false);
                judySelectionPanel0.SetActive(true);

            }
            if (answeredType == "A")
            {

                transitionAreaJudy.SetActive(true);
                judySelectionPanel0.SetActive(false);
                meSay = "So are you happy with your work?"; 
                StartCoroutine(myType("judy"));
            }
            if (answeredType == "B")
            {

                transitionAreaJudy.SetActive(true);
                judySelectionPanel0.SetActive(false);
                meSay = "So are you happy with your work?"; 
                StartCoroutine(myType("judy"));
            }
            if (answeredType == "0")
            {
                specialJudyContinueBtn.SetActive(false);
                transitionAreaJudy.SetActive(true);
                judySelectionPanel0.SetActive(false);
                if (isJudyAngry)
                {
                    judySay =judySpecialSentencesAngry[1] ;
                }
                else
                {
                    judySay = judySpecialSentencesHappy[1];
                }
                
                StartCoroutine(type("me"));
            }
            if (answeredType == "1")
            {
                specialJudyContinueBtn.SetActive(false);
                transitionAreaJudy.SetActive(true);
                judySelectionPanel0.SetActive(false);
                if (isJudyAngry)
                {
                    judySay = judySpecialSentencesAngry[2];
                }
                else
                {
                    judySay = judySpecialSentencesHappy[2];
                }
                StartCoroutine(type("me"));
            }
            if (answeredType == "2")
            {
                specialJudyContinueBtn.SetActive(false);
                transitionAreaJudy.SetActive(true);
                judySelectionPanel0.SetActive(false);
                if (isJudyAngry)
                {
                    judySay = judySpecialSentencesAngry[3];
                }
                else
                {
                    judySay = judySpecialSentencesHappy[3];
                }
                StartCoroutine(type("me"));
            }

        }
        if (types == "coworker")
        {
            if (answeredType == "begin")
            {
                transitionAreaCoworker.SetActive(true);
                speakArea.SetActive(false);
                coworkerSay = "Sir, would you like to see overall ratings?";
                StartCoroutine(typeBegin("coworker"));
            }
            if (answeredType == "open")
            {
                answerBtnCoworker.SetActive(false);
                transitionAreaCoworker.SetActive(false);
                coworkerSelectionPanel0.SetActive(true);

            }
            if (answeredType == "A")
            {

                transitionAreaCoworker.SetActive(true);
                coworkerSelectionPanel0.SetActive(false);
                meSay = "How are the people reacting?"; 
                StartCoroutine(myType("coworker"));
            }
            if (answeredType == "B")
            {

                transitionAreaCoworker.SetActive(true);
                coworkerSelectionPanel0.SetActive(false);
                meSay = "Tell me how great ratings we have been receiving!"; 
                StartCoroutine(myType("coworker"));
            }

        }
       
        if (types == "close")
        {
            if (hasTalkedWithSales && hasTalkedWithSocialMedia&&hasTalkedWithJudy&&hasTalkedWithCoworker) // fix later
            {
                advicceText.text = "GO HOME";
                endGameBtn.SetActive(true);
                makeHumansDisapper();
                
            }
            if (hasTalkedWithSales)
            {
                salesBtn.gameObject.SetActive(false);
            }
            if (hasTalkedWithSocialMedia)
            {
                SNSBtn.gameObject.SetActive(false);
            }
            if (hasTalkedWithJudy)
            {
                JudyBtn.gameObject.SetActive(false);
            }
            if (hasTalkedWithCoworker)
            {
                coBtn.gameObject.SetActive(false);
            }
            salesBtn.enabled = true;
            coBtn.enabled = true;
            SNSBtn.enabled = true;
            JudyBtn.enabled = true;
            speakArea.SetActive(true);
            
            transitionSales.SetActive(false);
            transitionSNS.SetActive(false);
            transitionAreaCoworker.SetActive(false);
            transitionAreaJudy.SetActive(false);

            goBackBtnSales.SetActive(false);
            goBackBtnSNS.SetActive(false);
            goBackBtnJudy.SetActive(false);
            goBackBtnCoworker.SetActive(false);
        }
    }
    IEnumerator myType(string whichTheme)
    {
        
        if (whichTheme == "sales")
        {
            myTextAreaSales.text = "";
            for (int i = 0; i < meSay.Length; i++)
            {
                myTextAreaSales.text += meSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == meSay.Length - 1)
                {
                    continueBtnSales.SetActive(true);
                    continueBtnSales.GetComponent<Button>().enabled = true;
                }
            }
            
        }
        if (whichTheme == "SNS")
        {
            myTextAreaSNS.text = "";
            for (int i = 0; i < meSay.Length; i++)
            {
                myTextAreaSNS.text += meSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == meSay.Length - 1)
                {
                    continueBtnSNS.SetActive(true);
                    continueBtnSNS.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (whichTheme == "judy")
        {
            myTextAreaJudy.text = "";
            for (int i = 0; i < meSay.Length; i++)
            {
                myTextAreaJudy.text += meSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == meSay.Length - 1)
                {
                    continueBtnJudy.SetActive(true);
                    continueBtnJudy.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (whichTheme == "coworker")
        {
            myTextAreaCoworker.text = "";
            for (int i = 0; i < meSay.Length; i++)
            {
                myTextAreaCoworker.text += meSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == meSay.Length - 1)
                {
                    continueBtnCoworker.SetActive(true);
                    continueBtnCoworker.GetComponent<Button>().enabled = true;
                }
            }

        }


    }
    IEnumerator type(string type)
    {
        if (type == "me")
        {
            if (spedicalJudyCounter == 0)
            {
                if (isJudyAngry)
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesAngry[0].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesAngry[0][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesAngry[0].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(0));
                            

                        }
                    }
                }
                else
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesHappy[0].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesHappy[0][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesHappy[0].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(0));
                            
                        }
                    }
                }
            }
            if (spedicalJudyCounter == 1)
            {
                if (isJudyAngry)
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesAngry[1].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesAngry[1][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesAngry[1].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(1));


                        }
                    }
                }
                else
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesHappy[1].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesHappy[1][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesHappy[1].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(1));

                        }
                    }
                }
            }
            if (spedicalJudyCounter == 2)
            {
                if (isJudyAngry)
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesAngry[2].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesAngry[2][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesAngry[2].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(2));


                        }
                    }
                }
                else
                {
                    myTextAreaJudy.text = "";
                    for (int i = 0; i < meSpecialSentencesHappy[2].Length; i++)
                    {
                        myTextAreaJudy.text += meSpecialSentencesHappy[2][i];
                        yield return new WaitForSeconds(waitTime);
                        if (i == meSpecialSentencesHappy[2].Length - 1)
                        {
                            StartCoroutine(judyAdditionalType(2));

                        }
                    }
                }
            }



        }

        if (type == "sales")
        {
            salesTextArea.text = "";
            for (int i = 0; i < salesMangerSay.Length; i++)
            {
                salesTextArea.text += salesMangerSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == salesMangerSay.Length - 1)
                {
                    goBackBtnSales.SetActive(true);
                    goBackBtnSales.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (type == "SNS")
        {
            sNSTextArea.text = "";
            for (int i = 0; i < socialMediaSay.Length; i++)
            {
                sNSTextArea.text += socialMediaSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == socialMediaSay.Length - 1)
                {
                    goBackBtnSNS.SetActive(true);
                    goBackBtnSNS.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (type == "judy")
        {
            judyTextArea.text = "";
            for (int i = 0; i < judySay.Length; i++)
            {
                judyTextArea.text += judySay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == judySay.Length - 1)
                {
                    specialJudyContinueBtn.SetActive(true);
                    specialJudyContinueBtn.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (type == "coworker")
        {
            coworkerTextArea.text = "";
            for (int i = 0; i < coworkerSay.Length; i++)
            {
                coworkerTextArea.text += coworkerSay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == coworkerSay.Length - 1)
                {
                    goBackBtnCoworker.SetActive(true);
                    goBackBtnCoworker.GetComponent<Button>().enabled = true;
                }
            }

        }
    }
    IEnumerator judyAdditionalType(int types)
    {

        if (types == 0)
        {
            judyTextArea.text = "";
            for (int i = 0; i < judySay.Length; i++)
            {
                judyTextArea.text += judySay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == judySay.Length - 1)
                {
                    if (isJudyAngry)
                    {
                        goBackBtnJudy.SetActive(true);
                        goBackBtnJudy.GetComponent<Button>().enabled = true;
                    }
                    else
                    {
                        spedicalJudyCounter = 1;
                        specialJudyContinueBtn.SetActive(true);
                        specialJudyContinueBtn.GetComponent<Button>().enabled = true;
                    }
                    
                }
            }

        }
        if (types == 1)
        {
            judyTextArea.text = "";
            for (int i = 0; i < judySay.Length; i++)
            {
                judyTextArea.text += judySay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == judySay.Length - 1)
                {
                    
                    spedicalJudyCounter = 2;
                    specialJudyContinueBtn.SetActive(true);
                    specialJudyContinueBtn.GetComponent<Button>().enabled = true;
                }
            }

        }
        if (types == 2)
        {
            
            judyTextArea.text = "";
            for (int i = 0; i < judySay.Length; i++)
            {
                judyTextArea.text += judySay[i];
                yield return new WaitForSeconds(waitTime);
                if (i == judySay.Length - 1)
                {
                    if (isJudyAngry == false)
                    {
                        goBackBtnJudy.SetActive(true);
                    }
                   

                }
            }

        }

    }
}
