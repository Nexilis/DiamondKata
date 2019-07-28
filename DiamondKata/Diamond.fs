module Barteklu.Kata.Diamond
open System

let print (letter: char) (result: string) =
  printfn "\nDiamond generation for: %s\n%s\nDiamond end\n" (string letter) result

let make letter =
  let letters = ['A' .. letter]
  let result =
    letters
    @ (letters |> List.rev |> List.tail)
    |> List.map string
    |> List.reduce (fun x y -> sprintf "%s%s%s" x Environment.NewLine y)
  result
