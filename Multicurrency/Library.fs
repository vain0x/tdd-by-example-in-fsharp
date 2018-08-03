namespace rec Multicurrency

[<AbstractClass>]
type Money(amount: int, currency: string) =
  member private this.Amount = amount

  member this.Currency = currency

  abstract Times: int -> Money

  override this.Equals(obj :obj) =
    match obj with
    | :? Money as other ->
      this.Amount = other.Amount
      && this.GetType() = other.GetType()
    | _ -> false

  override this.GetHashCode() =
    0

  static member Dollar(amount: int) =
    Dollar(amount) :> Money

  static member Franc(amount: int) =
    Franc(amount) :> Money

type Dollar(amount: int) =
  inherit Money(amount, "USD")

  override this.Times(multiplier) =
    Money.Dollar(amount * multiplier)

type Franc(amount: int) =
  inherit Money(amount, "CHF")

  override this.Times(multiplier) =
    Money.Franc(amount * multiplier)
