// <copyright file="ButtplugUnityClientOptions.cs" company="Nonpolynomial Labs LLC">
// Buttplug Unity Source Code File - Visit https://buttplug.io for more info about the project.
// Copyright (c) Nonpolynomial Labs LLC. All rights reserved.
// Licensed under the BSD 3-Clause license. See LICENSE file in the project root for full license information.
// </copyright>
using System;

namespace ButtplugUnity {
  public class ButtplugUnityOptions {
    // Client name. Not particularly useful unless you're connecting out to
    // Intiface Desktop, but if you are it will show up in the Intiface Desktop
    // GUI.
    public string ClientName = "Buttplug Unity Client";
    
    // If true, have our functions run the server process on connect. Otherwise,
    // assume we're connecting to Intiface Desktop.
    public bool UseServerProcess = true;

    // If using our own server process, set the ping time. A value of 0 means
    // the ping checker is turned off. Ping time will make the server drop a
    // connection and shut down all devices if a ping isn't received in a
    // certain amount of time. The ButtplugClient class handles ping sending
    // automatically, but this is useful as a watchdog in case of thread locks,
    // crashes, etc.
    public uint ServerPingTime = 0;

    // Address of the server to connect to. Will usually just be localhost
    // unless you are for some reason connecting out to a remote server.
    public string WebsocketAddress = "localhost";

    // Port that the client should try to connect to. 0 implies that we're
    // running a server process internally (i.e. UseServerProcess is true), in
    // which case we'll just choose a random high number port.
    public ushort WebsocketInsecurePort = 0;

    // If true, this will cause ButtplugUnity's convenience functions to log to
    // the Unity console. Handy when things are going wrong.
    public bool OutputDebugMessages = false;
  }
}