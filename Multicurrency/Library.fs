namespace Multicurrency

type Dollar(amount: int) =
  member this.Times(multiplier) =
    Dollar(amount * multiplier)

  member this.Amount = amount
