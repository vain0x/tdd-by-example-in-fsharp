namespace Multicurrency

[<AbstractClass>]
type Money(amount: int, currency: string) =
  member private this.Amount = amount

  member this.Currency = currency

  override this.Equals(obj :obj) =
    match obj with
    | :? Money as other ->
      this.Amount = other.Amount
      && this.GetType() = other.GetType()
    | _ -> false

  override this.GetHashCode() =
    0

type Dollar(amount: int) =
  inherit Money(amount, "USD")

  member this.Times(multiplier) =
    Dollar(amount * multiplier)

type Franc(amount: int) =
  inherit Money(amount, "CHF")

  member this.Times(multiplier) =
    Franc(amount * multiplier)

type Money with
  static member Dollar(amount: int) =
    Dollar(amount)

  static member Franc(amount: int) =
    Franc(amount)
