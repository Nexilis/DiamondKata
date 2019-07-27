module Barteklu.Kata.StringFunctions

open System

let split (x: string) =
  x.Split([| Environment.NewLine |], StringSplitOptions.None)

let trim (x: string) =
  x.Trim()

let leadingSpaces (x: string) =
  let indexOfSpaces = x.IndexOfAny [| 'A' .. 'Z' |]
  x.Substring(0, indexOfSpaces)

let trailingSpaces (x: string) =
  let lastIndexOfNonSpaces = x.LastIndexOfAny [| 'A' .. 'Z' |]
  x.Substring(lastIndexOfNonSpaces + 1)
