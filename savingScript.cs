
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Globalization;

public class savingScript : MonoBehaviour
{
    public SaveData activeData;
    public static savingScript instance;
    public bool hasLoaded;


    private void Awake()
    {

        instance = this;
        Load();
    }

    public void Save()
    {

        TempStatic.assignToSave();




        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeData.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeData);
        stream.Close();

    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("hasPlayed"))
        {

        }
        else
        {
            savingScript.instance.DeleteData();

            savingScript.instance.Save();
            PlayerPrefs.SetInt("hasPlayed", 1);
            PlayerPrefs.Save();
        }
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeData.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeData.saveName + ".save", FileMode.Open);
            activeData = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            hasLoaded = true;
        }


        TempStatic.assignToTemp();




    }

    public void DeleteData()
    {

        string dataPath = Application.persistentDataPath;
        if (File.Exists(dataPath + "/" + activeData.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeData.saveName + ".save");

            Debug.Log("deleted");
        }
        TempStatic.getInitialValueForTemp();
        TempStatic.assignToSave();
        PlayerPrefs.DeleteAll();
    }
}
[System.Serializable]
public class SaveData
{

    public bool isAAA;
    public int hasPlayed;

    public bool isFirstTime;
    public string saveName;
    public string gameArt;
    public string programming;
    public string narrativeWriting;
    public int gameArtP;
    public int programmingP;
    public int narrativeWritingP;
    public bool hasGotFakeMaterial;
    public bool withDelay;
    public int unrealisticExpectation;
    public int bigPoint;
    public bool hasLostRetailer;
    public int cyberP;
    public bool hasRecord;
    public int copieNum;
}

public static class TempStatic
{
  
    public static bool isAAA { get; set; }
    public static bool isFirstTime { get; set; }
    public static string gameArt { get; set; }
    public static string programming { get; set; }
    public static string narrativeWriting { get; set; }
   
    public static int gameArtP { get; set; }
    public static int programmingP { get; set; }
    public static int narrativeWritingP { get; set; }
    public static bool hasGotFakeMaterial { get; set; }
    public static bool withDelay { get; set; }
    public static int unrealisticExpectation { get; set; }
    public static int bigPoint { get; set; }
    public static bool hasLostRetailer { get; set; }
    public static int cyberP { get; set; }
    public static bool hasRecord { get; set; }
    public static int copieNum { get; set; }
    public static void assignToTemp()
    {
        TempStatic.isAAA = savingScript.instance.activeData.isAAA;

        TempStatic.isFirstTime = savingScript.instance.activeData.isFirstTime;
        TempStatic.gameArt = savingScript.instance.activeData.gameArt;
        TempStatic.programming = savingScript.instance.activeData.programming;
        TempStatic.narrativeWriting = savingScript.instance.activeData.narrativeWriting;

        TempStatic.gameArtP = savingScript.instance.activeData.gameArtP;
        TempStatic.programmingP = savingScript.instance.activeData.programmingP;
        TempStatic.narrativeWritingP = savingScript.instance.activeData.narrativeWritingP;
        TempStatic.hasGotFakeMaterial = savingScript.instance.activeData.hasGotFakeMaterial;
        TempStatic.withDelay = savingScript.instance.activeData.withDelay;

        TempStatic.unrealisticExpectation = savingScript.instance.activeData.unrealisticExpectation;
        TempStatic.bigPoint = savingScript.instance.activeData.bigPoint;
        TempStatic.hasLostRetailer = savingScript.instance.activeData.hasLostRetailer;
        TempStatic.cyberP = savingScript.instance.activeData.cyberP;
        TempStatic.hasRecord = savingScript.instance.activeData.hasRecord;
        TempStatic.copieNum = savingScript.instance.activeData.copieNum;
    }
    public static void assignToSave()
    {

        savingScript.instance.activeData.isAAA = TempStatic.isAAA;
        savingScript.instance.activeData.isFirstTime = TempStatic.isFirstTime;
        savingScript.instance.activeData.gameArt = TempStatic.gameArt;
        savingScript.instance.activeData.programming = TempStatic.programming;
        savingScript.instance.activeData.narrativeWriting = TempStatic.narrativeWriting;

        savingScript.instance.activeData.gameArtP = TempStatic.gameArtP;
        savingScript.instance.activeData.programmingP = TempStatic.programmingP;
        savingScript.instance.activeData.narrativeWritingP = TempStatic.narrativeWritingP;
        savingScript.instance.activeData.hasGotFakeMaterial = TempStatic.hasGotFakeMaterial;
        savingScript.instance.activeData.withDelay = TempStatic.withDelay;

        savingScript.instance.activeData.unrealisticExpectation = TempStatic.unrealisticExpectation;
        savingScript.instance.activeData.bigPoint = TempStatic.bigPoint;
        savingScript.instance.activeData.hasLostRetailer = TempStatic.hasLostRetailer;
        savingScript.instance.activeData.cyberP = TempStatic.cyberP;
        savingScript.instance.activeData.hasRecord = TempStatic.hasRecord;
        savingScript.instance.activeData.copieNum = TempStatic.copieNum;
    }
   
   
   

    public static void getInitialValueForTemp()
    {


        isAAA = false;
        isFirstTime = true;
        gameArt = "";
        programming = "";
        narrativeWriting = "";

        gameArtP = 0;
        programmingP = 0;
        narrativeWritingP = 0;
        hasGotFakeMaterial = false;
        withDelay = false;
        unrealisticExpectation = 0;
        bigPoint = 0;
        hasLostRetailer = false;
        cyberP = 0;
        hasRecord = false;
        copieNum = 0;
    }


}

