namespace Multicurrency

type Dollar(amount: int) =
  member this.Times(multiplier) =
    ()

  member this.Amount = 0
