module Barteklu.Kata.DiamondProperties

open System
open FsCheck
open FsCheck.Xunit

type Letters =
  static member Char() =
    Arb.Default.Char()
    |> Arb.filter (fun c -> 'A' <= c && c <= 'Z')

type DiamondPropertyAttribute () =
  inherit PropertyAttribute(Arbitrary = [| typeof<Letters> |])

[<DiamondProperty>]
let ``Diamond is not-empty`` (letter: char) =
  printf "%c" letter
  let actual = Diamond.make letter
  not (String.IsNullOrWhiteSpace actual)
