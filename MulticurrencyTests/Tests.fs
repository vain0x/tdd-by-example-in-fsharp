module Tests

open System
open Xunit
open Multicurrency

let is<'T> (actual: 'T) (expected: 'T) =
  Assert.Equal(expected, actual)

module DollarTests =
  [<Fact>]
  let testMultiplication () =
    let five = Dollar(5)
    five.Times(2) |> is (Dollar(10))
    five.Times(3) |> is (Dollar(15))

  [<Fact>]
  let testEquality () =
    Dollar(5) |> is (Dollar(5))
    Dollar(5) <> Dollar(6) |> is true
