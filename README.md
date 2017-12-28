# Textual Auto-Complete
![alt text](https://blairleduc.gallerycdn.vsassets.io/extensions/blairleduc/net-core-starters-pack/1.0.0/1510457372304/Microsoft.VisualStudio.Services.Icons.Default "dot net core project")

Textual Auto-Complete is an efficient, tiny library for auto-completing words.

  - Read training data (words, sentences, etc.)
  - Predictions with confidences
  - Magic

__Training Example__

```csharp
var processor = new CommandProcessor();
processor.Process("train: training data to train for training");
// Train:  training data to train for training
processor.Process("input: train");
// Input: "train" --> "training" (2), "train" (1)
```

__Summary__  
The processor may continue to be trained, indefinitely. Each occurence of a word increments the confidence of the match, making the word have higher priority during auto-completion.
