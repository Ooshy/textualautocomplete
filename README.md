# Textual Auto-Complete
![alt text](https://blairleduc.gallerycdn.vsassets.io/extensions/blairleduc/net-core-starters-pack/1.0.0/1510457372304/Microsoft.VisualStudio.Services.Icons.Default "dot net core logo")
.NET Core App 1.1  

[![Travis](https://img.shields.io/travis/rust-lang/rust.svg)](https://travis-ci.org/Ooshy/textualautocomplete/)

Textual Auto-Complete is an efficient, tiny library for auto-completing words.

  - Read training data (words, sentences, etc.) into trie data-structure
  - Ordered predictions with confidence values
  - Magic

__Summary__  
The processor may continue to be trained, indefinitely. Each occurence of a word increments the confidence of the match, making the word have higher priority during auto-completion.

__C# Example__

```csharp
var ac = new AutoCompleteProvider(new Trie<string>(), new TrieNodeFactory<string>());
ac.Train("The third thing that I need to tell you is that this thing does not think thoroughly.");
var words = ac.GetWords("thi");
// {"thing"(2), "think"(1), "third"(1), "this"(1)}
```

__How To Get__  
From NuGet, via __Common.AutoComplete__ package.

__Build Instructions__  
On a platform with .NET Core App 1.1.2 installed, build and run the solution.

Runtime can be downloaded from [here](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.1.2-download.md).  