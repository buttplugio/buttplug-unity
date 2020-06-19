using System.IO;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Startup {
    static Startup()
    {
        Debug.Log("Checking for Buttplug's Intiface Engine Executable");
        var engineExecutable = Path.GetFullPath("Packages/com.nonpolynomial.buttplug-unity/Executable/IntifaceCLI.exe");
        var engineExecutableFileInfo = new DirectoryInfo(Path.GetDirectoryName(engineExecutable)).GetFiles("IntifaceCLI.exe");
        long engineExecutableFileSize = 0;
        if (engineExecutableFileInfo.Length == 1) {
          // Get the file size. This isn't as good as hashing, but that would
          // block editor load since the file is 70+mb.
          engineExecutableFileSize = engineExecutableFileInfo[0].Length;
          Debug.Log($"Engine exists, file size: {engineExecutableFileSize}");
        } else {
          // We can't find our own executable, commense freakout.
          Debug.Log("Buttplug cannot find its own ass (or the Intiface Engine executable). Please contact developers and/or the nearest grown up.");
        }

        // Assets in StreamingAssets are just copied over wholesale, and we have
        // a direct reference to where that directory is via the Application
        // global. 
        var streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, "Buttplug");
        var targetExecutable = Path.Combine(streamingAssetsPath, "IntifaceCLI.exe");
        // If streaming assets path doesn't exist, create it.
        if (!Directory.Exists(streamingAssetsPath)) {
          Directory.CreateDirectory(streamingAssetsPath);
          Debug.Log($"Creating buttplug asset directory at {streamingAssetsPath}");
        } else {
          Debug.Log($"Buttplug Engine asset already exists, checking if update required.");
          // If the directory exists, check to see if it's the same executable
          // version
          var targetExecutableFileInfo = new DirectoryInfo(streamingAssetsPath).GetFiles("IntifaceCLI.exe");
          if (targetExecutableFileInfo.Length == 1) {
            if (targetExecutableFileInfo[0].Length == engineExecutableFileSize) {
              Debug.Log("File sizes match, skipping copy and assuming same version.");
              return;
            }
          }
        }

        try {
          Debug.Log($"Copying engine executable {engineExecutable} to {targetExecutable}");
          File.Copy(engineExecutable, targetExecutable, true);
          Debug.Log("Buttplug engine file copy successful");
        } catch (Exception e) {
          Debug.Log($"File copy failed: {e}");
        }
    }
}
