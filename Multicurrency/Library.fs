namespace Multicurrency

type Dollar(amount: int) =
  member this.Times(multiplier) =
    Dollar(amount * multiplier)

  member this.Amount = amount

  override this.Equals(obj :obj) =
    true

  override this.GetHashCode() =
    0
