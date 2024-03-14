module Words

open System.IO

let inline charToBitfield (c: char) : int = 1 <<< (c - 'A' |> int)

let wordToBitfield (w: string) : int =
    let mutable bits = 0

    for c in w do
        bits <- bits ||| charToBitfield c

    bits

let GetWordsFromFile path =
    File.ReadLines path |> Seq.map (fun w -> w.ToUpperInvariant())

let path = "../../word_lists/words_alpha.txt"

let GetWords = GetWordsFromFile path