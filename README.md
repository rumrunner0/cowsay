# cowsay
ASCII-entities that can repeat phrases.

This repository contains the `Rumrunner0.Cowsay` class library and `Rumrunner0.Cowsay.Tool` CLI tool. All the content in the repository is an original work created as a personal project, and serves as a .NET C# adaptation of the original cowsay program.

[![License](https://img.shields.io/github/license/rumrunner0/cowsay?label=license)](https://github.com/rumrunner0/cowsay/blob/main/LICENSE)
[![NuGet Package: Rumrunner0.Cowsay](https://img.shields.io/nuget/v/Rumrunner0.Cowsay?label=nuget%3A%20Rumrunner0.Cowsay)](https://www.nuget.org/packages/Rumrunner0.Cowsay)
[![NuGet Package: Rumrunner0.Cowsay.Tool](https://img.shields.io/nuget/v/Rumrunner0.Cowsay.Tool?label=nuget%3A%20Rumrunner0.Cowsay.Tool)](https://www.nuget.org/packages/Rumrunner0.Cowsay.Tool)

## Description
Cowsay is a fun and configurable speaking cow (not only) program. Originally developed for GNU/Linux, this C# adaptation brings the fun of the original cowsay to the .NET ecosystem.

## Usage

### Rumrunner0.Cowsay Library

```csharp
using System;
using Rumrunner0.Cowsay;

var entity = EchoingEntity.Cow;
Console.WriteLine(entity.Speak());
Console.WriteLine(entity.Echo("Hello, world!"));
```

### Rumrunner0.Cowsay.Tool

To install the tool globally, use the following command:
```shell
$ dotnet tool install --global Rumrunner0.Cowsay.Tool
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

## Contributing
If you have any suggestions, ideas, or feedback to enhance the project, please feel free to create an issue. Your collaboration is welcomed to make this project a bit better.