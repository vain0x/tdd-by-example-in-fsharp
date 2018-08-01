namespace Multicurrency

type Dollar(amount: int) =
  member this.Times(multiplier) =
    Dollar(amount * multiplier)

  member this.Amount = amount

  override this.Equals(obj :obj) =
    match obj with
    | :? Dollar as other ->
      this.Amount = other.Amount
    | _ -> false

  override this.GetHashCode() =
    0
