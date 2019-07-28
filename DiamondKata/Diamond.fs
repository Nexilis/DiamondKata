module Barteklu.Kata.Diamond
open System

let print (letter: char) (result: string) =
  printfn "\nDiamond generation for: %s\n%s\nDiamond end\n" (string letter) result

let make letter =
  let makeLine letterCount letter =
    let padding = String(' ', letterCount - 1)
    sprintf "%s%c%s" padding letter padding

  let letters = ['A' .. letter]
  let result =
    letters
    @ (letters |> List.rev |> List.tail)
    |> List.map (makeLine letters.Length)
    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)
  result
