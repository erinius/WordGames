module Anagrams

open Words

let areAnagrams (w1: string) (w2: string) =
    let letterCount (w: string) =
        w.ToUpperInvariant() |> Seq.countBy id |> Set.ofSeq

    if w1.Length <> w2.Length then
        false
    else
        (letterCount w1) = (letterCount w2)

let findAnagrams (w: string) =
    w.Length |> wordsOfLength |> Seq.filter (areAnagrams w)

[<EntryPoint>]
let main args =
    let anagrams = findAnagrams args[0]

    for a in anagrams do
        printfn "%s" a

    0
