﻿module Barteklu.Kata.DiamondProperties

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

[<DiamondProperty>]
let ``Figure is symmetric around the horizontal axis`` (letter: char) =
  let actual = Diamond.make letter
  Diamond.print letter actual

  let rows = split actual
  let topRows =
    rows
    |> Seq.takeWhile (fun x -> not (x.Contains(string letter)))
    |> Seq.toList
  let bottomRows =
    rows
    |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
    |> Seq.skip 1
    |> Seq.toList
    |> List.rev

  topRows = bottomRows

[<DiamondProperty>]
let ``Diamond is as wide as it's high`` (letter: char) =
  let actual = Diamond.make letter

  let rows = split actual
  let expected = rows.Length
  rows |> Array.forall (fun x -> x.Length = expected)

[<DiamondProperty>]
let ``All rows expect top and bottom have two identical letters`` (letter: char) =
  let actual = Diamond.make letter

  let isTwoIdenticalLetters x =
    let hasIdenticalLetters = x |> Seq.distinct |> Seq.length = 1
    let hasTwoLetters = x |> Seq.length = 2
    hasIdenticalLetters && hasTwoLetters

  let rows = split actual
  rows
  |> Array.filter (fun x -> not (x.Contains("A")))
  |> Array.map (fun x -> x.Replace(" ", ""))
  |> Array.forall isTwoIdenticalLetters

[<DiamondProperty>]
let ``Lower left space is a triangle`` (letter: char) =
  let actual = Diamond.make letter
  let rows = split actual

  let lowerLeftSpace =
    rows
    |> Seq.skipWhile (fun x -> not (x.Contains(string letter)))
    |> Seq.map leadingSpaces
    |> Seq.toList

  let spaceCounts = lowerLeftSpace |> List.map (fun x -> x.Length)

  let expected = Seq.initInfinite id
                 |> Seq.take spaceCounts.Length
                 |> Seq.toList

  expected = spaceCounts