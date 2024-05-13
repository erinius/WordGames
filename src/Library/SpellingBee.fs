module WordGames.Library.SpellingBee

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

let getSolutions (requiredLetter: char) (allowedLetters: string) =
    GetWords
    |> Seq.filter (fun w -> w.Length >= 4)
    |> SpellingBeeFilter requiredLetter allowedLetters

let getSolutionsFromArgs (requiredLetterString: string) (allowedLetters: string) : string seq =
    let requiredLetter = requiredLetterString.Chars(0)

    getSolutions requiredLetter allowedLetters
