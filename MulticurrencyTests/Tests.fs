module Tests

open System
open Xunit
open Multicurrency

let inline is<'T> (actual: 'T) (expected: 'T) =
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

  let defaultBank = Bank().AddRate("CHF", "USD", 2)

  let fiveBucks = Money.Dollar(5)
  let tenFrancs = Money.Franc(10)

  [<Fact>]
  let testMultiplication () =
    fiveBucks.Times(2) |> is (Money.Dollar(10))
    fiveBucks.Times(3) |> is (Money.Dollar(15))

  [<Fact>]
  let testSimplePlus () =
    let sum = fiveBucks.Plus(fiveBucks)
    let reduced = defaultBank.Reduce(sum, "USD")
    reduced |> is (Money.Dollar(5 + 5))

  [<Fact>]
  let testMixedPlus () =
    let sum = fiveBucks.Plus(tenFrancs)
    defaultBank.Reduce(sum, "USD") |> is (Money.Dollar(10))

  [<Fact>]
  let testSumPlusMoney () =
    let sum = (MoneySum (fiveBucks, tenFrancs)).Plus(fiveBucks)
    let reduced = defaultBank.Reduce(sum, "USD")
    reduced |> is (Money.Dollar(15))

  [<Fact>]
  let testSumTimes () =
    let sum = (MoneySum (fiveBucks, tenFrancs)).Times(3)
    let reduced = defaultBank.Reduce(sum, "USD")
    reduced |> is (Money.Dollar(30))

  [<Fact>]
  let testReduceMoney () =
    defaultBank.Reduce(fiveBucks, "USD") |> is fiveBucks

  [<Fact>]
  let testReduceMoneyToDifferenceCurrency () =
    let two = Money.Franc(2)
    defaultBank.Reduce(two, "USD") |> is (Money.Dollar(1))

  [<Fact>]
  let testReduceSum () =
    let three = Money.Dollar(3)
    let four = Money.Dollar(4)
    let sum = three.Plus(four)
    defaultBank.Reduce(sum, "USD") |> is (Money.Dollar(7))

  [<Fact>]
  let testEquality () =
    Money.Dollar(5) |> is (Money.Dollar(5))
    Money.Dollar(5) <> Money.Dollar(6) |> is true
    Money.Dollar(5).Equals(Money.Franc(5)) |> is false
    Money(5, "CHF") |> is (Money.Franc(5))
