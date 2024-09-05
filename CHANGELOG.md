# 3.1.0 (2024-09-05)

## Breaking Changes

- Client device command tuple calls changed to requiring class structures. If you were actually
  using the tuple calls, PLEASE GET AHOLD OF ME, everyone I asked wasn't and I'm very curious if they were useful. I can't personally see how they were.
- Websockets are now included in this library, in the Buttplug.Client namespace.

## Features

- Update to Buttplug C# v3.1.0
  - Moves websockets to Buttplug.Client module
  - Removes extra dependencies for Websockets
  - Removes uses of System.ValueTuple

# 3.0.1 (2023-06-18)

## Features

- Update to C# v3.0.1, mostly bug fixes

## Bugfixes

- Add package dependencies that were missing for running on Unity < 2020

# 3.0.0 (2023-02-05)

## Breaking Changes

- Remove IntifaceCLI executable, expect that users will now connect to Intiface Central.

## Features

- Update to Buttplug C# v3.0
  - Returns to working with pure native C# libraries, no more architecture-specific Rust FFI
    required.
  - Basically make this a copy of the nuget package
  - Probably piss off devs but it's either do that or just drop this project completely

# v2.1.1 (2021-05-14)

## Features

- Update to Buttplug C# v2.0.2, fixes some crashes relating to the logging system

# v2.1.0 (2021-05-10)

## Features

- Update repo for OpenUPM support

# v2.0.0 (2021-04-24)

## Features

- Add support for raw commands
- Add support for connector type selection

# v1.0.0 (2020-04-22)

## Features

- Update to Buttplug C# v1

# v0.0.1 (2020-06-18)

## Features

- Initial release, built on Buttplug C# 0.5.9
- Simple shim between Unity and Buttplug C#