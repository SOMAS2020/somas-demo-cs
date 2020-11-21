## What am I looking at?

The C# MWE.

## Structure

### `Source/Clients`
Each subfolder will contain all of the code for each team. e.g, `Source/Clients/Team1` will contain all the client code for Team1

### `Source/Server`
Code for the server

### `Source/Common`
Shared code including interfaces, structs etc.


## Setting up
### C#
- Using C#9 with .NET 5.0
- Download the SDK from here https://dotnet.microsoft.com/download/dotnet/5.0

### Running the code
- `dotnet run`


## Some config things

This csproj is setup to use the new nullable feature from C#8, as well as treating those warnings as errors

What this means is that _all_ types are by default non nullable and will compile time error if assigned to null. To make them nullable, you must now use `?` after the type. The compiler will then in those cases _still_ complain if the variable is dereferenced without first checking that it is non null. This means nulls are still usable where appropriate, but becomes very hard to accidentally run into a null reference exception

## Thoughts on C#

- Server and clients are completely decoupled through interfaces (and a bit of reflection to find the client types) which is good
- Built in strong typing
- Not that hard to learn with some basic C++/Java knowledge and you don't need to foray into many details; compiler has useful errors which should make it easy to learn as you go
- Fairly speedy
- Solid async/await solution built into the language, but perhaps a little confusing to see Task everywhere when you haven't yet learnt the language. Not easy to call async code from sync code.



## F#?

Both C# and F# turn into the same IL and run under the same runtime, so they should be able to interop seamlessly. This means groups could create their part in F# if they want to and it should work fine, but might need to fiddle around with a multi csproj/fsproj solution. This _also_ means people could use VisualBasic or Visual C++ (not the same as C++), but I assume no one wants to do that