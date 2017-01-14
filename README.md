# Simulation

|Type|Status|
|---|:-:|
|Build|![Build status](https://devvy.visualstudio.com/_apis/public/build/definitions/a1626956-4a96-4b5d-850b-d2886d95b82f/3/badge)|
|NuGet (interface)| coming soon  |
|NuGet (runner)| coming soon  |

## Goal
Our goal is to make developing neural networks fun.

## Intro
We ([@kgroener](https://github.com/kgroener) and [@tomkuijsten](https://github.com/tomkuijsten)) started creating neural networks for fun, just to see if we could create them and teach them something. It actually worked pretty soon, but the it was kind of... boring. It was all console stuff and the only output we saw was ASCII art at best. That's no fun! @kgroener came up with the idea to create a game where you could "plugin" your neural network and see how good it was in certain situations. That's what sparked the idea of .... (project name)

## Get started
If you want to create your own "player" in the game, there are a few easy steps to follow:
- Get [visual studio](https://go.microsoft.com/fwlink/?LinkId=691978&clcid=0x409)
- Start a new library project (.net 4.6.1 and up, or .netstandard 1.4 and up)
- Install the [interface](...) and the [runner](...) packages
- Create a class and implement the ISpecimenFactory interface
- Build it
- Set the host.exe as startup project
- Run and see your specimen survive... or not

## Build it yourself
If you want to build this repo yourself, just use any Visual Studio 2015 (and up) edition.
