namespace rec Multicurrency

type Money(amount: int, currency: string) =
  member private this.Amount = amount

  member this.Currency = currency

  member this.Times(multiplier) =
    Money(amount * multiplier, this.Currency)

  override this.Equals(obj :obj) =
    match obj with
    | :? Money as other ->
      this.Amount = other.Amount
      && this.Currency = other.Currency
    | _ -> false

  override this.GetHashCode() =
    0

  static member Dollar(amount: int) =
    Dollar(amount) :> Money

  static member Franc(amount: int) =
    Franc(amount) :> Money

type Dollar(amount: int) =
  inherit Money(amount, "USD")

type Franc(amount: int) =
  inherit Money(amount, "CHF")
