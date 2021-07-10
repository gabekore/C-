package clientjava;

import clientjava.Views.MainView;

/**
 * ▼ClientJavaの作り方（事前準備）
 * 1.サーバーアプリを起動
 * 2.サーバーアプリでサービス起動
 * 3.事前確認
 *     Webブラウザで「http://localhost:8081/Gabekore」にアクセス
 *     「http://localhost:8081/Gabekore?wsdl」というWSDLのアドレスをコピっておく【A】
 *     ※「Service サービス」「サービスを作成しました。このサービスをテストするには、クライアントを作成し、そのクライアントを使用してサービスを呼び出す必要があります。これは、コマンド ラインから次の構文を使用し、svcutil.exe ツールを呼び出すことによって行えます。」
 *       ↑のメッセージが出ればOK、出ていなければサーバーアプリの作り方がおかしいのでやり直し
 * 4.事前確認がOKなら次へ進む、NGならサーバーアプリ作り直し
 * ▼ClientJavaの作り方（クライアント作成）
 * 1.NetBEeansで普通に作る
 * 2.プロジェクト→右クリック→新規→Webサービス・クライアント
 * 3.WSDLに【A】入力
 * 4.パッケージに何らかのパッケージ名入力
 *   ※例「com.gabekore.api」
 * 4.パッケージ名を入力しなかった場合、org.tempuriとなってしまうのでちゃんとパッケージ名を入力しましょう
 * 
 */
public class ClientJava {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MainView mv = new MainView();
        mv.setVisible(true);
    }
    
}
