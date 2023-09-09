using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;

public class CustomCommand : AdvCustomCommandManager
{
	public override void OnBootInit()
	{
		Utage.AdvCommandParser.OnCreateCustomCommandFromID += CreateCustomCommand;
	}

	void OnDestroy()
	{
		Utage.AdvCommandParser.OnCreateCustomCommandFromID -= CreateCustomCommand;
	}

	//AdvEnginのクリア処理のときに呼ばれる
	public override void OnClear()
	{
	}

	//カスタムコマンドの作成用コールバック
	public void CreateCustomCommand(string id, StringGridRow row, AdvSettingDataManager dataManager, ref AdvCommand command)
	{
		switch (id)
		{
			//既存のコマンドを改造コマンドに変えたい場合は、IDで判別
			//コメントアウトを解除すれば、テキスト表示がデバッグログ出力のみに変わる
			//				case AdvCommandParser.IdText:
			//					command = new SampleCustomAdvCommandText(row);
			//					break;
			//新しい名前のコマンドも作れる
			case "DebugLog":
				command = new AdvCommand_DebugLog(row);
				break;
			case "Save":
				command = new AdvCommand_Save(row);
				break;
		}
	}
}

//Textの内容をデバッグログで出力するカスタムコマンド
public class AdvCommand_DebugLog : AdvCommand
{
	string log;

	public AdvCommand_DebugLog(StringGridRow row) : base(row)
	{
		//コンストラクタでParseすると、インポート時にエラーがでる

		//「Text」列の文字列を取得
		this.log = ParseCell<string>(AdvColumnName.Text);
	}

	//コマンド実行
	public override void DoCommand(AdvEngine engine)
	{
		Debug.Log(log);
	}	
}

//Textの内容をデバッグログで出力するカスタムコマンド
public class AdvCommand_Save : AdvCommand
{
	//string log;

	public AdvCommand_Save(StringGridRow row) : base(row)
	{
		//コンストラクタでParseすると、インポート時にエラーがでる

		//「Text」列の文字列を取得
		//this.log = ParseCell<string>(AdvColumnName.Text);
	}

	//コマンド実行
	public override void DoCommand(AdvEngine engine)
	{
		// 아직 파라메터 값 불러오는 중!
		if (!engine.Param.IsInit)
		{
			Debug.Log("!engine.Param.IsInit");
			return;
		} 				

		var hoge = engine.Param.GetParameter("hoge");
	}
}
