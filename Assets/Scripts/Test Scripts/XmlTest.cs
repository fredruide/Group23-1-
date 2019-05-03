using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XmlTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Hero knight = new Hero();
        knight.name = "Knight of Solamnia";
        knight.isBoss = true;
        knight.hitPoints = 122;
        knight.baseDamage = 50f;

        XmlSerializer serializer = new XmlSerializer(typeof(Hero));
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/hero.xml");
        serializer.Serialize(writer.BaseStream, knight);
        writer.Close();

    }
}

public class XMLOp
{
    public static void Serialize(object item, string path)
    {
        Hero knight = new Hero();
        knight.name = "Knight of Solamnia";
        knight.isBoss = true;
        knight.hitPoints = 100;
        knight.baseDamage = 50f;

        XmlSerializer serializer = new XmlSerializer(typeof(Hero));
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }
}

public class XMLSerializer : MonoBehaviour
{

}

public class Hero
{
    public string name;
    public bool isBoss;
    public int hitPoints;
    public float baseDamage;
}
