using UnityEngine;
using System.Collections;

public class XMLShow : MonoBehaviour
{
    private XMLreader xmlreader = new XMLreader();

    [SerializeField]
    private GameObject button;
    [SerializeField]
    private string file;
    [SerializeField]
    private string path;
    [SerializeField]
    private string node;
    [SerializeField]
    private int id;

    // Use this for initialization
    void Start()
    {
        Debug.Log("help");
        xmlreader.ReadXML(file, path, node, id);
        Debug.Log(xmlreader.ReadXML(file, path, node, id));

        string[] playerPosibilities = xmlreader.ReadSubnodes(file, path, id);

        for (int i = 0; i < xmlreader.ReadSubnodes(file,path+ "/Greetings", id).Length; i++)
        {
            var choiceButton = (GameObject)Instantiate(button, new Vector3(0,100 + (50 * i),0),Quaternion.identity);
            choiceButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform,false); 
            TextChanger textChanger = choiceButton.GetComponent<TextChanger>();
            textChanger.ChangeText(xmlreader.ReadSubnodes(file, path + "/Greetings", id)[i]);
            Debug.Log(xmlreader.ReadSubnodes(file, path + "/Greetings", id)[i]);

        }

    }
}
	

