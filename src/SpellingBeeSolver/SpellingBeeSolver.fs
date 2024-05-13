module SpellingBeeSolver

open WordGames.Library.SpellingBee

[<EntryPoint>]
let main args =
    if Array.length args <> 2 then
        eprintfn "Usage: SpellingBeeSolver required-letter allowed-letters"
        eprintfn "For example: SpellingBeeSolver A BCD"
        1

    else
        let filteredSeq = getSolutionsFromArgs args[0] args[1]

        for w in filteredSeq do
            printfn "%s" w

        0
