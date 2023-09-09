// UTAGE: Unity Text Adventure Game Engine (c) Ryohei Tokimura
using UnityEngine;
using Utage;
	
public class SampleCustomCommand : AdvCustomCommandManager
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
	public void CreateCustomCommand(string id, StringGridRow row, AdvSettingDataManager dataManager, ref AdvCommand command )
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
		}
	}
}

