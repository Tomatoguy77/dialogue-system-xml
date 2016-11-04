using UnityEngine;
using System;
using System.Collections;
using System.Xml;

public class XMLreader
{

    private string[] choiceTest;
    public string[] ChoiceTest
    {
        get
        {
            return choiceTest;
        }
    }

    public string ReadXML(string FileName, string Path, string Node, int id)
    {
        var textFile = Resources.Load(FileName) as TextAsset;

        //Load xml file into memory
        XmlDocument XMLDoc = new XmlDocument();
        string xml = textFile.text;
        XMLDoc.LoadXml(xml);

        //start parsing xml
        XmlNodeList nodes = XMLDoc.SelectNodes(Path);

        return nodes[id].SelectSingleNode(Node).FirstChild.Value;
    }

    public string[] ReadSubnodes(string FileName, string Path, int id)
    {
        var textFile = Resources.Load(FileName) as TextAsset;

        //load xml into memory
        XmlDocument xmlDoc = new XmlDocument();
        string xml = textFile.text;
        xmlDoc.LoadXml(xml);

        //start parsing xml
        XmlNodeList nodes = xmlDoc.SelectNodes(Path);

        XmlNodeList subnodes = nodes[id].SelectNodes("Response");//find any subnodes with the response tag

        string[] choiceDescs = new string[subnodes.Count];

        choiceTest = new string[subnodes.Count];

        for (int i = 0; i < subnodes.Count; i++)
        {
            //Debug.Log(subnodes[i].FirstChild.Value + " " + subnodes[i].SelectSingleNode("@next").Value);

            choiceTest[i] = subnodes[i].SelectSingleNode("@next").Value;

            choiceDescs[i] = subnodes[i].FirstChild.Value;
        }

        return choiceDescs;

    }

}