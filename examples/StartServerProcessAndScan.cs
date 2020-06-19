// This is not a particularly good example, as process bringup and notification
// will be handled by the package itself soon. But, if you absolutely cannot
// wait to start playing with Buttplug and Unity, this is what you need to do in
// order to bring up the server, then connect the client to it.
//
// This is just a generic behavior, so you can attach it to any active object in
// your scene and it'll run on scene load.
using System;
using System.IO;
using System.Diagnostics;
using UnityEngine;
using Buttplug.Core.Logging;
using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;

public class NewBehaviourScript : MonoBehaviour
{

    private ButtplugClient client;
    private Process serverProcess;
    // Start is called before the first frame update
    void Start()
    {

        UnityEngine.Debug.Log(Application.streamingAssetsPath);
        var processPath = Path.Combine(Application.streamingAssetsPath, "IntifaceCLI.exe");
        var processInfo = new ProcessStartInfo(processPath);
        processInfo.CreateNoWindow = true;
        processInfo.RedirectStandardOutput = true;
        processInfo.UseShellExecute = false;
        processInfo.Arguments = "--wsinsecureport 12345";
        serverProcess = Process.Start(processInfo);
        serverProcess.OutputDataReceived += OnServerStart;
        serverProcess.BeginOutputReadLine();
        UnityEngine.Debug.Log("Hi I am a cube that is starting up");
    }

    void OnServerStart(object sender, DataReceivedEventArgs e) {
        UnityEngine.Debug.Log("Got line, starting server");
        StartClient();
        serverProcess.OutputDataReceived -= OnServerStart;
    }

    void StartClient() {
        var connector = new ButtplugWebsocketConnector(new Uri("ws://localhost:12345/buttplug"));

        // ButtplugClient creation is the same as the last example. From here on out, things look
        // basically the same.
        client = new ButtplugClient("Example Client", connector);
        UnityEngine.Debug.Log("I am connecting.");
        client.ConnectAsync().GetAwaiter().GetResult();
        UnityEngine.Debug.Log("I connected.");

        client.Log += (aObj, aLogEvent) =>
            UnityEngine.Debug.Log($"{aLogEvent.Message.LogLevel}: {aLogEvent.Message.LogMessage}");
        client.RequestLogAsync(ButtplugLogLevel.Debug).GetAwaiter().GetResult();
        client.DeviceAdded += (aObj, aDeviceEventArgs) =>
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Connected!");

        client.DeviceRemoved += (aObj, aDeviceEventArgs) =>
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Removed!");

        client.ScanningFinished += (aObj, aScanningFinishedArgs) =>
            UnityEngine.Debug.Log("Device scanning is finished!");
        client.StartScanningAsync().GetAwaiter().GetResult();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        this.client?.DisconnectAsync().GetAwaiter().GetResult();
        this.client = null;
        this.serverProcess.Kill();
        UnityEngine.Debug.Log("I am destroyed now");

    }
}
