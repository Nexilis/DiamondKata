module Barteklu.Kata.Diamond
open System

let print (letter: char) (result: string) =
  printfn "\nDiamond generation for: %s\n%s\nDiamond end\n" (string letter) result

let make letter =
  let mirrorAndFuse l = l @ (l |> List.rev |> List.tail)

  let makeLine letterCount (letter, letterIndex) =
    let leadingSpace = String(' ', letterCount - 1 - letterIndex)
    let innerSpaces = String(' ', letterCount - 1 - leadingSpace.Length)

    sprintf "%s%c%s" leadingSpace letter innerSpaces
    |> Seq.toList
    |> mirrorAndFuse
    |> List.map string
    |> List.reduce (sprintf "%s%s")

  let indexedLetters = ['A' .. letter] |> List.mapi (fun i l -> l, i)
  let result =
    indexedLetters
    |> mirrorAndFuse
    |> List.map (makeLine indexedLetters.Length)
    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)
  result
