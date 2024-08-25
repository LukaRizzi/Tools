using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LanguageData
{
    public Dictionary<string, Dictionary<string, string>> ParseTSV()
    {
        var result = new Dictionary<string, Dictionary<string, string>>();

        var lines = File.ReadAllLines("Assets/Text.tsv");
        if (lines.Length == 0)
        {
            throw new Exception("TSV file is empty.");
        }

        // Split the header line to get the language keys
        var header = lines[0].Split('\t');

        // Initialize the result dictionary with language keys
        for (int j = 1; j < header.Length; j++)
        {
            if (!result.ContainsKey(header[j]))
            {
                result[header[j]] = new Dictionary<string, string>();
            }
        }

        // Fill in the data for each language
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split('\t');
            var id = values[0];

            for (int j = 1; j < header.Length; j++)
            {
                result[header[j]][id] = values[j];
            }
        }

        return result;
    }
}
