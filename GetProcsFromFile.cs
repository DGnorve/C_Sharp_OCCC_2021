//David Norvell
//OCCC C# Spring 2021 Online
//GetProcsFromFile.cs (Made it standalone because of how code-heavy it was)

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace FinalExam2
{
    public class GetProcsFromFile
    {

        public static List<Product> GetProductsFromXML()
        {
            string workingDir = Environment.CurrentDirectory;
            string projectTrueDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
            
            string pathXML = projectTrueDir + "//InventoryItems.xml";

            List<Product> procs = null;
            XmlReader ingest = getReader(pathXML);
            StringBuilder dismal = new StringBuilder(0);
            string procCode = null;
            string desc = null;
            string price = null;

            

            int Aelita = 0;
            //Yes this is straight copied from my InventoryMaintenance HW with minor alterations

            if(ingest != null)
            {
                procs = new List<Product>();
                while (ingest.Read())
                {
                    switch (ingest.NodeType)
                    {
                        case XmlNodeType.Element:
                            break;
                        case XmlNodeType.Text:
                            dismal.Append(ingest.Value + "|");
                            Aelita++;
                            if(Aelita == 3)
                           {
                                string temp = dismal.ToString();
                                string[] tempA = temp.Split("|");
                                procCode = tempA[0];
                                desc = tempA[1];
                                price = tempA[2];
                                procs.Add(new Product(procCode, desc, price));
                                dismal.Clear();
                                procCode = null;
                                desc = null;
                                price = null;
                                Aelita = 0;

                            }
                            break;
                        case XmlNodeType.CDATA:
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            break;
                        case XmlNodeType.Comment:
                            break;
                        case XmlNodeType.XmlDeclaration:
                            break;
                        case XmlNodeType.Document:
                            break;
                        case XmlNodeType.DocumentType:
                            break;
                        case XmlNodeType.EntityReference:
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
                ingest.Close();
                return procs;
            }
            else
                return procs;
        }



        public static XmlReader getReader(string x)
        {
            XmlReaderSettings init = new XmlReaderSettings();
            init.ConformanceLevel = ConformanceLevel.Document;
            init.IgnoreWhitespace = true;
            init.IgnoreComments = true;
            try
            {
                XmlReader temp = XmlReader.Create(x, init);
                return temp;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

            return null;
        }


        public static void outputList()
        {
            List<Product> data = GetProductsFromXML();
            for (int i = 0; i < data.Count; i++)
            {
                System.Console.WriteLine(data[i].Code + " " + data[i].Description + " " + data[i].price);
            }
        }

    }
}
