//++++++++++++++++++++++++
//QuesZGetScores.cs
//++++++++++++++++++++++++
/*This script collects all toggle values (spider fear and exclusion criteria) and writes these to 
 * a text on the final page together with the data protection agreement in encrypted form which can only 
 * be decrypted with a macro in the posession of the student researcher. The decryption method chosen is 
 * simple replacement encryption, but without knowledge of the test, the data is of no value and 
 * not understandable. Decryption is however necessary since the data is also sent to an HTM form, with the consent 
 * of the participant (button press) in which final personal data is collected and the data is transmitted to the 
 * student researcher. The data is relayed via php on the website www.given-communication.de 
 * which is owned by the student researcher. the data is not saved by the website, but simply relayed to 
 * the student participant. A link is provided to the data protection policy of the website, in order 
 * to ensure that the participants are informed of the use of an external page. Of course no means of 
 * transmission is completely secure and interception is always a technical possibility, but the use of php means that the 
 * data is not stored online as is the case in data banks or upload systems.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class QuesZGetScores : MonoBehaviour


{
    public _ToggleConsultation _toggleConsultation;
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


    public static string EnqStringQues01;
    public static string EnqStringQues02;
    public static string EnqStringQues03;
    public static string EnqStringQues04;
    public static string EnqStringQues05;
    public static string EnqStringQues06;
    public static string EnqStringQues07;
    public static string EnqStringSPQ01;
    public static string EnqStringSPQ02;
    public static string EnqStringSPQ03;
    public static string EnqStringSPQ04;
    public static string EnqStringSPQ05;
    public static string EnqStringSPQ06;
    public static string EnqStringSPQ07;
    public static string EnqStringSPQ08;
    public static string EnqStringSPQ09;
    public static string EnqStringSPQ10;
    public static string EnqStringSPQ11;
    public static string EnqStringSPQ12;
    public static string StringConsult;


    public InputField EmailAndScores;

    public static bool BoolEmailAndScores;

    //    public Text MailtoJOGI; 
    //    string email;
    //    string subject;
    //    string body;

    void Start()
    {
        BoolEmailAndScores = true;
    }


    void Update()
    {
        //Coded Version
        if (QuesQuestion01.IntExcl01True == 0) { EnqStringQues01 = "izuß09ßmkljalgdgd"; }
        else if (QuesQuestion01.IntExcl01True == 1) { EnqStringQues01 = "ipoümkljalseljlzer"; }
        else if (QuesQuestion01.IntExcl01True == 2) { EnqStringQues01 = "ß09ßseljlsefsydsa"; }
        if (QuesQuestion02.IntExcl02True == 0) { EnqStringQues02 = "mkljalsefsgdgdxcbnvm"; }
        else if (QuesQuestion02.IntExcl02True == 1) { EnqStringQues02 = "seljlgdgdzerycxy"; }
        else if (QuesQuestion02.IntExcl02True == 2) { EnqStringQues02 = "sefszerydsazrzrs"; }
        if (QuesQuestion03.IntExcl03True == 0) { EnqStringQues03 = "gdgdydsaxcbnvmadad"; }
        else if (QuesQuestion03.IntExcl03True == 1) { EnqStringQues03 = "zerxcbnvmycxyadad"; }
        else if (QuesQuestion03.IntExcl03True == 2) { EnqStringQues03 = "ydsaycxyzrzrsdhf"; }
        if (QuesQuestion04.IntExcl04True == 0) { EnqStringQues04 = "xcbnvmzrzrsadadsgsdgds"; }
        else if (QuesQuestion04.IntExcl04True == 1) { EnqStringQues04 = "ycxyadadadadsfgsdfgs"; }
        else if (QuesQuestion04.IntExcl04True == 2) { EnqStringQues04 = "zrzrsadaddhfsfs"; }
        if (QuesQuestion05.IntExcl05True == 0) { EnqStringQues05 = "adaddhfsgsdgdsdg"; }
        else if (QuesQuestion05.IntExcl05True == 1) { EnqStringQues05 = "adadsgsdgdssfgsdfgsgetet"; }
        else if (QuesQuestion05.IntExcl05True == 2) { EnqStringQues05 = "dhfsfgsdfgssfsxgsdd"; }
        if (QuesQuestion06.IntExcl06True == 0) { EnqStringQues06 = "sgsdgdssfsdghfhd"; }
        else if (QuesQuestion06.IntExcl06True == 1) { EnqStringQues06 = "sfgsdfgsdggetetfsafa"; }
        else if (QuesQuestion06.IntExcl06True == 2) { EnqStringQues06 = "sfsgetetxgsddysfsay"; }
        if (QuesQuestion07.IntExcl07True == 0) { EnqStringQues07 = "dgxgsddhfhdfsfsaf"; }
        else if (QuesQuestion07.IntExcl07True == 1) { EnqStringQues07 = "getethfhdfsafakgkg"; }
        else if (QuesQuestion07.IntExcl07True == 2) { EnqStringQues07 = "xgsddfsafaysfsayfhdghs"; }
        if (SPQ01Question.IntSPQ01True == 0) { EnqStringSPQ01 = "hfhdysfsayfsfsaf479uj"; }
        else if (SPQ01Question.IntSPQ01True == 1) { EnqStringSPQ01 = "fsafafsfsafkgkgljl"; }
        else if (SPQ01Question.IntSPQ01True == 2) { EnqStringSPQ01 = "ysfsaykgkgfhdghspoipq"; }
        if (SPQ02.IntSPQ02True == 0) { EnqStringSPQ02 = "fsfsaffhdghs479ujlkl"; }
        else if (SPQ02.IntSPQ02True == 1) { EnqStringSPQ02 = "kgkg479ujljllkioaj"; }
        else if (SPQ02.IntSPQ02True == 2) { EnqStringSPQ02 = "fhdghsljlpoipqgzug"; }
        if (SPQ03.IntSPQ03True == 0) { EnqStringSPQ03 = "479ujpoipqlklsfs"; }
        else if (SPQ03.IntSPQ03True == 1) { EnqStringSPQ03 = "ljllkllkioajrt"; }
        else if (SPQ03.IntSPQ03True == 2) { EnqStringSPQ03 = "poipqlkioajgzugfsfw"; }
        if (SPQ04.IntSPQ04True == 0) { EnqStringSPQ04 = "lklgzugsfssfsa"; }
        else if (SPQ04.IntSPQ04True == 1) { EnqStringSPQ04 = "lkioajsfsrtfs"; }
        else if (SPQ04.IntSPQ04True == 2) { EnqStringSPQ04 = "gzugrtfsfwghdghe"; }
        if (SPQ05.IntSPQ05True == 0) { EnqStringSPQ05 = "sfsfsfwsfsafgsf"; }
        else if (SPQ05.IntSPQ05True == 1) { EnqStringSPQ05 = "rtsfsafsgs"; }
        else if (SPQ05.IntSPQ05True == 2) { EnqStringSPQ05 = "fsfwfsghdghegegtr"; }
        if (SPQ06.IntSPQ06True == 0) { EnqStringSPQ06 = "sfsaghdghefgsfnvnfv"; }
        else if (SPQ06.IntSPQ06True == 1) { EnqStringSPQ06 = "fsfgsfgssfse"; }
        else if (SPQ06.IntSPQ06True == 2) { EnqStringSPQ06 = "ghdghegsgegtrwfew"; }
        if (SPQ07.IntSPQ07True == 0) { EnqStringSPQ07 = "fgsfgegtrnvnfvsfs"; }
        else if (SPQ07.IntSPQ07True == 1) { EnqStringSPQ07 = "gsnvnfvsfseqeqw"; }
        else if (SPQ07.IntSPQ07True == 2) { EnqStringSPQ07 = "gegtrsfsewfewlulkz"; }
        if (SPQ08.IntSPQ08True == 0) { EnqStringSPQ08 = "nvnfvwfewsfsnvn"; }
        else if (SPQ08.IntSPQ08True == 1) { EnqStringSPQ08 = "sfsesfsqeqwnbm"; }
        else if (SPQ08.IntSPQ08True == 2) { EnqStringSPQ08 = "wfewqeqwlulkzoiuou"; }
        if (SPQ09.IntSPQ09True == 0) { EnqStringSPQ09 = "nvnoiuouüpoüwqeq"; }
        else if (SPQ09.IntSPQ09True == 1) { EnqStringSPQ09 = "nbmüpoüipipmwmfo"; }
        else if (SPQ09.IntSPQ09True == 2) { EnqStringSPQ09 = "oiuouipipljhklyimswp"; }
        if (SPQ10.IntSPQ10True == 0) { EnqStringSPQ10 = "üpoüljhklwqeqzwqufc"; }
        else if (SPQ10.IntSPQ10True == 1) { EnqStringSPQ10 = "ipipwqeqmwmfoizq"; }
        else if (SPQ10.IntSPQ10True == 2) { EnqStringSPQ10 = "ljhklmwmfoyimswp9879uhsai"; }
        if (SPQ11.IntSPQ11True == 0) { EnqStringSPQ11 = "wqeqyimswpzwqufch<auidia"; }
        else if (SPQ11.IntSPQ11True == 1) { EnqStringSPQ11 = "mwmfozwqufcizqcbyjbj"; }
        else if (SPQ11.IntSPQ11True == 2) { EnqStringSPQ11 = "yimswpizq9879uhsaijgajvc"; }
        if (SPQ12.IntSPQ12True == 0) { EnqStringSPQ12 = "zwqufc9879uhsaih<auidiaaidh"; }
        else if (SPQ12.IntSPQ12True == 1) { EnqStringSPQ12 = "izqh<auidiacbyjbjcgau"; }
        else if (SPQ12.IntSPQ12True == 2) { EnqStringSPQ12 = "9879uhsaicbyjbjjgajvcadcu"; }


        /*        if (_ToggleConsultation.IntConsultTrue == 1) { StringConsult = " I understand that contact will mainly be per email, " +
                        "but a skype or zoom session would be preferable to me when submitting " +
                        "my personal data and to know more about the experiment. I am aware " +
                        "that I will also be contacted per email shortly after the experiment." +
                        "(Personal details can be supplied here optionally, but can also be given during the initial online meeting) \r\n" +
                        "Surname: \r\n" +
                        "Forename: \r\n" +
                        "Age: \r\n" +
                        "Occupation: \r\n" +
                        "Student Y/N?: \r\n";}
                else
                {
                    StringConsult = " I prefer to have contact solely per email. " +
                        "If there are any relevant issues, I will contact the university. " +
                        "I am aware that a researcher may contact me shortly after the experiment " +
                        "for reasons of quality control and to ask if there are outstanding issues.\r\n" +
                        "My personal details are as follows: \r\n" +
                        "Surname: \r\n" +
                        "Forename: \r\n" +
                        "Age: \r\n" +
                        "Occupation: \r\n" +
                        "Student Y/N?: \r\n";
                }
        */



    }
}