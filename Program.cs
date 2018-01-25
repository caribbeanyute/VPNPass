using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace VPNPass
{
    class Program
    {    
        static void Main(string[] args)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://www.vpnme.me/freevpn.html");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            string newResult = result.Substring(result.IndexOf("<td>fr-open</td>"));
            string output = newResult.Substring(0, newResult.IndexOf("<td><strong>UDP Port:</strong></td>") + 1);
            // Fetches HTML from VPNME WEBSITE

            output = output.Replace("<td>", "");
            output = output.Replace("</td>", "");
            output = output.Replace("ca-open", "");
            output = output.Replace("<tr>", "");
            output = output.Replace("</tr>", "");
            output = output.Replace("</tr>", "");
            output = output.Replace("<", "");
            output = output.Replace("\t", "");
           
            // Removes Certain KEYWORDs and TABS(\t)

          
            sr.Close();

           string fileName = "temp.txt";

            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName,
                    output.ToString());

           
            // Further Removing of Key Words- Removes the Entire Line that contains the text Password
            string search_text = "Password";
            string n = "";
            
            StreamReader srx = File.OpenText("temp.txt");
            while ((output = srx.ReadLine()) != null)
            {
                if (!output.Contains(search_text))
                {
                    n += output + Environment.NewLine;
                }
               
            }
          srx.Close();
            File.WriteAllText("temp.txt", n);
           
            var lines = File.ReadAllLines("temp.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines("temp.txt", lines);
             // Removing Empty Spaces

            string line = null;
            int line_number = 0;
            int line_to_delete = 2;

            using (StreamReader reader = new StreamReader("temp.txt"))
            {
                using (StreamWriter writer = new StreamWriter("vpnmefr.txt"))

                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        line_number++;

                        if (line_number == line_to_delete)
                            continue;

                        if (line_number == 4)
                            continue;

                        writer.WriteLine(line);
                        //Removes Unnesary lines that were left behin

                      


                    }
                        reader.Close();
                        writer.Close();

                    File.Delete("temp.txt");
                }



            }


            }
        }












    }
























