module Anagrams

open WordGames.Library.Anagrams

[<EntryPoint>]
let main args =
    let anagrams = findAnagrams args[0]

    for a in anagrams do
        printfn "%s" a

    0
