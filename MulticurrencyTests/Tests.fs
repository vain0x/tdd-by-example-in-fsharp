module Tests

open System
open Xunit
open Multicurrency

let is<'T> (actual: 'T) (expected: 'T) =
  Assert.Equal(expected, actual)

[<Fact>]
let testMultiplication () =
  let five = Dollar(5)
  let product = five.Times(2)
  product |> is (Dollar(10))

  let product = five.Times(3)
  product |> is (Dollar(15))

[<Fact>]
let testEquality () =
  Dollar(5) |> is (Dollar(5))
  Dollar(5) <> Dollar(6) |> is true
