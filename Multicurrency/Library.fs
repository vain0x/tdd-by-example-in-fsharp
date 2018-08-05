namespace rec Multicurrency

type Bank() =
  member this.AddRate(source: string, target: string, rate: float) =
    ()

  member this.Rate(source: string, target: string) =
    match source, target with
    | "CHF", "USD" -> 2
    | _ -> 1

  member this.Reduce(expr: IExpr, currency: string) =
    match expr with
    | :? Money as money ->
      money.Reduce(this, currency)
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

  member this.Reduce(bank: Bank, target) =
    let rate = bank.Rate(currency, target)
    Money(amount / rate, target)

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
    let (MoneySum (left, right)) = this
    Money(left.Amount + right.Amount, target)

  interface IExpr with
    override this.Reduce(bank, target) =
      failwith "no impl"
