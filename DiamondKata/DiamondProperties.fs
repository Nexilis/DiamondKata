module Barteklu.Kata.DiamondProperties

open Barteklu.Kata.StringFunctions
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

[<DiamondProperty>]
let ``First row contains 'A`` (letter: char) =
  let actual = Diamond.make letter

  let rows = split actual
  rows |> Seq.head |> trim = "A"

[<DiamondProperty>]
let ``All rows must have a symmetric contour`` (letter: char) =
  let actual = Diamond.make letter

  let rows = split actual
  rows |> Array.forall (fun r -> (leadingSpaces r) = (trailingSpaces r))

[<DiamondProperty>]
let ``Top of figure has correct letters in correct order`` (letter: char) =
  let actual = Diamond.make letter

  let expected = ['A' .. letter]
  let rows = split actual
  let firstNonWhiteSpaceLetters =
      rows
      |> Seq.take expected.Length
      |> Seq.map trim
      |> Seq.map Seq.head
      |> Seq.toList
  expected = firstNonWhiteSpaceLetters
