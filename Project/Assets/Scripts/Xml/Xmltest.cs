using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class Xmltest : MonoBehaviour {
    //this is the xml document
    [SerializeField]
    TextAsset Gameasset;

    static string CubeCharacter = "";
    static string Cylindercharacter = "";
    static string CapsuleCharacter = "";
    static string SphereCharacter = "";
    List<Dictionary<string, string>> levels = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;

    void Start() {
      
    }

    public void GetLevel()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Gameasset.text); // load the actual xml doc here
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level");  // creates an array

        foreach (XmlNode LevelInfo in levelsList)
        {
            XmlNodeList levelcontent = LevelInfo.ChildNodes;
            obj = new Dictionary<string, string>();
            foreach (XmlNode levelsitems in levelcontent)
            {
                if(levelsitems.Name == "name")
                {
                    obj.Add("name", levelsitems.InnerText);
                }
                if (levelsitems.Name == "tutorial")
                {
                    obj.Add("tutorial", levelsitems.InnerText);
                }
                if (levelsitems.Name == "object")
                {
                    switch (levelsitems.Attributes["name"].Value)
                    {
                        case "Cube": obj.Add("cube", levelsitems.InnerText);break;
                        case "Cylinder": obj.Add("cylinder", levelsitems.InnerText); break;
                        case "Capsule": obj.Add("Capsule", levelsitems.InnerText); break;
                        case "Sphere": obj.Add("Sphere", levelsitems.InnerText); break;


                    }

                    if (levelsitems.Name == "finaltext")
                    {
                        obj.Add("finalText",levelsitems.InnerText); 

                    }
                }
            }
         }
    }

   


	
}
