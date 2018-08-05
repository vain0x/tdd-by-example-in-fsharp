module Tests

open System
open Xunit
open Multicurrency

let is<'T> (actual: 'T) (expected: 'T) =
  Assert.Equal(expected, actual)

module CurrencyTests =
  [<Fact>]
  let testCurrency () =
    Money.Dollar(1).Currency |> is "USD"
    Money.Franc(1).Currency |> is "CHF"

module BankTests =
  [<Fact>]
  let testIdentityRate () =
    let bank = Bank()
    bank.Rate("USD", "USD") |> is 1

module MoneyTests =
  [<Fact>]
  let testMultiplication () =
    let five = Money.Dollar(5)
    five.Times(2) |> is (Money.Dollar(10))
    five.Times(3) |> is (Money.Dollar(15))

  [<Fact>]
  let testSimplePlus () =
    let bank = Bank()
    let five = Money.Dollar(5)
    let sum = five.Plus(five)
    let reduced = bank.Reduce(sum, "USD")
    reduced |> is (Money.Dollar(5 + 5))

  [<Fact>]
  let testReduceMoney () =
    let bank = Bank()
    let five = Money.Dollar(5)
    bank.Reduce(five, "USD") |> is five

  [<Fact>]
  let testReduceMoneyToDifferenceCurrency () =
    let bank = Bank().AddRate("CHF", "USD", 2)
    let two = Money.Franc(2)
    bank.Reduce(two, "USD") |> is (Money.Dollar(1))

  [<Fact>]
  let testReduceSum () =
    let bank = Bank()
    let three = Money.Dollar(3)
    let four = Money.Dollar(4)
    let sum = three.Plus(four)
    bank.Reduce(sum, "USD") |> is (Money.Dollar(7))

  [<Fact>]
  let testEquality () =
    Money.Dollar(5) |> is (Money.Dollar(5))
    Money.Dollar(5) <> Money.Dollar(6) |> is true
    Money.Dollar(5).Equals(Money.Franc(5)) |> is false
    Money(5, "CHF") |> is (Money.Franc(5))
