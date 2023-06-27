# cowsay
ASCII-entities that can repeat phrases.

This repository contains the `Rumble.Cowsay` C# library and `Rumble.Cowsay.Tool` dotnet tool. The code in this repository is an original work created as a personal project, and serves as a .NET C# adaptation of the original cowsay program.

[![NuGet Package: Rumble.Cowsay](https://img.shields.io/nuget/vpre/Rumble.Cowsay?label=nuget%3A%20Rumble.Cowsay)](https://www.nuget.org/packages/Rumble.Cowsay)
[![NuGet Package: Rumble.Cowsay.Tool](https://img.shields.io/nuget/vpre/Rumble.Cowsay.Tool?label=nuget%3A%20Rumble.Cowsay)](https://www.nuget.org/packages/Rumble.Cowsay.Tool)

## Description

Cowsay is a fun and configurable speaking cow (not only) program. Originally developed for GNU/Linux, this C# adaptation brings the fun of the original cowsay to the .NET ecosystem.

## Usage

### Rumble.Cowsay Library

```csharp
using Rumble.Cowsay;

var entity = EchoingEntity.Cow;
Console.WriteLine(entity.Speak());
Console.WriteLine(entity.Echo("Hello, world!"));
```

### Rumble.Cowsay.Tool

To install the tool globally, use the following command:

```shell
dotnet tool install --global Rumble.Cowsay.Tool
```

Then, you can use the tool with the following commands:

```shell
# with default entity (cow)
$ cowsay
$ cowsay --phrase "Hello, World!"

# with specific entity (cow)
$ cowsay --entity-name cow
$ cowsay --entity-name cow --phrase "Hello, World!"

# with specific entity (elephant)
$ cowsay --entity-name elephant
$ cowsay --entity-name elephant --phrase "Hello, World!"
```

Also, you can get more information about the tool with the following commands:
```shell
# displays current version
$ cowsay --version

# displays help
$ cowsay -h
$ cowsay --help
```

## History

The original cowsay program, written in Perl, was created by Tony Monroe, with suggestions from Shannon Appel and contributions from Anthony Polito, as a whimsical program for GNU/Linux systems. It served as a creative output mechanism, generating ASCII art of a cow uttering the input text.

## Note

This project is made out of pure love for .NET C# and cowsay. It serves as a pet-project, therefore, don't expect it to do anything serious or solve any significant problems. It's a just-for-fun project. All the code here is 100% original.
