namespace rec Multicurrency

type Bank(rates: Map<string * string, int>) =
  new() = Bank(Map.empty)

  member this.AddRate(source: string, target: string, rate: int) =
    Bank(rates |> Map.add (source, target) rate)

  member this.Rate(source: string, target: string) =
    if source = target then
      1
    else
      rates |> Map.find (source, target)

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

  member this.Plus(right: IExpr) =
    MoneySum (this, right) :> IExpr

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
      this.Reduce(bank, target)

type MoneySum =
  | MoneySum of IExpr * IExpr
with
  member this.Plus(right): IExpr =
    MoneySum (this, right) :> IExpr

  member this.Reduce(bank, target) =
    let (MoneySum (left, right)) = this
    let left = left.Reduce(bank, target)
    let right = right.Reduce(bank, target)
    Money(left.Amount + right.Amount, target)

  interface IExpr with
    override this.Reduce(bank, target) =
      this.Reduce(bank, target)
