//++++++++++++++
//Passwords.cs
//++++++++++++++
//Stores all passwords and activates program upon entry. Self explanatory. List can be expanded here.
//Check also subfolder Qurestionnaire/Passwordscript.cs. It looks as if this might be a copy. Make sure 
//you change the right file and delete the other
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passwords : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        string[] passwords = new string[162] {
        "94test",
        "95test",
        "96test",
        "97test",
        "98test",
        "99test",
        "100test",
        "102ecrk",
        "103yiut",
        "104ypxu",
        "105nify",
        "106eftg",
        "107mhzr",
        "108mnok",
        "109jqzf",
        "110kecq",
        "111nkqu",
        "112jsmh",
        "113hwyi",
        "114qbqu",
        "115pxpi",
        "116eulv",
        "117injj",
        "118gtci",
        "119cihf",
        "120holp",
        "121xfrc",
        "122qoku",
        "123lqxp",
        "124nlsv",
        "125fmuv",
        "126pcrv",
        "127hnaj",
        "128nkxm",
        "129cjzx",
        "130qsds",
        "131cjae",
        "132gdhb",
        "133iokn",
        "134czxm",
        "135them",
        "136sdcv",
        "137mlhg",
        "138ryqd",
        "139encc",
        "140kowl",
        "141iwvc",
        "142hwnx",
        "143brin",
        "144vjvs",
        "145owlt",
        "146azvr",
        "147doki",
        "148rykv",
        "149unke",
        "150zmjd",
        "151llzx",
        "152acbt",
        "153uiha",
        "154bmkd",
        "155ewxn",
        "156juey",
        "157bcnl",
        "158qqsb",
        "159lnvi",
        "160vkbi",
        "161xvkv",
        "162vlrw",
        "163nmnw",
        "164lovy",
        "165tyde",
        "166jgoc",
        "167ihbk",
        "168nobe",
        "169bmey",
        "170pekv",
        "171btgx",
        "172pkpq",
        "173fipm",
        "174mgjf",
        "175fdyx",
        "176wikh",
        "177rnah",
        "178jxyi",
        "179olxv",
        "180kjnm",
        "181nwwu",
        "182zokg",
        "183kdnc",
        "184amxg",
        "185wrdw",
        "186dpji",
        "187ktyl",
        "188iqqn",
        "189hzcn",
        "190mihx",
        "191bzti",
        "192ktyk",
        "193rjdk",
        "194iwxt",
        "195aozf",
        "196bydp",
        "197pvel",
        "198qbvx",
        "199xtnr",
        "200pgmr",
        "201hong",
        "202ymqv",
        "203grqc",
        "204frjd",
        "205ljck",
        "206gtwt",
        "207mznw",
        "208desc",
        "209cqem",
        "210bxkh",
        "211escp",
        "212gkjd",
        "213puno",
        "214yfcl",
        "215munw",
        "216etgw",
        "217hhiq",
        "218okab",
        "219lpvj",
        "220nmph",
        "221lyax",
        "222jawa",
        "223dqel",
        "224wiyt",
        "225duxu",
        "226irts",
        "227hwcf",
        "228ktlq",
        "229wtio",
        "230hvvf",
        "231rymh",
        "232xzpp",
        "233mgep",
        "234ucds",
        "235jsvm",
        "236lfwh",
        "237quwr",
        "238tgio",
        "239hpbd",
        "240verx",
        "241ytbv",
        "242blls",
        "243tfmm",
        "244bbay",
        "245oaev",
        "246puyx",
        "247jwvb",
        "248tejg",
        "249ezkg",
        "250bxeb",
        "251tizd",
        "252cvhi",
        "253ikcs",
        "254fxri",
        "255snba",
        "256kbea",
};

        string whatwastyped = "1234";

        string resultsfrompasswordcheck = System.Array.Find(passwords,
           element => element.Equals(whatwastyped));


        print("You typed " + whatwastyped);
        if (resultsfrompasswordcheck == null)
        {
            print("That is not the correct password. You're just guessing, you scoundral");
        }
        else
        {
            print("Well done! You have sucessfully used " + resultsfrompasswordcheck);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
