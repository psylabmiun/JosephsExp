using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceResponse : MonoBehaviour
{
    //main script by user "Dapper Dino", 27/09/2018 (www.youtube.com/watch?v=29vyEOgsW8s), with fine tuning by the author of this experiment


    // Start is called before the first frame update
    public static KeywordRecognizer keywordRecognizer; 
    public static Dictionary<string, Action> keywords = new Dictionary<string, Action>();

    public MicInput micInputScript;

    public TaskTestSession taskTestSessionScript;
    public TaskInstructionScript taskInstructionScript;
    public ChangeMaterial changeMaterialScript;

    public static int IncrementForSpeech;


    void Start()
    {
        keywords.Add("yes", Yes);
        keywords.Add("no", No);
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }


    void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(+Time.time);
        keywords[speech.text].Invoke();

    }

    public void Yes()
    {
        File.AppendAllText(Application.dataPath + "/FinalLog/VoiceResponsesAndProcTimes.txt",
        "\r\n" + 
        "FearLoopIncrement" + "\t" + ChangeMaterial.IncrementFearLoop + "\t" + 
        "SpeechIncrement" + "\t" + IncrementForSpeech++ + "\t" + 
        "TaskIncrement" + "\t" + TaskTestSession.DisplayIncrement + 
        "\tYes\t" + 
        Time.time + 
        "\tdb is \t" + MicInput.MicLoudnessinDecibels.ToString("##.##") + "\t" + 
        TaskTestSession.rend.sharedMaterial);//\t= separator

    }
    public static void No()

    {
        File.AppendAllText(Application.dataPath + "/FinalLog/VoiceResponsesAndProcTimes.txt",
        "\r\n" + 
        "FearLoopIncrement" + "\t" + ChangeMaterial.IncrementFearLoop + "\t" + 
        "SpeechIncrement" + "\t" + IncrementForSpeech++ + "\t" +
        "TaskIncrement" + "\t" + TaskTestSession.DisplayIncrement + 
        "\tNo\t" + 
        Time.time + 
        "\tdb is " + "\t" + MicInput.MicLoudnessinDecibels.ToString("##.##") +"\t" + 
        TaskTestSession.rend.sharedMaterial);//\t= separator

    }

    void Update()
    {

        //Debug.Log("db is " + MicInput.MicLoudnessinDecibels.ToString("##.###"));
        File.AppendAllText(Application.dataPath + "/FinalLog/VoiceTimingDataSave.txt",
        "\r\n" + 
        "FearLoopIncrement" + "\t" + 
        ChangeMaterial.IncrementFearLoop + "\t" + 
        "SpeechIncrement" + "\t" + 
        IncrementForSpeech + "\t" +
        "TaskIncrement" + "\t" + TaskTestSession.DisplayIncrement + "\t" + 
        Time.time + 
        "\tdb is \t" + MicInput.MicLoudnessinDecibels.ToString("##.##"));//\t= separator

    }

}
