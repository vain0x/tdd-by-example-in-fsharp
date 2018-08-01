# Diary: Reading "TDD by Example" Japanese edition

## 1. Go to bookstore

Japanese Edition: [テスト駆動開発【委託】 - 達人出版会](https://tatsu-zine.com/books/test-driven-development)

## 2. Development Environment Construction

According to [Ionide - Crossplatform F# Editor Tools](http://ionide.io/#getting-started)...

- Install [.NET Core CLI Tools 2.x](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- Install [Visual Studio Code](https://code.visualstudio.com/)
- Launch Code (vscode),
    - install F# extension `ionide-fsharp`,
    - and reload. (`Control + Shift + P`, type `reload`, Enter)

To generate .gitignore, use <https://www.gitignore.io/api/fsharp,csharp,visualstudio>.

## 3. Project Scaffolding

Create a project (unit of program), called Multicurrency, and another to test it.

According to [Unit testing F# libraries in .NET Core using dotnet test and xUnit | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-fsharp-with-dotnet-test)...

Open terminal (`Control + Shift + P`, "toggle integrated terminal") and run the following commands.

```sh
dotnet new classlib -lang F# --name Multicurrency
dotnet new xunit -lang F# --name MulticurrencyTests
```

Add inter-project reference so that testing project (MulticurrencyTests) refers to tested project (Multicurrency).

```sh
dotnet add MulticurrencyTests reference Multicurrency
```

Try it works. (One test should pass.)

```sh
dotnet test MulticurrencyTests
```

## TODOs

- $10 + 5 CHF = $10 (rate 2:1)
- $5 * 2 = $10
- [x] no Dollar class
- [x] no Dollar ctor
- [x] no Times method
- [x] no Amount field
- make private amount
- [x] side effects of Dollar
- round of Money
- [x] equality
- [x] hashCode
- ~~compare with null~~ (no problem in F#)
- compare with objects of different type

## Links

- [新訳版『テスト駆動開発』が出ます - t-wadaのブログ](http://t-wada.hatenablog.jp/entry/tddbook)
