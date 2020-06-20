# Buttplug Unity

[![Patreon donate button](https://img.shields.io/badge/patreon-donate-yellow.svg)](https://www.patreon.com/qdot)
[![Github sponsor button](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub)](https://github.com/sponsors/qdot)
[![Discourse Forum](https://img.shields.io/badge/discourse-forum-blue.svg)](https://metafetish.club)
[![Discord](https://img.shields.io/discord/353303527587708932.svg?logo=discord)](https://discord.buttplug.io)
[![Twitter](https://img.shields.io/twitter/follow/buttplugio.svg?style=social&logo=twitter)](https://twitter.com/buttplugio)

Unity Package for Buttplug support in Unity 2018.2+.

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

- [Download latest zip or tgz from releases section](https://github.com/buttplugio/buttplug-unity/releases)
- In the Unity Project Window, go to *Window* > *Package Manager* and hit the
  "+" button. Choose either:
  - "Add Package from Disk" (if you downloaded and unzip'd the zip file), then
    choose the package.json file from buttplug-unity.
  - "Add Package from tarball" (if you downloaded the .tgz file).
  - **Please note that "Add Package from git repo" will not work, see FAQ for
    reasoning**.
- If using Unity 2018, you will need to restart Unity in order for the
  StreamingAssets additions to show up. Unity 2019 does not require
  this.
- Start using Buttplug classes in your scripts.

## Usage

During the initial phase of rollout, Buttplug Unity will be updated frequently
and the API will change often. Any updates to the minor version (X in 0.X.Y)
will denote a breaking API change.

See the [Buttplug Unity example
directory](https://github.com/buttplugio/buttplug-unity/tree/master/examples) as
well as the [Buttplug C#
examples](https://github.com/buttplugio/buttplug-csharp#library-usage-examples)
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
filter](https://iostindex.com/?filter0ButtplugSupport=1).

### How does the Buttplug Unity package change my Unity project?

When the Buttplug Unity package is loaded, it checks to see whether a
[StreamingAssets
directory](https://docs.unity3d.com/Manual/StreamingAssets.html) already exists.
If not, it creates the directory, and under that, creates a Buttplug directory,
to which it copies the Intiface CLI executable. This allows us to make sure that
Unity packages the executable with your game.

As of 0.0.1, in order to make usage as work-free as possible, this functionality
is automatic and there is no way to turn it off. If this affects your project in
adverse ways, or if you would like to have the option to only use [Intiface
Desktop](https://intiface.com/desktop) versus handling the binary yourself,
please file an issue (or if one is already filed, add a +1 comment), and we'll
try to figure out another way to do this.

### Why do I have to run an outside process alongside my game?

On windows, we use UWP to access bluetooth, which is how most sex toys
communicate with hosts. Direct linking UWP into Unity is an issue right now, so
we host this code in an external process.

By hosting hardware access externally, we also minimize the impact of errors and
crashes on the game process. While we certainly do our best to avoid errors,
dealing with hardware can sometimes be a dynamic and challenging situation,
where an extended period of normal usage can be suddenly interrupted by shit
going absolutely fucked. By keeping process separation as a boundary, we can
assure games that as much of the fuckery as possible stays on the Buttplug side.

### Why is the executable 75mb?

At the moment, Buttplug Unity is built on top of the [Buttplug
C#](https://github.com/buttplugio/buttplug-csharp) implementation of the
[Buttplug Protocol Standard](https://buttplug-spec.docs.buttplug.io). In order
to distribute this in a way that is both simple to package and requires the
least amount of work for Unity, we use .Net Core App 3.1 with the Single File
packing option. This means we bundle all of our dependencies down to the
framework level into the executable, which makes for a large binary.

At some point in the near-to-medium future, we will be moving to [Buttplug
Rust](https://github.com/buttplugio/buttplug-rs) for our main implementation,
which should reduce the binary size by at least 10x if not more. This should
have no effect on games built with Buttplug Unity, other than reduced binary
sizes.

### Does Buttplug Unity work with IL2CPP?

Not yet. See
[https://github.com/buttplugio/buttplug-unity/issues/1](https://github.com/buttplugio/buttplug-unity/issues/1).

### Why can't I add the package from a git repo?

Due to the large binaries required for the package, keeping Buttplug-Unity
completely in a git repo would make the repo very large, very fast. Therefore we
only keep text files in the repo, and bring in binaries as part of our build
process.

### Can I use Buttplug Unity in my commercial game?

Yes, Buttplug Unity falls under the same BSD 3-Clause license as the
rest of the library, meaning you just need a copyright acknowledgement
in your game credits and license file. If you are interested in
featuring our logos on your loading screen (which we appreciate!),
please contact us on [Discord](https://discord.buttplug.io) or
[Twitter](https://twitter.com/buttplugio) to discuss.

### How can I get direct support from the Buttplug developers for my game?

The Buttplug Developers are happy to consider paid support contracts.
Please contact on [Discord](https://discord.buttplug.io) or
[Twitter](https://twitter.com/buttplugio) to discuss.

### I don't see my question here, what should I do?

- File an issue on this repo
- [Join the Discord Server](https://discord.buttplug.io) and ask there
