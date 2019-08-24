module Barteklu.Kata.Diamond
open System

let print (letter: char) (result: string) =
  printfn "\nDiamond generation for: %s\n%s\nDiamond end\n" (string letter) result

let make letter =
  let makeLine letterCount letter =
    let padding = String(' ', letterCount - 1)
    match letter with
    | 'A' -> sprintf "%s%c%s" padding letter padding
    | _   ->
      let left = sprintf "%c%s" letter padding |> Seq.toList
      left @ (left |> List.rev |> List.tail)
      |> List.map string
      |> List.reduce (sprintf "%s%s")

  let letters = ['A' .. letter]
  let result =
    letters
    @ (letters |> List.rev |> List.tail)
    |> List.map (makeLine letters.Length)
    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)
  result
