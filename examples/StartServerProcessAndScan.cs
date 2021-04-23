// Starts up a Buttplug Server, creates a client, connects to it, and has that
// client run a device scan. All output goes to the Unity Debug log.
//
// This is just a generic behavior, so you can attach it to any active object in
// your scene and it'll run on scene load.
using System;
using UnityEngine;
using ButtplugUnity;

public class StartServerProcessAndScan : MonoBehaviour
{

    private ButtplugUnityClient client;

    // Start is called before the first frame update
    async void Start() {
        client = new ButtplugUnityClient("Test Client");
        UnityEngine.Debug.Log("Trying to create client");

        // Set up client event handlers before we connect.
        client.DeviceAdded += async (aObj, aDeviceEventArgs) => {
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Connected!");
            await aDeviceEventArgs.Device.SendVibrateCmd(0.5);
        };

        client.DeviceRemoved += (aObj, aDeviceEventArgs) =>
            UnityEngine.Debug.Log($"Device {aDeviceEventArgs.Device.Name} Removed!");

        client.ScanningFinished += (aObj, aScanningFinishedArgs) =>
            UnityEngine.Debug.Log("Device scanning is finished!");

        // Try to create the client.
        try {
          await ButtplugUnityHelper.StartProcessAndCreateClient(client, new ButtplugUnityOptions {
            // Since this is an example, we'll have the unity class output everything its doing to the logs.
            OutputDebugMessages = true,
          });
        } catch (ApplicationException e) {
            UnityEngine.Debug.Log("Got an error while starting client");
            UnityEngine.Debug.Log(e);
            return;
        }
        
        await client.StartScanningAsync();
    }

    // Update is called once per frame
    void Update()
    {
    }

    async void OnDestroy()
    {
        // On object shutdown, disconnect the client and just kill the server
        // process. Server process shutdown will be cleaner in future builds.
        await this.client?.DisconnectAsync();
        this.client?.Dispose();
        this.client = null;
        ButtplugUnityHelper.StopServer();
        UnityEngine.Debug.Log("I am destroyed now");
    }
}
