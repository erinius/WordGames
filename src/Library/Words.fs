module WordGames.Library.Words

open System.IO

let inline charToBitfield (c: char) : int = 1 <<< (c - 'A' |> int)

let wordToBitfield (w: string) : int =
    let mutable bits = 0

    for c in w do
        bits <- bits ||| charToBitfield c

    bits

let GetWordsFromFile path =
    File.ReadLines path |> Seq.map (fun w -> w.ToUpperInvariant()) |> Seq.cache

let wordListsDir = Path.Join(__SOURCE_DIRECTORY__, "..", "..", "word_lists")
let mainListPath = Path.Join(wordListsDir, "words_alpha.txt")

let GetWords = GetWordsFromFile mainListPath

let wordsOfLength (length: int) =
    GetWordsFromFile (Path.Join(wordListsDir, $"words_length_{length}.txt"))
