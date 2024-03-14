module MakeWordLists

open System.IO
open Words

let wordsByLength = GetWords |> Seq.groupBy (fun w -> w.Length)

for (length, words) in wordsByLength do
    File.WriteAllLines($"../../word_lists/words_length_{length}.txt", words)
