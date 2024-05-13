module WordGames.Library.Anagrams

open Words

/// <summary>Determines if two strings are anagrams</summary>
/// <param name="w1">First word</param>
/// <param name="w2">Second word</param>
/// <returns>True if the two strings are anagrams, false otherwise</returns>
let areAnagrams (w1: string) (w2: string) : bool =
    let letterCount (w: string) = w |> Seq.countBy id |> Set.ofSeq

    if w1.Length <> w2.Length then
        false
    else
        (letterCount w1) = (letterCount w2)

/// <summary></summary>
/// <param name="w"></param>
/// <returns></returns>
let findAnagrams (w: string) : string seq =
    w.Length
    |> wordsOfLength
    |> Seq.map (fun w -> w.ToUpperInvariant())
    |> Seq.filter (w.ToUpperInvariant() |> areAnagrams)
