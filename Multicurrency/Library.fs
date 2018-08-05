namespace rec Multicurrency

type Bank() =
  member this.Reduce(expr: IExpr, currency: string) =
    match expr with
    | :? Money as money ->
      money
    | :? MoneySum as sum ->
      sum.Reduce(this, currency)
    | _ ->
      Money.Dollar(10)

type IExpr =
  abstract Reduce: Bank * string -> Money

type Money(amount: int, currency: string) =
  member this.Amount = amount

  member this.Currency = currency

  member this.Plus(right: Money) =
    MoneySum (this, right)

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

type MoneySum =
  | MoneySum of Money * Money
with
  member this.Reduce(bank, target) =
    let (MoneySum(left, right)) = this
    Money(left.Amount + right.Amount, target)

  interface IExpr with
    override this.Reduce(bank, target) =
      failwith "no impl"
