# Diary: Reading "TDD by Example"

## 1. Go to bookstore

Japanese Edition: [テスト駆動開発【委託】 - 達人出版会](https://tatsu-zine.com/books/test-driven-development)

## 2. Build Development Environment

According to the official page [Ionide - Crossplatform F# Editor Tools](http://ionide.io/#getting-started)...

- Install development tool: [.NET Core CLI Tools 2.x](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- Install source code editor: [Visual Studio Code](https://code.visualstudio.com/)
- Launch "Code" (vscode), install F# extension `ionide-fsharp`, and reload.

    *(To reload, press `Control + Shift + P`, input `reload`, and press Enter.)*

- (Omittable) Generate `.gitignore` file by <https://www.gitignore.io/api/fsharp,csharp,visualstudio>

## 3. Project Scaffolding

According to [Unit testing F# libraries in .NET Core using dotnet test and xUnit | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-fsharp-with-dotnet-test)...

Create a project (unit of program) called "Multicurrency", and another one to test it. To do this, open terminal, and run the following commands.

*(To open terminal, in vscode, press `Control + Shift + P`, input `toggle integrated terminal`, and Enter.)*

```sh
dotnet new classlib -lang F# --name Multicurrency
dotnet new xunit -lang F# --name MulticurrencyTests
```

Add inter-project reference so that testing project (MulticurrencyTests) refers to target project (Multicurrency).

```sh
dotnet add MulticurrencyTests reference Multicurrency
```

Try it works. One test will pass.

```sh
dotnet test MulticurrencyTests
```

## 3. Implement Dollar

- Write tests of `Dollar` type
- Define `Dollar` with obvious implementation
- Generalize it by eliminating duplication
- Define `equals` method for structural equality (bearing record types in mind)

## 4. Implement Franc

- Write implementations and tests for `Franc` type by copy-pasting from `Dollar` type
- Improve equality defintion so that two currencies are distinct
- Eliminate code duplication between the two types

## 5. Money type

- Add Money, base type of Dollar/Franc
- Add field `currency`
- Move methods to Money from Dollar/Franc
- Remove Dollar/Franc

## TODOs

- [x] $10 + 5 CHF = $10 (rate 2:1)
- [x] $5 + $5 = $10
- ~~$5 + $5 : Money~~
- [x] Bank.reduce

## Links

- [新訳版『テスト駆動開発』が出ます - t-wadaのブログ](http://t-wada.hatenablog.jp/entry/tddbook)
