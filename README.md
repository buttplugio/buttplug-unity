# Buttplug Unity

[![Patreon donate button](https://img.shields.io/badge/patreon-donate-yellow.svg)](https://www.patreon.com/qdot)
[![Github sponsor button](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub)](https://github.com/sponsors/qdot)
[![Discord](https://img.shields.io/discord/353303527587708932.svg?logo=discord)](https://discord.buttplug.io)
[![Twitter](https://img.shields.io/twitter/follow/buttplugio.svg?style=social&logo=twitter)](https://twitter.com/buttplugio)

Unity Package for Buttplug support in Unity 2018.2+.

Buttplug Unity contains a Intiface CLI executable, so Intiface Desktop
is not required. It is still recommended that you allow users to
connect out to ID somehow, though.

## Installation

- [Download latest zip or tgz from releases section](https://github.com/buttplugio/buttplug-unity/releases)
- In the Unity Project Window, go to *Window* > *Package Manager* and hit the
  "+" button. Choose either:
  - "Add Package from Disk" (if you downloaded and unzip'd the zip file), then
    choose the package.json file from buttplug-unity.
  - "Add Package from tarball" (if you downloaded the .tgz file).
  - **Please note that "Add Package from git repo" will not work, see FAQ for
    reasoning**.
- If using Unity 2018, you will need to restart Unity in order for the StreamingAssets additions to
  show up. Unity >= 2019 does not require this.
- Start using Buttplug classes in your scripts.

## Usage

See the [Buttplug Unity example
directory](https://github.com/buttplugio/buttplug-unity/tree/master/examples) as
well as the [Buttplug Developer Guide](https://buttplug-developer-guide.docs.buttplug.io)
for code and usage advice.

Using Buttplug consists of the following steps:

- Setting up a connector and client
- Connecting to a server
- Scanning for devices
- Controlling devices

For the first 3 of those steps, we provide helper methods in the
[ButtplugUnityHelper](https://github.com/buttplugio/buttplug-unity/blob/master/package/Runtime/ButtplugUnityHelper.cs)
file. See the comments in that file and the examples for usage
documentation.

In Buttplug C# (which Buttplug Unity is built on), most of these are async
functions, as accessing both the network and the hardware are slow functions
that can block. We highly recommend executing tasks on background thread pools,
as not to interrupt game actions. More examples related to this will be released
soon.

## FAQ

### What hardware will this work with?

An up-to-date list is kept at [IOSTIndex, using the Buttplug C#
filter](https://iostindex.com/?filtersChanged=1&filter0Availability=Available,DIY&filter1ButtplugSupport=4).

### How does the Buttplug Unity package change my Unity project?

When the Buttplug Unity package is loaded, it checks to see whether a [StreamingAssets
directory](https://docs.unity3d.com/Manual/StreamingAssets.html) already exists. If not, it creates
the directory, and under that, creates a Buttplug directory, to which it copies the Intiface CLI
executable. This allows us to make sure that Unity packages the executable with your game.

As of 1.0.0, in order to make usage as work-free as possible, this functionality is automatic and
there is no way to turn it off. If this affects your project in adverse ways, or if you would like
to have the option to only use [Intiface Desktop](https://intiface.com/desktop) versus handling the
binary yourself, please file an issue (or if one is already filed, add a +1 comment), and we'll try
to figure out another way to do this.

### Why do I have to run an outside process alongside my game?

By hosting hardware access externally, we minimize the impact of errors and crashes on the game
process. While we certainly do our best to avoid errors, dealing with hardware can sometimes be a
dynamic and challenging situation, where an extended period of normal usage can be suddenly
interrupted by shit going absolutely fucked. By keeping process separation as a boundary, we can
assure games that as much of the fuckery as possible stays on the Buttplug side.

### Does Buttplug Unity work with IL2CPP?

Yes.

### Can I use Buttplug Unity in my commercial game?

Yes, Buttplug Unity falls under the same BSD 3-Clause license as the rest of the library, meaning
you just need a copyright acknowledgement in your game credits and license file. If you are
interested in featuring our logos on your loading screen (which we appreciate!), please contact us
on [Discord](https://discord.buttplug.io) or [Twitter](https://twitter.com/buttplugio) to discuss.

### How can I get direct support from the Buttplug developers for my game?

The Buttplug Developers are happy to consider paid support contracts. Please contact on
[Discord](https://discord.buttplug.io) or [Twitter](https://twitter.com/buttplugio) to discuss.

### I don't see my question here, what should I do?

- File an issue on this repo
- [Join the Discord Server](https://discord.buttplug.io) and ask there
