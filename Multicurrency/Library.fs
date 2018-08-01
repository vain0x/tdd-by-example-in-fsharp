namespace Multicurrency

type Dollar(amount: int) =
  // Redeclare amount as mutable field.
  let mutable amount = amount

  member this.Times(multiplier) =
    amount <- amount * 2

  member this.Amount = amount
