module Barteklu.Kata.StringFunctions

open System

let split (x: string) =
  x.Split([| Environment.NewLine |], StringSplitOptions.None)

let trim (x :string) =
  x.Trim()
