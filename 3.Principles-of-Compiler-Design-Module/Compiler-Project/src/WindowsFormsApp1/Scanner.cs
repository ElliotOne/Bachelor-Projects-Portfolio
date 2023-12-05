using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Scanner
    {
        List<List<int>> transRule = new List<List<int>>();
        public static Dictionary<int, string> dictValues = new Dictionary<int, string>();

        public static void MapData()
        {
            //Keyword 100
            //Identifier 200
            //Operator 300
            //String(Literal constant) 400
            //NumInt 500
            //NumFloat 600
            //SpecialChar 700 ,  ex : (


            //keyword
            dictValues.Add(100,"int");
            dictValues.Add(101, "double");
            dictValues.Add(102, "string");
            dictValues.Add(103, "char");
            dictValues.Add(104, "bool");
            dictValues.Add(105, "break");
            dictValues.Add(106, "case");
            dictValues.Add(107, "continue");
            dictValues.Add(108, "default");
            dictValues.Add(109, "switch");
            //Operator
            dictValues.Add(300,".");
            dictValues.Add(301, '"'.ToString());
            dictValues.Add(302,"\'");
            dictValues.Add(303, "_");
            dictValues.Add(304, "+");
            dictValues.Add(305, "=");
            dictValues.Add(306, "-");
            dictValues.Add(307, "%");
            dictValues.Add(308, "!");
            dictValues.Add(309, ">");
            dictValues.Add(310, "<");
            dictValues.Add(311, "/");
            //SpecialChar
            dictValues.Add(700, "(");
            dictValues.Add(701, ")");
            dictValues.Add(702, ";");
            dictValues.Add(703, "");
            dictValues.Add(704, "[");
            dictValues.Add(705, "]");
            dictValues.Add(706, "@");
        }
        private void getTransitions(string path)
        {
            string data = System.IO.File.ReadAllText(path);
            if (data.Length < 2)
            {
                throw new Exception();
            }
            foreach (var item in data.Split('\n'))
            {
                var temp = new List<int>();
                foreach (var itm in item.Trim().Split(' '))
                {
                    temp.Add(Convert.ToInt32(itm));
                }
                transRule.Add(temp);
            }
        }

        private int nextState(int iState, char ch)
        {
            if (char.IsLetter(ch))
                return transRule[iState][1];
            else if (char.IsDigit(ch))
                return transRule[iState][2];
            else if (ch == '.')
                return transRule[iState][3];
            else if (ch == '"')
                return transRule[iState][4];
            else if (ch == '\'')
                return transRule[iState][5];
            else if (ch == '_')
                return transRule[iState][6];
            else if (ch == '+')
                return transRule[iState][7];
            else if (ch == '=')
                return transRule[iState][8];
            else if (ch == '-')
                return transRule[iState][9];
            else if (ch == '%')
                return transRule[iState][10];
            else if (ch == '!')
                return transRule[iState][11];
            else if (ch == '>')
                return transRule[iState][12];
            else if (ch == '<')
                return transRule[iState][13];
            else if (ch == '/')
                return transRule[iState][14];
            return transRule[iState][0];
        }

        private bool isKeyword(string token)
        {
            if ((token).Length > 16 || (token).Length == 0)
                return false;
            var sKeywords = new List<string>(){
                //start from 100 - 109
                "int","double","string","char","bool","break","case","continue","default","switch"
            };
            return sKeywords.Exists(element => (token.ToLower()) == element);
        }



        public string Result(string txt, string src = @"transistionTable.txt")
        {
            try
            {
                getTransitions(src);
            }
            catch (Exception)
            {
                return "File not found.";
            }
            if (txt.Length == 0)
                return "";
            var result = "";
            int txtIndex = 0, iState = 0;
            char cTemp = txt[txtIndex], cChar = ' ';
            string sToken = "";
            bool flag = true;

            txt += " ";
            while (txtIndex != txt.Length)
            {
                if (flag)
                {
                    cChar = cTemp;
                    if (txt.Length - 1 == txtIndex)
                        return result + cChar;
                    cTemp = txt[++txtIndex];
                }
                else
                    flag = true;

  
                if (cChar == '/' && cTemp == '/')
                {
                    if (txt.Length - 1 == txtIndex)
                        return result;
                    while (txt[++txtIndex] != '\n')
                    {
                        if (txt.Length == txtIndex)
                            return result;
                    }
                    result += '\r';
                    if (txt.Length - 1 != txtIndex)
                        cTemp = txt[++txtIndex];
                    continue;
                }
                if (cChar == '/' && cTemp == '*')
                {
                    if (txt.Length - 1 == txtIndex)
                        return result;
                    cTemp = txt[++txtIndex];
                    do
                    {
                        cChar = cTemp;
                        if (txt.Length - 1 == txtIndex)
                            return result + cChar;
                        cTemp = txt[++txtIndex];
                    } while (cChar != '*' && cTemp != '/');
                    result += '\r';
                    if (txt.Length - 1 != txtIndex)
                        cTemp = txt[++txtIndex];
                    continue;
                }

                iState = nextState(iState, cChar);
                switch (iState)
                {
                    case 0:
                        if (dictValues.Values.Contains(cChar.ToString()))
                        {
                            var myKey = dictValues.FirstOrDefault(x => x.Value == cChar.ToString()).Key;
                            result += $"SpecialChar\t{cChar.ToString()}\t{myKey}\n";
                            iState = 0;
                            sToken = "";
                        }
                        break;
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 10:
                    case 14:
                    case 18:
                    case 25:
                    case 26:
                        sToken += cChar;
                        break;
                    case 2:
                        if (isKeyword(sToken))
                        {
                            if (dictValues.Values.Contains(sToken))
                            {
                                var myKey = dictValues.FirstOrDefault(x => x.Value == sToken).Key;
                                result += $"Keyword\t{sToken}\t{myKey}\n";
                            }
                        }
                            
                        else
                            result += $"Identifier\t{sToken}\t200\n";
                        iState = 0;
                        flag = false;
                        sToken = "";
                        break;
                    case 4:
                        result += $"NumInt\t{sToken}\t500\n";
                        iState = 0;
                        flag = false;
                        sToken = "";
                        break;
                    case 6:
                        result += $"NumFloat\t{sToken}\t600\n";
                        iState = 0;
                        flag = false;
                        sToken = "";
                        break;
                    case 8:
                        result += $"String\t{sToken}\t700\n";
                        iState = 0;
                        sToken = "";
                        break;
                    case 9:
                    case 11:
                    case 12:
                    case 13:
                    case 15:
                    case 16:
                    case 17:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 27:
                    case 28:
                        if (dictValues.Values.Contains(sToken))
                        {
                            var myKey = dictValues.FirstOrDefault(x => x.Value == sToken).Key;
                            result += $"Operator\t{sToken}\t{myKey}\n";

                            if (cChar != '+' && cChar != '-' && cChar != '/'
                           && cChar != '>' && cChar != '<' && cChar != '=')
                                flag = false;
                            iState = 0;
                            sToken = "";
                        }
                        break;
                    case 30:
                    case 33:
                        iState = 0;
                        sToken = "";
                        break;
                }
            }
            return result;
        }

    }
}
