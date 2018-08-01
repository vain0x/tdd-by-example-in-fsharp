namespace Multicurrency

type Dollar(amount: int) =
  // Redeclare amount as mutable field.
  let mutable amount = amount

  member this.Times(multiplier) =
    Dollar(amount * multiplier)

  member this.Amount = amount
