module SpellingBeeSolver

open Words


let isValidWord (requiredBit: int) (allowedBits: int) (word: string) : bool =
    let givenBits = wordToBitfield word
    ((givenBits &&& requiredBit) <> 0) && ((givenBits &&& (~~~allowedBits)) = 0)

let wordChecker (requiredLetter: char) (allowedLetters: string) =
    let requiredBit = charToBitfield requiredLetter
    let allowedBits = requiredBit ||| wordToBitfield allowedLetters
    isValidWord requiredBit allowedBits

let SpellingBeeFilter (requiredLetter: char) (allowedLetters: string) (wordSeq: string seq) =
    let requiredUpper = requiredLetter |> System.Char.ToUpperInvariant
    let allowedUpper = allowedLetters.ToUpperInvariant()
    let checker = wordChecker requiredUpper allowedUpper

    wordSeq |> Seq.filter checker


[<EntryPoint>]
let main args =
    if Array.length args <> 2 then
        eprintfn "Usage: SpellingBeeSolver required-letter allowed-letters"
        eprintfn "For example: SpellingBeeSolver A BCD"
        1

    else
        let requiredLetter = args[0].Chars(0)

        let filteredSeq =
            GetWordsFromFile "../../words_alpha.txt"
            |> SpellingBeeFilter requiredLetter args[1]
            |> Seq.filter (fun w -> w.Length >= 4)

        for w in filteredSeq do
            printfn "%s" w

        0
