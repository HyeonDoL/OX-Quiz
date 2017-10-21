using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Parser : MonoBehaviour
{
    public static List<string[]> Parse(string fileName)
    {
        string filePath = Application.dataPath + "/" + fileName + ".txt";

        FileStream fs = new FileStream(filePath, FileMode.Open);
        StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default, true);

        List<string[]> quizList = new List<string[]>();

        string source = sr.ReadLine();

        string[] values;

        while (source != null)
        {
            values = source.Split('^');

            if (values.Length == 0)
            {
                sr.Close();
                break;
            }

            quizList.Add(values);

            source = sr.ReadLine();
        }

        return quizList;
    }
}