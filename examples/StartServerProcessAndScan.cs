// This is not a particularly good example, as process bringup and notification
// will be handled by the Buttplug Unity package itself soon. But, if you
// absolutely cannot wait to start playing with Buttplug and Unity, this is what
// you need to do in order to bring up the server, then connect the client to
// it.
//
// This is just a generic behavior, so you can attach it to any active object in
// your scene and it'll run on scene load.
using System;
using System.IO;
using System.Threading.Tasks;
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
        // We want to start the CLI process without a window, and capture output
        // from stdout at the moment just to see if it's alive. Crude, but it
        // does the job of making sure we don't try to connect before the
        // process spins up. This will change to using the Intiface Protobuf
        // system in the future.
        UnityEngine.Debug.Log(Application.streamingAssetsPath);
        var processPath = Path.Combine(Application.streamingAssetsPath, "Buttplug", "IntifaceCLI.exe");
        var processInfo = new ProcessStartInfo(processPath);
        processInfo.CreateNoWindow = true;
        processInfo.RedirectStandardOutput = true;
        processInfo.UseShellExecute = false;
        // 12345 is our default port. This should most likely choose a random
        // high port, and will most likely do so in the future.
        processInfo.Arguments = "--wsinsecureport 12345";
        serverProcess = Process.Start(processInfo);
        serverProcess.OutputDataReceived += OnServerStart;
        serverProcess.BeginOutputReadLine();
        UnityEngine.Debug.Log("Hi I am a cube that is starting up");
    }

    async void OnServerStart(object sender, DataReceivedEventArgs e) {
        serverProcess.OutputDataReceived -= OnServerStart;
        UnityEngine.Debug.Log("Got line, starting server");
        await StartClient();
    }

    async Task StartClient() {
        // We will probably handle client setup,
        var connector = new ButtplugWebsocketConnector(new Uri("ws://localhost:12345/buttplug"));
        client = new ButtplugClient("Example Client", connector);
        UnityEngine.Debug.Log("I am connecting.");

        // Here and below, if you want to block instead of dealing with async,
        // replace "await []" with "[].GetAwaiter().GetResult()". i.e.
        // "client.ConnectAsync().GetAwaiter().GetResult()"
        await client.ConnectAsync();
        UnityEngine.Debug.Log("I connected.");

        // This block will tell the server to send us all of the log messages it
        // generates, and routes them to the Unity console. Useful for
        // debugging, but also pretty spammy. Turn down the log level to Info if
        // you want less messages.
        client.Log += (aObj, aLogEvent) =>
            UnityEngine.Debug.Log($"{aLogEvent.Message.LogLevel}: {aLogEvent.Message.LogMessage}");
        await client.RequestLogAsync(ButtplugLogLevel.Debug);

        // Set up the device addition events so we can see in the console when
        // we connect to a device.
        client.DeviceAdded += (aObj, aDeviceEventArgs) =>
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Connected!");

        client.DeviceRemoved += (aObj, aDeviceEventArgs) =>
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Removed!");

        client.ScanningFinished += (aObj, aScanningFinishedArgs) =>
            UnityEngine.Debug.Log("Device scanning is finished!");
        await client.StartScanningAsync();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        // On object shutdown, disconnect the client and just kill the server
        // process. Server process shutdown will be cleaner in future builds.
        this.client?.DisconnectAsync().GetAwaiter().GetResult();
        this.client = null;
        this.serverProcess.Kill();
        UnityEngine.Debug.Log("I am destroyed now");

    }
}
