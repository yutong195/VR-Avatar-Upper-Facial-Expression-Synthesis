using UnityEngine;
using System.IO;

public static class CSVManager_woman {

    private static string reportDirectoryName = "Report_woman";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[52];
    private static string timeStampHeader = "time stamp";

#region Interactions

    public static void AppendToReport(string[] strings) {
        // VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            Debug.Log(finalString);
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport() {
        // VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath())) {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                // Debug.Log(finalString);
                if (finalString != "") {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

#endregion


#region Operations

    static void VerifyDirectory() {
         string dir = GetDirectoryPath();
         if (!Directory.Exists(dir)) {
             Directory.CreateDirectory(dir);
         }
     }

    static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }

#endregion


#region Queries

     static string GetDirectoryPath() {
         // Debug.Log(Application.dataPath);
         return Application.dataPath + "/" + reportDirectoryName;
     }

    static string GetFilePath() {
        //return Path.Combine(Application.persistentDataPath, reportFileName);
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp() {
        return System.DateTime.UtcNow.ToString();
    }

#endregion

}
