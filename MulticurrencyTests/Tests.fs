module Tests

open System
open Xunit
open Multicurrency

let is<'T> (actual: 'T) (expected: 'T) =
  Assert.Equal(expected, actual)

[<Fact>]
let testMultiplication () =
  let five = Dollar(5)
  five.Times(2)
  five.Amount |> is 10
