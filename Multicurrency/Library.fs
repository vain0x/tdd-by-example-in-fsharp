namespace rec Multicurrency

type Bank() =
  member this.Reduce(expr: IExpr, currency: string) =
    match expr with
    | :? Money as money ->
      money
    | _ ->
      Money.Dollar(10)

type IExpr =
  abstract Reduce: Bank * string -> Money

type Money(amount: int, currency: string) =
  member private this.Amount = amount

  member this.Currency = currency

  member this.Plus(right: Money) =
    Money(amount + right.Amount, currency)

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

  interface IExpr with
    override this.Reduce(bank, target) =
      failwith "no impl"
