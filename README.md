# Textual Auto-Complete
![alt text](https://blairleduc.gallerycdn.vsassets.io/extensions/blairleduc/net-core-starters-pack/1.0.0/1510457372304/Microsoft.VisualStudio.Services.Icons.Default "dot net core logo")
.NET Core App 1.1  

Textual Auto-Complete is an efficient, tiny library for auto-completing words.

  - Read training data (words, sentences, etc.) into trie data-structure
  - Ordered predictions with confidence values
  - Magic

__Summary__  
The processor may continue to be trained, indefinitely. Each occurence of a word increments the confidence of the match, making the word have higher priority during auto-completion.

__Command Line Example__

```
train: training data to train for training
#Train: training data to train for training
input: train
#Input: "train" --> "training" (2), "train" (1)
```

__C# Example (Not Implemented For Consumption, Yet)__

```csharp
var processor = new CommandProcessor();
processor.Process("train: training data to train for training");
// Train:  training data to train for training
processor.Process("input: train");
// Input: "train" --> "training" (2), "train" (1)
```

__Build Instructions__  
On a platform with .NET Core App 1.1 installed, build and run the solution.
