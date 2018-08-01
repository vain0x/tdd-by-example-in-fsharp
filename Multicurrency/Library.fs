namespace Multicurrency

type Dollar(amount: int) =
  // Redeclare amount as mutable field.
  let mutable amount = amount

  member this.Times(multiplier) =
    amount <- amount * multiplier

  member this.Amount = amount
