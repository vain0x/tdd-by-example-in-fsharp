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
    Money(amount, "USD")

  static member Franc(amount: int) =
    Money(amount, "CHF")
