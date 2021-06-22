using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenSummary : MonoBehaviour
{
    public QuesQuestion01 quesQuestion01;
    public QuesQuestion02 quesQuestion02;
    public QuesQuestion03 quesQuestion03;
    public QuesQuestion04 quesQuestion04;
    public QuesQuestion05 quesQuestion05;
    public QuesQuestion06 quesQuestion06;
    public QuesQuestion07 quesQuestion07;
    public SPQ01Question sPQ01;
    public SPQ02 sPQ02;
    public SPQ03 sPQ03;
    public SPQ04 sPQ04;
    public SPQ05 sPQ05;
    public SPQ06 sPQ06;
    public SPQ07 sPQ07;
    public SPQ08 sPQ08;
    public SPQ09 sPQ09;
    public SPQ10 sPQ10;
    public SPQ11 sPQ11;
    public SPQ12 sPQ12;

    private string StringQues01;
    private string StringQues02;
    private string StringQues03;
    private string StringQues04;
    private string StringQues05;
    private string StringQues06;
    private string StringQues07;
    private string StringSPQ01;
    private string StringSPQ02;
    private string StringSPQ03;
    private string StringSPQ04;
    private string StringSPQ05;
    private string StringSPQ06;
    private string StringSPQ07;
    private string StringSPQ08;
    private string StringSPQ09;
    private string StringSPQ10;
    private string StringSPQ11;
    private string StringSPQ12;


    public Text OnScreenScores;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Unencrypted Version
        /*        if (QuesQuestion01.IntExcl01True==0){StringQues01 = "Not confirmed";}
                        else if (QuesQuestion01.IntExcl01True == 1){StringQues01 = "Confirmed";}
                        else */

        if (QuesQuestion01.IntExcl01True == 2) { StringQues01 = "Page 2 - first question, "; }
        else { StringQues01 = ""; }
        /*       if (QuesQuestion02.IntExcl02True == 0) { StringQues02 = "Not confirmed"; }
                        else if (QuesQuestion02.IntExcl02True == 1) { StringQues02 = "Confirmed"; }
                        else */
        if (QuesQuestion02.IntExcl02True == 2) { StringQues02 = "Page 2 - second question, "; }
        else { StringQues02 = " "; }

        /*       if (QuesQuestion03.IntExcl03True == 0) { StringQues03 = "Not confirmed"; }
                        else if (QuesQuestion03.IntExcl03True == 1) { StringQues03 = "Confirmed"; }
                        else */
        if (QuesQuestion03.IntExcl03True == 2) { StringQues03 = "Page 2 - third question,\r\n"; }
        else { StringQues03 = "\r\n"; }

        /*       if (QuesQuestion04.IntExcl04True == 0) { StringQues04 = "Not confirmed"; }
                        else if (QuesQuestion04.IntExcl04True == 1) { StringQues04 = "Confirmed"; }
                        else*/
        if (QuesQuestion04.IntExcl04True == 2) { StringQues04 = "Page 2 - fourth question, "; }
        else { StringQues04 = " "; }    
        /*        if (QuesQuestion05.IntExcl05True == 0) { StringQues05 = "Not confirmed"; }
                        else if (QuesQuestion05.IntExcl05True == 1) { StringQues05 = "Confirmed"; }
                        else*/
        if (QuesQuestion05.IntExcl05True == 2) { StringQues05 = "Page 2 - fifth question, "; }
        else { StringQues05 = " "; }
        /*        if (QuesQuestion06.IntExcl06True == 0) { StringQues06 = "Not confirmed"; }
                        else if (QuesQuestion06.IntExcl06True == 1) { StringQues06 = "Confirmed"; }
                        else */
        if (QuesQuestion06.IntExcl06True == 2) { StringQues06 = "Page 2 - sixth question, \r\n"; }
        else { StringQues06 = "\r\n"; }
        /*        if (QuesQuestion07.IntExcl07True == 0) { StringQues07 = "Not confirmed"; }
                        else if (QuesQuestion07.IntExcl07True == 1) { StringQues07 = "Confirmed"; }
                        else*/
        if (QuesQuestion07.IntExcl07True == 2) { StringQues07 = "Page 2 - seventh question, \r\n"; }
        else { StringQues07 = "\r\n"; }
        /*        if (SPQ01Question.IntSPQ01True == 0) { StringSPQ01 = " False"; }
                        else if (SPQ01Question.IntSPQ01True == 1) { StringSPQ01 = "True"; }
                        else */
        if (SPQ01Question.IntSPQ01True == 2) { StringSPQ01 = "Page 3 - SPQ question 1, "; }
        else { StringSPQ01 = " "; }
        /*        if (SPQ02.IntSPQ02True == 0) { StringSPQ02 = " False"; }
                        else if (SPQ02.IntSPQ02True == 1) { StringSPQ02 = "True"; }
                        else */
        if (SPQ02.IntSPQ02True == 2) { StringSPQ02 = "Page 3 - SPQ question 2, "; }
        else { StringSPQ02 = " "; }
        /*        if (SPQ03.IntSPQ03True == 0) { StringSPQ03 = " False"; }
                      else if (SPQ03.IntSPQ03True == 1) { StringSPQ03 = "True"; }
                      else */
        if (SPQ03.IntSPQ03True == 2) { StringSPQ03 = "Page 3 - SPQ question 3, "; }
        else { StringSPQ03 = " "; }
        /*        if (SPQ04.IntSPQ04True == 0) { StringSPQ04 = " False"; }
                        else if (SPQ04.IntSPQ04True == 1) { StringSPQ04 = "True"; }
                        else*/
        if (SPQ04.IntSPQ04True == 2) { StringSPQ04 = "Page 3 - SPQ question 4, "; }
        else { StringSPQ04 = " "; }
        /*        if (SPQ05.IntSPQ05True == 0) { StringSPQ05 = " False"; }
                        else if (SPQ05.IntSPQ05True == 1) { StringSPQ05 = "True"; }
                        else*/
        if (SPQ05.IntSPQ05True == 2) { StringSPQ05 = "Page 3 - SPQ question 5, "; }
        else { StringSPQ05 = " "; }
        /*        if (SPQ06.IntSPQ06True == 0) { StringSPQ06 = " False"; }
                        else if (SPQ06.IntSPQ06True == 1) { StringSPQ06 = "True"; }
                        else */
        if (SPQ06.IntSPQ06True == 2) { StringSPQ06 = "Page 3 - SPQ question 6, "; }
        else { StringSPQ06 = " "; }
        /*        if (SPQ07.IntSPQ07True == 0) { StringSPQ07 = " False"; }
                        else if (SPQ07.IntSPQ07True == 1) { StringSPQ07 = "True"; }
                        else*/
        if (SPQ07.IntSPQ07True == 2) { StringSPQ07 = "Page 3 - SPQ question 7, "; }
        else { StringSPQ07 = " "; }
        /*        if (SPQ08.IntSPQ08True == 0) { StringSPQ08 = " False"; }
                        else if (SPQ08.IntSPQ08True == 1) { StringSPQ08 = "True"; }
                        else */
        if (SPQ08.IntSPQ08True == 2) { StringSPQ08 = "Page 3 - SPQ question 8, "; }
        else { StringSPQ08 = " "; }
        /*        if (SPQ09.IntSPQ09True == 0) { StringSPQ09 = " False"; }
                        else if (SPQ09.IntSPQ09True == 1) { StringSPQ09 = "True"; }
                        else */
        if (SPQ09.IntSPQ09True == 2) { StringSPQ09 = "Page 4 - SPQ question 9, "; }
        else { StringSPQ09 = " "; }
        /*        if (SPQ10.IntSPQ10True == 0) { StringSPQ10 = " False"; }
                else { StringQues10 = ""; }
        /*              else if (SPQ10.IntSPQ10True == 1) { StringSPQ10 = "True"; }
                        else */
        if (SPQ10.IntSPQ10True == 2) { StringSPQ10 = "Page 4 - SPQ question 10, "; }
        else { StringSPQ10 = " "; }
        /*        if (SPQ11.IntSPQ11True == 0) { StringSPQ11 = " False"; }
                        else if (SPQ11.IntSPQ11True == 1) { StringSPQ11 = "True"; }
                        else */
        if (SPQ11.IntSPQ11True == 2) { StringSPQ11 = "Page 4 - SPQ question 11, "; }
        else { StringSPQ11 = " "; }
        /*        if (SPQ12.IntSPQ12True == 0) { StringSPQ12 = " False"; }
                        else if (SPQ12.IntSPQ12True == 1) { StringSPQ12 = "True"; }
                        else */
        if (SPQ12.IntSPQ12True == 2) { StringSPQ12 = "Page 4 - SPQ question 12, "; }
        else { StringSPQ12 = " "; }


        OnScreenScores.text = "Please do not change anything in this box." +
" This is the content of the email that will be sent to: \r\n jogi1800@miun.se. \r\n " +
" I wish to participate in the experiment    'Peripheral perception of fearful objects'.  " +
"Please send me a data protection code. " +
"\r\n I am aware that this experiment uses images of animals to elicit emotional reactions in a virtual environment " +
"and some of the pictures shown may therefore contain threatening scenes or animals. " +
"My scores for the exclusion criteria are as follows (encrypted) please do not change any of this encrypted information " +
"or we cannot read your data:  \r\n " +
"!“§(=O)izumkljalydsaipoüxcbnvm" + QuesZGetScores.EnqStringQues01 + "ß9ß+qayseljlzeradadsefsadad" + QuesZGetScores.EnqStringQues05 +
"87416ipoüseljlxcbnvmß09ßycxy" + QuesZGetScores.EnqStringQues02 + "upä+üpß09sefsydsaadadgdgddhf" + QuesZGetScores.EnqStringQues06 +
")/(==“I=ß09ßsefsycxymkljalzrzrs" + QuesZGetScores.EnqStringQues03 + "7898+-+luiogdgdxcbnvmdhfzersgsdgds" + QuesZGetScores.EnqStringQues07 +
"Ä‘*+ä#ömkljalgdgdzrzrsseljladad" + QuesZGetScores.EnqStringQues04 + "" +
"!)/)UOAQ^8w4g15e7" +
"Ljpk,öüizumkljalydsaipoüxcbnvm" + QuesZGetScores.EnqStringSPQ01 + "56242lläüäseljlzeradadsefsadad: " + QuesZGetScores.EnqStringSPQ05 + "(I=”(sgsdgdsdgysfsaysfgsdfgsfsfsaf" + QuesZGetScores.EnqStringSPQ09 +
";.=ouo??ipoüseljlxcbnvmß09ßycxy" + QuesZGetScores.EnqStringSPQ02 + "mkl_llmsefsydsaadadgdgddhf" + QuesZGetScores.EnqStringSPQ06 + "“!$%sfgsdfgsgetetfsfsafsfskgkg" + QuesZGetScores.EnqStringSPQ10 +
"Ä##+#öäkß09ßsefsycxymkljalzrzrs" + QuesZGetScores.EnqStringSPQ03 + "üo912egdgdxcbnvmdhfzersgsdgds" + QuesZGetScores.EnqStringSPQ07 + "LJLJ)()“sfsxgsddkgkgdgfhdghs" + QuesZGetScores.EnqStringSPQ11 +
"Ä’gutqsbmkljalgdgdzrzrsseljladad" + QuesZGetScores.EnqStringSPQ04 + "=)(Ktdhfsfsfsafasgsdgdsysfsay" + QuesZGetScores.EnqStringSPQ08 + "464641&/))dghfhdfhdghsgetet479uj" + QuesZGetScores.EnqStringSPQ12 +
" \r\n I declare that I have read and understood the Data Protection Notice and Procedure and " +
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
"and can request the deletion of my personal data and results without giving any reason. \r\n ";


    }
}
