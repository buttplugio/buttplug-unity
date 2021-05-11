# Buttplug Unity

[![openupm](https://img.shields.io/npm/v/com.nonpolynomial.buttplug-unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.nonpolynomial.buttplug-unity/)
[![Patreon donate button](https://img.shields.io/badge/patreon-donate-yellow.svg)](https://www.patreon.com/qdot)
[![Github sponsor button](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub)](https://github.com/sponsors/qdot)
[![Discord](https://img.shields.io/discord/353303527587708932.svg?logo=discord)](https://discord.buttplug.io)
[![Twitter](https://img.shields.io/twitter/follow/buttplugio.svg?style=social&logo=twitter)](https://twitter.com/buttplugio)

Unity Package for Buttplug support in Unity 2018.2+.

Buttplug Unity contains a Intiface CLI executable, so Intiface Desktop
is not required. It is still recommended that you allow users to
connect out to ID somehow, though.

## Installation

### Option #1: OpenUPM CLI

If you have the [OpenUPM command line interface](https://openupm.com/docs/getting-started.html#installing-openupm-cli)
installed, then this is the fastest way to add the package to your project:

- Open your Unity project folder in a terminal like CMD or PowerShell
- Run `openupm add com.nonpolynomial.buttplug-unity`

### Option #2: Edit Package Manager
If you don't have OpenUPM's CLI installed, you can manually perform the same steps in Unity 2019+.

Add the OpenUPM registry and Buttplug Unity's scope to Project Settings:
![image](https://user-images.githubusercontent.com/33731102/117752226-86a26800-b26a-11eb-998b-6e038eb19fe4.png)
- Go to `Edit > Project Settings > Package manager`
- Click the `+` button in the registry list
- Name it `OpenUPM`
- Set the URL to `https://package.openupm.com`
- Set the Scope to `com.nonpolynomial.buttplug-unity`
- Click `Apply`

Add the Buttplug Unity package in the Package Manager:
![image](https://user-images.githubusercontent.com/33731102/117750921-5b1e7e00-b268-11eb-80eb-0746c0cdf798.png)
- Go to `Window > Package Manager`
- Use the drop down in the upper left to select `My Registeries`
- Select the `ButtplugUnity` package
- Click `Install`

### Option #3: Manual Install of ButtplugUnity Package

You can also manually download and install the ButtplugUnity package, but you'll need to
check in all the package files into your project and you will need to manually remove and
re-import the package when you want to update the Buttplug Unity package version.

- Download the [Latest Buttplug Unity Package](https://package-installer.glitch.me/v1/installer/OpenUPM/com.nonpolynomial.buttplug-unity?registry=https%3A%2F%2Fpackage.openupm.com)
- In Unity, use `Assets > Import Package > Custom Package...`
- Open the downloaded package.
- Click `Import`

### Options #4: Clone This Project

This is a fully functional Unity project that you can clone as your own.

- Clone `https://github.com/buttplugio/buttplug-unity` with your favorite Git client
- Open root of the cloned project folder in Unity 2019.
- Open the `Example/Example.unity` scene file to run the example script.

## Usage

See the [Buttplug Unity example
directory](https://github.com/buttplugio/buttplug-unity/tree/master/Assets/Example) as
well as the [Buttplug Developer Guide](https://buttplug-developer-guide.docs.buttplug.io)
for code and usage advice.

Note that this repo is a complete Unity project that can be opened and run in Unity.

Using Buttplug consists of the following steps:

- Setting up a connector and client
- Connecting to a server
- Scanning for devices
- Controlling devices

For the first 3 of those steps, we provide helper methods in the
[ButtplugUnityHelper](https://github.com/buttplugio/buttplug-unity/blob/master/Packages/ButtplugUnity/Runtime/ButtplugUnityHelper.cs)
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
