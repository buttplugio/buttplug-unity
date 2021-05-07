// Starts up a Buttplug Server, creates a client, connects to it, and has that
// client run a device scan. All output goes to the Unity Debug log.
//
// This is just a generic behavior, so you can attach it to any active object in
// your scene and it'll run on scene load.

using System;
using System.Collections.Generic;
using Buttplug;
using ButtplugUnity;
using UnityEngine;

public class StartServerProcessAndScan : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float intensity = 0.5f;

    private ButtplugUnityClient client;

    public List<ButtplugClientDevice> Devices { get; } = new List<ButtplugClientDevice>();

    private async void Start()
    {
        client = new ButtplugUnityClient("Test Client");
        Log("Trying to create client");

        // Set up client event handlers before we connect.
        client.DeviceAdded += AddDevice;
        client.DeviceRemoved += RemoveDevice;
        client.ScanningFinished += ScanFinished;

        // Try to create the client.
        try {
            await ButtplugUnityHelper.StartProcessAndCreateClient(client, new ButtplugUnityOptions {
                // Since this is an example, we'll have the unity class output everything its doing to the logs.
                OutputDebugMessages = true,
            });
        }
        catch (ApplicationException e) {
            Log("Got an error while starting client");
            Log(e);
            return;
        }

        await client.StartScanningAsync();
    }

    private async void OnDestroy()
    {
        Devices.Clear();

        // On object shutdown, disconnect the client and just kill the server
        // process. Server process shutdown will be cleaner in future builds.
        if (client != null)
        {
            client.DeviceAdded -= AddDevice;
            client.DeviceRemoved -= RemoveDevice;
            client.ScanningFinished -= ScanFinished;
            await client.DisconnectAsync();
            client.Dispose();
            client = null;
        }

        ButtplugUnityHelper.StopServer();
        Log("I am destroyed now");
    }

    private void OnValidate()
    {
        UpdateDevices();
    }

    private void UpdateDevices()
    {
        foreach (ButtplugClientDevice device in Devices)
        {
            device.SendVibrateCmd(intensity);
        }
    }

    private void AddDevice(object sender, DeviceAddedEventArgs e)
    {
        Log($"Device {e.Device.Name} Connected!");
        Devices.Add(e.Device);
        UpdateDevices();
    }

    private void RemoveDevice(object sender, DeviceRemovedEventArgs e)
    {
        Log($"Device {e.Device.Name} Removed!");
        Devices.Remove(e.Device);
        UpdateDevices();
    }

    private void ScanFinished(object sender, EventArgs e)
    {
        Log("Device scanning is finished!");
    }

    private void Log(object text)
    {
        Debug.Log("<color=red>Buttplug:</color> " + text, this);
    }
}