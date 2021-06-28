# 参考URL

以下の記事を参考にさせて頂きました。

ありがとうございます。

[WCF入門-001 (簡単なサンプル, 自己ホスト形式, コードで記述) |いろいろ備忘録日記](https://devlights.hatenablog.com/entry/20111020/p1)

[WCFでAddressAccessDeniedExceptionが発生する場合の対処方法 | tekkの日記 C#,VB.NET](https://tekk.hatenadiary.org/entry/20150102/1420205325)

[.NET FrameworkのWCFとは？C#で簡単なサービスを作成する方法 | Qiita](https://www.fenet.jp/dotnet/column/tool/4389/)

[WCFのキホン vol.1 | .NETコラム](https://qiita.com/kenji-yokoi/items/7cbe870ec66b48fcf8b8)


元ネタは上記の記事ですので、ぜひとも上記記事もご覧ください。


# 構成
C#でWCFを実現するサンプルです

構成はこんな感じ

1. Serverソリューション
   1. Serverプロジェクト
   2. CommonInterfaceプロジェクト
2. Clientソリューション
   1. Clientプロジェクト
   2. CommonInterfaceプロジェクト

一つのCommonInterfaceプロジェクトを両方のソリューションから参照しています

一つのソリューションに３つのプロジェクトを登録する形でも良かったんですけど、単にサーバー側とクライアント側を分けたかったのでソリューションも別個にしただけ

そこまで深い意味は無いです


# 概要
ClientがServerに要求を出して、結果をもらって画面に表示するだけ

# ビルド

VisualStudio2017、Windows10で作っています。
.NET Framework 4.7.2

ビルドすればすぐに使えるはず


# 動作手順
1. Serverの実行
2. Serverでサービス開始ボタンクリック
3. Clientの実行
4. Clientでボタン押せばServerへ要求が行く
5. Clientのテキストボックスに結果が表示される

# 注意
ServerのFormにテキストボックスがありますが、今の所未使用

将来的に使いたいので置いてるだけ
