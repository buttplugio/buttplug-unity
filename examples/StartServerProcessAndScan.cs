// Starts up a Buttplug Server, creates a client, connects to it, and has that
// client run a device scan. All output goes to the Unity Debug log.
//
// This is just a generic behavior, so you can attach it to any active object in
// your scene and it'll run on scene load.
using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine;
using ButtplugUnity;
using Buttplug.Core.Logging;
using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;

public class StartServerProcessAndScan : MonoBehaviour
{

    private ButtplugClient client;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Starting cube");
        // Setting up the client can take a while, so we spawn that task off to a thread.
        Task.Run(StartClient);
    }

    async Task StartClient() {
        UnityEngine.Debug.Log("Trying to create client");
        // Try to create the client. 
        ButtplugClient client = null;
        try {
          client = await ButtplugUnityHelper.StartProcessAndCreateClient(new ButtplugUnityOptions {
            // Since this is an example, we'll have the unity class output everything its doing to the logs.
            OutputDebugMessages = true,
          });
        } catch (Exception e) {
            UnityEngine.Debug.Log(e);
            return;
        }

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
        ButtplugUnityHelper.StopServer();
        UnityEngine.Debug.Log("I am destroyed now");

    }
}
