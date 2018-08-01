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
    Dollar(5).Equals(Franc(5)) |> is false

module FrancTests =
  [<Fact>]
  let testMultiplication () =
    let five = Franc(5)
    five.Times(2) |> is (Franc(10))
    five.Times(3) |> is (Franc(15))

  [<Fact>]
  let testEquality () =
    Franc(5) |> is (Franc(5))
    Franc(5) <> Franc(6) |> is true
