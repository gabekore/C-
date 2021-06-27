# 参考URL

以下の記事を参考にさせて頂きました。

ありがとうございます。

[C#でプラグイン実装: niyoな日記](http://niyodiary.cocolog-nifty.com/blog/2009/09/c-506e.html)

元ネタは上記の記事ですので、ぜひとも上記記事もご覧ください。


# 概要

C# でプラグインを作るサンプルです

構成はこんな感じ

1. MainProgramCUI
    - プラグインを呼び出すEXE（CUI版）
    - プラグイン（DLL）があれば読み込んで、プラグインを実行する
1. MainProgramGUI
    - プラグインを呼び出すEXE（GUI版）
    - プラグイン（DLL）があれば読み込んで、プラグインを実行する
1. PluginBaseDLL
    - 抽象クラス
    - プラグインの親クラス
    - プラグインはこれを継承する
    - プラグインを呼び出すEXEからもプラグインそのものもこれを参照設定する
1. PluginSample1
    - プラグインその１
    - プラグインとしての処理をする
1. PluginSample2
    - プラグインその２
    - プラグインとしての処理をする

# リポジトリ名に付いてるAbstractClassVersionとは？

今回のPluginBaseDLLは抽象クラスにしているがインタフェースにすることもできる（クラスやインタフェース無くてもプラグインは作れるけど）

抽象クラスでもインタフェースでもそこまで大きな違いは無いと思うが、今回は抽象クラスで作った

今後、気が向けばインタフェース版も作るかもしれないのでAbstractClassVersionと付けている


# 動作概要

## CUI版
CUI版はどうってことないのでソース読んでください


## GUI版

- プラグインのログ（`Console.WriteLine()`）をEXE側の画面のListBoxに表示している
- プラグインを実行しているのはワーカースレッド
- ワーカースレッドで永久ループを回してプラグインを実行し続けている
- ワーカースレッドは画面（メインスレッド(UIスレッド)）の部品にはアクセスできないが、プラグインのログを画面に表示したいので、Invoke()を使ってプラグインのログを画面のListBoxに表示している
- 実用的に考えるのであればログレベルがあると便利なので、それにも対応できるようにenum使ってる


# 使い方と言うかビルド方法

VisualStudio2017、Windows10で作っています。

ビルドすればすぐに使えるはず

5つのプロジェクトはそれぞれ別々のプロジェクトです

1つのソリューションにしても良かったんですけど、別々に分かれている方が理解しやすいかと


## 手順

1. PluginBaseDLLのビルド
    - ダウンロードしたらソリューションorプロジェクトをすぐにビルド可能
    - EXEとプラグインDLLから参照されるのでビルドされたPluginBaseDLL.dllをどこかに置いておくといいでしょう、EXEと同じ場所がいいかも
    - EXEと同じ場所にPluginsというフォルダを作成しておく
1. EXEをビルド
    - プロジェクトの参照の追加でPluginBaseDLL.dllを参照設定
    - ソリューションorプロジェクトをビルド
        - GUI版もしくはCUI版のどちら一つあればいいよ
1. プラグインDLLのビルド（PluginSample1、PluginSample2）
    - プロジェクトの参照の追加でPluginBaseDLL.dllを参照設定
    - ソリューションorプロジェクトをビルド
    - EXEと同じ場所にあるPluginsというフォルダにビルドされたPluginSample1.dll / PluginSample2.dssを置く
1. EXE起動
    - CUI版は起動するだけ
    - GUI版は起動してThread Startボタンクリックでスレッド開始
        - ListBoxにログが出続けます
    - Thread Stopボタンでスレッド停止


# 懸念点

LOG_LEVELのenumは、EXE・プラグイン共にPluginBaseDLL.dllで定義したものを使っているが、これで良かったのかな？


# 最後に

プラグイン機能を作るのはかなり簡単

ソース読めば分かるでしょうから読んでね