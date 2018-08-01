namespace Multicurrency

type Dollar(amount: int) =
  // Redeclare amount as mutable field.
  let mutable amount = amount

  member this.Times(multiplier) =
    amount <- 5 * 2

  member this.Amount = amount
