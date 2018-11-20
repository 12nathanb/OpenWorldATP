using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


[XmlRoot("ChunksData")]
public class SaveChunk : MonoBehaviour
{

    [XmlArray("Chunks"), XmlArrayItem("Chunk")]
    public List<GameObject> chunks = new List<GameObject>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(SaveChunk));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    
}
