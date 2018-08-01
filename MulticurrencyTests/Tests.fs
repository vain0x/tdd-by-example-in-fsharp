module Tests

open System
open Xunit
open Multicurrency

let is<'T> (actual: 'T) (expected: 'T) =
  Assert.Equal(expected, actual)

module DollarTests =
  [<Fact>]
  let testMultiplication () =
    let five = Money.Dollar(5)
    five.Times(2) |> is (Money.Dollar(10))
    five.Times(3) |> is (Money.Dollar(15))

  [<Fact>]
  let testEquality () =
    Money.Dollar(5) |> is (Money.Dollar(5))
    Money.Dollar(5) <> Money.Dollar(6) |> is true
    Money.Dollar(5).Equals(Money.Franc(5)) |> is false

module FrancTests =
  [<Fact>]
  let testMultiplication () =
    let five = Money.Franc(5)
    five.Times(2) |> is (Money.Franc(10))
    five.Times(3) |> is (Money.Franc(15))

  [<Fact>]
  let testEquality () =
    Money.Franc(5) |> is (Money.Franc(5))
    Money.Franc(5) <> Money.Franc(6) |> is true
