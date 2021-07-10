# 参考URL

以下の記事を参考にさせて頂きました。

ありがとうございます。

[WCF入門-002 (簡単なサンプル, アプリケーション構成ファイルに記述) | いろいろ備忘録日記](https://devlights.hatenablog.com/entry/20111020/p2)

[【WCF】【C#】WCF　～ WCF に Javaクライアントでアクセスする ～ | プログラム の超個人的なメモ](https://dk521123.hatenablog.com/entry/37962361)

[C++からWebサービスに接続する | マゴトログ シュミニイキル](https://blog.janjan.net/2015/11/04/c-using-webservice/)

[QName クラス | akihiro kamijo](http://cuaoar.jp/2006/03/name-localname.html)

[XMLマスターへの道 第13回　名前空間を理解しDOMの概要をつかむ | @IT](https://www.atmarkit.co.jp/fxml/rensai2/xmlmaster13/master13.html)

[Consuming WCF Services with Java Client | Jan Fajfr's wall – Software engineer @ ITG RFQ-hub](http://www.hoonzis.com/consuming-wcf-services-with-java-client/)


元ネタは上記の記事ですので、ぜひとも上記記事もご覧ください。


# 構成
C#とJavaでWCFを実現するサンプルです

動作的なものは前回と同じですが、前回の[02_single_with_cpp](https://github.com/gabekore/CSharp/tree/master/WCF/02_single_with_cpp)と違うのは
- プログラムコード内に書いていたWCFの設定、App.configに移動
- C++/CLIのクライアント削除（最近のVisualStudioだと、C++プロジェクトではWebサービス参照できない）
- Javaクライアント追加
- 同一マシン内だけでなく、ネットワークでつながった別マシンからもアクセス可能（なはず。まだ確認できていない）


構成はこんな感じ

1. ソリューション
   1. Serverプロジェクト
   1. Interfaceプロジェクト
   1. C#のClientプロジェクト
1. JavaのClientプロジェクト


# 概要
ClientがServerに要求を出して、結果をもらって画面に表示するだけ

# ビルド
1. サーバー（C#）
   - VisualStudio2017、Windows10
   - .NET Framework 4.7.2
2. クライアント（C#）
   - サーバーと同じ
3. クライアント（Java）
   - NetBeans 8.1
   - JDK 1.8.0.191

ビルドすればすぐに使えるはず


# 動作手順
1. ソリューションで実行
1. Server（C#）、Client（C#）の2つが起動する
1. NetBeansでClient（Java）起動
1. Serverでサービス開始ボタンクリック
1. いずれかのClientでボタン押せばServerへ要求が行く
1. Clientのテキストボックスに結果が表示される


# C++/CLI について
C++プロジェクトはVisual Studio（おそらく2010以降）ではWebサービス参照ができない
古いVisual Studio（2008とかかな）ではできるので、そちらでWebサービス参照して生成されたものを持ってくればできるらしいけど、そこまでしてC++を使いたいわけではないので、今回はプロジェクトに含めていない


# 注意
- ServerのFormにテキストボックスがありますが、今の所未使用  
将来的に使いたいので置いてるだけ
