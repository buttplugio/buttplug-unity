# Buttplug Unity

Unity Package for Buttplug support in Unity 2019.1+.

Only the following classes should be used:

- ButtplugClient
- ButtplugWebsocketConnector

Trying to use an embedded connector will fail as no
DeviceSubtypeManagers are distributed with this package (UWP doesn't
play well with Unity, so you wouldn't get Bluetooth anyways). It is
expected that anything built with this will either connect to
[Intiface Desktop](https://github.com/intiface/intiface-desktop) or
[Intiface CLI](https://github.com/intiface/intiface-cli-csharp).

Buttplug Unity contains a Intiface CLI executable, so Intiface Desktop
is not required. It is still recommended that you allow users to
connect out to ID somehow, though.

## Installation

- [Download latest zip from releases section](https://github.com/buttplugio/buttplug-unity/releases)
- Unzip somewhere
- In Unity Project Frame, right click "Assets" > "Import Package" > "Custom Package"
- Choose package.json from buttplug-unity.
- Start using Buttplug classes in your scripts
