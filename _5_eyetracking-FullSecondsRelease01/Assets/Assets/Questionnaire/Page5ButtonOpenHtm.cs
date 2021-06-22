//There are several buttons in this program. Each button has 
//its own controller in a separate script. 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

public class Page5ButtonOpenHtm : MonoBehaviour
{
    public QuesZGetScores quesZGetScores;
    public string Fname;
    public string Sname;
    public string DoB;
    public string Pmail;



    public Button ButtonPage5htm;
    public GameObject ButtonActvPage5htm;
    public Text Summary;
    public bool BoolBtnActvPage5htm;
    string startupPath = System.IO.Directory.GetCurrentDirectory();


    // Start is called before the first frame update
    void Start()
    {
        Button btn = ButtonPage5htm.GetComponent<Button>();
        btn.onClick.AddListener(SetBoolBtnActvPage5htm);
        BoolBtnActvPage5htm = true;
    }
    public void SetBoolBtnActvPage5htm()
    {
        CreateOutput();
            File.AppendAllText(startupPath + "/SpiderExperimentV05R02_Data/FinalLog/webform/gradtest/QuestionnaireAnswers.htm", 
"Please do not change anything in this box." +
" This is the content of the email that will be sent to: %p jogi1800@miun.se. %p " +
" I wish to participate in the experiment %p'Peripheral perception of fearful objects'. %p " +
"Please send me a data protection code. " +
"%p I am aware that this experiment uses images of animals to elicit emotional reactions in a virtual environment " +
"and some of the pictures shown may therefore contain threatening scenes or animals. " +
"My scores for the exclusion criteria are as follows (encrypted) please do not change any of this encrypted information " +
"or we cannot read your data:  %p " +
"!“§(=O)izumkljalydsaipoüxcbnvm" + QuesZGetScores.EnqStringQues01 + "ß9ß+qayseljlzeradadsefsadad" + QuesZGetScores.EnqStringQues05 +
"87416ipoüseljlxcbnvmß09ßycxy" + QuesZGetScores.EnqStringQues02 + "upä+üpß09sefsydsaadadgdgddhf" + QuesZGetScores.EnqStringQues06 +
")/(==“I=ß09ßsefsycxymkljalzrzrs" + QuesZGetScores.EnqStringQues03 + "7898+-+luiogdgdxcbnvmdhfzersgsdgds" + QuesZGetScores.EnqStringQues07 +
"Ä‘*+ä#ömkljalgdgdzrzrsseljladad" + QuesZGetScores.EnqStringQues04 + "" +
"!)/)UOAQ^8w4g15e7" +
"Ljpk,öüizumkljalydsaipoüxcbnvm" + QuesZGetScores.EnqStringSPQ01 + "56242lläüäseljlzeradadsefsadad: " + QuesZGetScores.EnqStringSPQ05 + "(I=”(sgsdgdsdgysfsaysfgsdfgsfsfsaf" + QuesZGetScores.EnqStringSPQ09 +
";.=ouo??ipoüseljlxcbnvmß09ßycxy" + QuesZGetScores.EnqStringSPQ02 + "mkl_llmsefsydsaadadgdgddhf" + QuesZGetScores.EnqStringSPQ06 + "“!$%sfgsdfgsgetetfsfsafsfskgkg" + QuesZGetScores.EnqStringSPQ10 +
"Ä##+#öäkß09ßsefsycxymkljalzrzrs" + QuesZGetScores.EnqStringSPQ03 + "üo912egdgdxcbnvmdhfzersgsdgds" + QuesZGetScores.EnqStringSPQ07 + "LJLJ)()“sfsxgsddkgkgdgfhdghs" + QuesZGetScores.EnqStringSPQ11 +
"Ä’gutqsbmkljalgdgdzrzrsseljladad" + QuesZGetScores.EnqStringSPQ04 + "=)(Ktdhfsfsfsafasgsdgdsysfsay" + QuesZGetScores.EnqStringSPQ08 + "464641&/))dghfhdfhdghsgetet479uj" + QuesZGetScores.EnqStringSPQ12 +
" %p I declare that I have read and understood the Data Protection Notice and Procedure and " +
"agree with the provisions stated therein. " +
"In sending this informtion I am aware that the encryption used " +
"serves to prevent my result data being collated with my personal data. " +
"I realise that electronic data transmission is always associated with the risk of interception and accept " +
"that sufficient steps have been taken, also taking into account the type of data being transmitted. " + 
"I am aware that a copy of the Data Protection Agreement and Procedure " +
"has been provided to me (either on paper directly by the researcher " +
"or in the top folder of this application where I started the application). " +
"I understand that applying for a code does not prevent me " +
"from withdrawing my participation and my data at a later time.  " +
"I am aware that personal data will be collected " +
"and that a code will be used when handling experimental data " +
"so that my personal data is protected. I have been informed of " +
"my right to withdraw from this experiment at any time " +
"and can request the deletion of my personal data and results without giving any reason. %p ");
File.AppendAllText(startupPath + "/SpiderExperimentV05R02_Data/FinalLog/webform/gradtest/QuestionnaireAnswers.htm",
@""" name=textarea1</input> </TD> <TD></TD></TR>
<br><br><br>

Thank you 
<br>
</form >
<a href=""#top"">Now click here to return to the top of page. Check your details and click the ""send"" button.</a>
<br><br><br>
Given Communication

  </body>
</html>");
            UnityEngine.Debug.Log("Page5ButtonOpenHtm/SetBoolBtnActvPage5htm()");
    }
    public void CreateOutput()
    {
        ShowExplorer();
    }


    public void ShowExplorer()
    {
        BoolBtnActvPage5htm = false;
        startupPath = startupPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        //System.Diagnostics.Process.Start("explorer.exe", startupPath);
        Application.OpenURL("file:///" + startupPath + "/SpiderExperimentV05R02_Data/FinalLog/webform/gradtest/QuestionnaireAnswers.htm");
        print(startupPath);

    }

    void Update()
    {
       
    }

}
