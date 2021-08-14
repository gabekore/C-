# 参考URL

以下の記事を参考にさせて頂きました。

ありがとうございます。

[+WCF+双方向通信によるサーバープッシュ | Free Flying](http://tuotehhou.y.ribbon.to/index.php?%2BWCF%2B%E5%8F%8C%E6%96%B9%E5%90%91%E9%80%9A%E4%BF%A1%E3%81%AB%E3%82%88%E3%82%8B%E3%82%B5%E3%83%BC%E3%83%90%E3%83%BC%E3%83%97%E3%83%83%E3%82%B7%E3%83%A5)

[WCF入門-007 (基本的なサンプル, 双方向通信(Duplex)) | いろいろ備忘録日記](https://devlights.hatenablog.com/entry/20111023/p2)

[C#で非同期に処理するTask間のメッセージ通信 | JoTech](https://hiroki-sawano.hatenablog.com/entry/2018/09/07/074232)

[C#でシグナル処理 | Qiita](https://qiita.com/rawr/items/6888778b53fc95c41f00)

[スレッド間での情報共有について | stack overflow](https://ja.stackoverflow.com/questions/32749/%E3%82%B9%E3%83%AC%E3%83%83%E3%83%89%E9%96%93%E3%81%A7%E3%81%AE%E6%83%85%E5%A0%B1%E5%85%B1%E6%9C%89%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6)

[C#のスレッド間でのデータのやり取りについて | teratail](https://teratail.com/questions/19966)

[C#における変数のアトミック性 | 副業以上起業未満のフリーランス](https://ww7f-4thlab-ddt.com/programming/atomic/)

[C# の long は読み書き Atomic じゃないから Interlocked 使おう | ..たれろぐ..](https://naga-sawa.hatenadiary.org/entry/20160713/1468375077)

[スレッドセーフ | C言語入門](https://kaworu.jpn.org/c/%E3%82%B9%E3%83%AC%E3%83%83%E3%83%89%E3%82%BB%E3%83%BC%E3%83%95)

[アトミック | C言語入門](https://kaworu.jpn.org/c/%E3%82%A2%E3%83%88%E3%83%9F%E3%83%83%E3%82%AF)

[一対多の Dictionary が欲しい | present](https://tnakamura.hatenablog.com/entry/20090611/multi_dictionary)

[【C#】1 つのキーに対して複数の値を登録できる Dictionary を実装する | コガネブログ](https://baba-s.hatenablog.com/entry/2015/03/06/125930)

[C#: Dictionaryのキーに複数の値を使う | け日記](https://ohke.hateblo.jp/entry/2017/03/17/000000)


元ネタは上記の記事ですので、ぜひとも上記記事もご覧ください。


# 構成
C#とJavaでWCFを実現するサンプルです

動作的なものは前回と同じですが、前回の[03_single_appconfig](https://github.com/gabekore/CSharp/tree/master/WCF/03_single_appconfig)と違うのは
- サーバープッシュ
- C#クライアントが2つ

構成はこんな感じ

1. ソリューション
   1. Serverプロジェクト
   1. ServiceIFプロジェクト
   1. C#のClient1プロジェクト
   1. C#のClient2プロジェクト
1. JavaのClient1プロジェクト
1. JavaのClient2プロジェクト


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


# 動作させる前の準備
1. ServerのApp.configの「<add baseAddress="http://localhost:8081/Gabekore"/>」のIPアドレスや名前を必要に応じて書き換える
   - Serverとクライアントアプリを同じマシンで動かすならlocalhostでいい
   - Serverとクライアントアプリを別のマシンで動かすならIPアドレスにする
2. 書き換えたら、Serverを起動してサービスを起動し、クライアントアプリでサービス参照をやり直しておく方がいい
   - ClientCSの場合
      1. Connected ServicesのGabekoreServiceを削除
      1. Connected Services→右クリック→サービス参照の追加
      1. ※以降省略
   - ClientJavaの場合
      1. Webサービス参照のGabekore削除
      1. ClientJavaのプロジェクト→右クリック→新規→Webサービス・クライアント
      1. ※以降省略


# 動作手順
1. ソリューションで実行
1. Server（C#）、Client（C#）の2つが起動する
   - マルチスタートアップで起動することを想定
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
