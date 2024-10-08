# Buttplug Unity

[![openupm](https://img.shields.io/npm/v/com.nonpolynomial.buttplug-unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.nonpolynomial.buttplug-unity/)
[![Patreon donate button](https://img.shields.io/badge/patreon-donate-yellow.svg)](https://www.patreon.com/qdot)
[![Github sponsor button](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub)](https://github.com/sponsors/qdot)
[![Discord](https://img.shields.io/discord/353303527587708932.svg?logo=discord)](https://discord.buttplug.io)
[![Twitter](https://img.shields.io/twitter/follow/buttplugio.svg?style=social&logo=twitter)](https://twitter.com/buttplugio)

Unity Package for Buttplug support in Unity 2019.4+.

**NOTE:** This package *may* work as far back as Unity 2018.2, but for anything before Unity 2019.4, you may need to provide your own Newtonsoft.Json.dll package. We now rely on the built-in library from unity by default.

Buttplug Unity is a repackage of the [Buttplug C# Libraries](https://github.com/buttplugio/buttplug-csharp) for Unity. 

Unlike older versions. Buttplug Unity v3 and later **DO NOT CONTAIN ANY EXECUTABLES OR WAYS TO ACCESS HARDWARE**. It is assumed that users will have [Intiface Central](https://intiface.com/central) installed.

It is highly recommended that developers check out the [Buttplug Developer Guide](https://docs.buttplug.io/docs/dev-guide) for more info on Buttplug architecture and usage before delving into using this package with their Unity project.

## Installation

### Option #1: OpenUPM CLI

If you have the [OpenUPM command line interface](https://openupm.com/docs/getting-started.html#installing-openupm-cli)
installed, then this is the fastest way to add the package to your project:

- Open your Unity project folder in a terminal like CMD or PowerShell
- Run `openupm add com.nonpolynomial.buttplug-unity`

### Option #2: Use OpenUPM's Installer Package

You can download and import the ButtplugUnity installer package which sets up the package reference and then removes itself.

- Download the [Latest Buttplug Unity Installer Package](https://package-installer.glitch.me/v1/installer/OpenUPM/com.nonpolynomial.buttplug-unity?registry=https%3A%2F%2Fpackage.openupm.com)
- In Unity, use `Assets > Import Package > Custom Package...`
- Open the downloaded package.
- Click `Import`

### Option #3: Edit Package Manager

You can also manually perform the setup steps in Unity 2019+.

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

### Options #4: Clone This Project

This is a fully functional Unity project that you can clone as your own. This will mean you have the Buttplug Unity package files locally,
so you'll need to manually update the package or pull latest from this project as updates are made.

- Clone `https://github.com/buttplugio/buttplug-unity` with your favorite Git client
- Open root of the cloned project folder in Unity >= 2019.
- Open the `Example/Example.unity` scene file to run the example script.

## Usage

See the [Buttplug Unity example
directory](https://github.com/buttplugio/buttplug-unity/tree/master/Assets/Example) as
well as the [Buttplug Developer Guide](https://docs.buttplug.io/docs/dev-guide)
for code and usage advice.

Note that this repo is a complete Unity project that can be opened and run in Unity.

Using Buttplug consists of the following steps:

- Setting up a connector and client
- Connecting to a server
- Scanning for devices
- Controlling devices

In Buttplug C# (which Buttplug Unity is built on), most of these are async
functions, as accessing both the network and the hardware are slow functions
that can block. We highly recommend executing tasks on background thread pools,
as not to interrupt game actions.

## FAQ

### What hardware will this work with?

An up-to-date list is kept at [IOSTIndex, using the Buttplug C#
filter](https://iostindex.com/?filtersChanged=1&filter0Availability=Available,DIY&filter1ButtplugSupport=4).

### Why do I have to run Intiface Central alongside my game?

[Intiface Central](https://intiface.com/central) is a cross platform application for running Buttplug servers and managing updates. Buttplug (the library) and Intiface (the official application layer on top of Buttplug) change frequently and allow for deep user configuration. Intiface Central manages those updates and configuration, meaning game devs only need to worry about connecting to Central and controlling devices.

Why not run hardware access inside the game process? By hosting hardware access externally, we
minimize the impact of errors and crashes on the game process. While we certainly do our best to
avoid errors, dealing with hardware can sometimes be a dynamic and challenging situation, where an
extended period of normal usage can be suddenly interrupted by shit going absolutely fucked. By
keeping process separation as a boundary, we can assure games that as much of the fuckery as
possible stays on the Buttplug side.

### Does Buttplug Unity work with IL2CPP?

Yes.

### Can I use Buttplug Unity in my commercial game?

Yes, Buttplug Unity falls under the same BSD 3-Clause license as the rest of the library, meaning
you just need a copyright acknowledgement in your game credits and license file. If you are
interested in featuring our logos on your loading screen (which we appreciate!), please contact us
on [Discord](https://discord.buttplug.io) or [Twitter](https://twitter.com/buttplugio) to discuss.

### How can I get direct support from the Buttplug developers for my game?

The Buttplug Developers are happy to consider paid support contracts. Please contact us on
[Discourse](https://discuss.buttplug.io), [Discord](https://discord.buttplug.io) or
[Twitter](https://twitter.com/buttplugio) to discuss.

### I don't see my question here, what should I do?

- File an issue on this repo
- [Check our forums](https://discuss.buttplug.io)
- [Join the Discord Server](https://discord.buttplug.io) and ask there

## Contributing

If you have issues or feature requests, [please feel free to file an issue on this repo](issues/).

We are not looking for code contributions or pull requests at this time, and will not accept pull
requests that do not have a matching issue where the matter was previously discussed. Pull requests
should only be submitted after talking to [qdot](https://github.com/qdot) via issues on this repo
(or on [discourse](https://discuss.buttplug.io) or [discord](https://discord.buttplug.io) if you
would like to stay anonymous and out of recorded info on the repo) before submitting PRs. Random PRs
without matching issues and discussion are likely to be closed without merging. and receiving
approval to develop code based on an issue. Any random or non-issue pull requests will most likely
be closed without merging.

If you'd like to contribute in a non-technical way, we need money to keep up with supporting the
latest and greatest hardware. We have multiple ways to donate!

- [Patreon](https://patreon.com/qdot)
- [Github Sponsors](https://github.com/sponsors/qdot)
- [Ko-Fi](https://ko-fi.com/qdot76367)

## License

This project is BSD 3-Clause licensed.

```text

Copyright (c) 2016-2024, Nonpolynomial, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of buttplug nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```