using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameCon : MonoBehaviour
{
    public Plant sprout;

    public GameObject testlabel;

    public GameObject inputBox;

    private string path;


    public void Start()
    {
        sprout = new Plant("null");
        sprout.setName("null");
        string filePath = Application.persistentDataPath + "/Save/";
        try
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            path = filePath + "1.xml";

        }
        catch (IOException ex)
        {
            Debug.Log(filePath);
        }
    }

    public void SaveButton()
    {
        string text = inputBox.GetComponent<InputField>().text;
        if (text != "" && text != null)
        {
            sprout.setName(text);
            testlabel.GetComponent<Text>().text = Application.persistentDataPath + "/Save/";
            //testlabel.GetComponent<Text>().text = sprout.getName();
            Save(sprout);
        }
        else
        {
            testlabel.GetComponent<Text>().text = "huhu";
        }

    }


    public void Save(Plant game)
    {
        Debug.Log("HAHA");
        Debug.Log("HAHA2");
        var serializer = new XmlSerializer(typeof(Plant));
        Debug.Log("HAHA3");
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, game);
        }
    }

    public void Load(GameObject gameobj)
    {
        var serializer = new XmlSerializer(typeof(Plant));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            sprout = serializer.Deserialize(stream) as Plant;
        }
        testlabel.GetComponent<Text>().text = sprout.getName();
    }


}
