# 参考URL

以下の記事を参考にさせて頂きました。

ありがとうございます。

[忘れっぽい僕のためのC++/CLIチートシート |Qiita](https://qiita.com/baikichiz/items/1f69d7ea21cb87fab845)

[C#の知識を流用する | 天翔記](http://xn--rssu31gj1g.jp/?page=nobu_mod_the_snmod_using_csharp_knowledge)

[C++/CLIを咥えてLINQをつつく0－まずは簡単なところから。本当に簡単？ | 無差別に技術をついばむ鳥](http://indori.blog32.fc2.com/blog-entry-296.html)

[aaaa | aaaa](https://lipoyang.hatenablog.com/entry/2018/11/05/114611)

[C#とC++のラムダ式 | 滴了庵日録](aaaa)

[C# to C++ Converter  | Tangible Software Solutions](https://www.tangiblesoftwaresolutions.com/download.html)


元ネタは上記の記事ですので、ぜひとも上記記事もご覧ください。


# 構成
C#とC++/CLIでWCFを実現するサンプルです

前回の[01_single](https://github.com/gabekore/CSharp/tree/master/WCF/01_single)にC++/CLIのクライアントを足しただけです


基本的には前回と同じですが、少しだけ変更しています
- C++/CLIクライアント追加
- 全プロジェクトを一つのソリューションにまとめた
- マルチスタートアップ
- CommonInterfaceをInterfaceに改名
- 後は微細な変更


構成はこんな感じ

1. ソリューション
   1. Serverプロジェクト
   1. Interfaceプロジェクト
   1. C#のClientプロジェクト
   1. C++/CLIのClientプロジェクト


# 概要
ClientがServerに要求を出して、結果をもらって画面に表示するだけ
ローカルマシン内のプロセス間通信にのみ使用可能
別マシン間の通信はできない

# ビルド
VisualStudio2017、Windows10で作っています。
.NET Framework 4.7.2

ビルドすればすぐに使えるはず


# 動作手順
1. ソリューションで実行
1. Server（C#）、Client（C#）、Client（C++/CLI）の3つが起動する
1. Serverでサービス開始ボタンクリック
1. いずれかのClientでボタン押せばServerへ要求が行く
1. Clientのテキストボックスに結果が表示される

# 注意
ServerのFormにテキストボックスがありますが、今の所未使用

将来的に使いたいので置いてるだけ
