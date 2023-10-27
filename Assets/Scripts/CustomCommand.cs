using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
			case "ParamSave":
				command = new AdvCommand_Save(row);
				break;
			case "ParamLoad":
				command = new AdvCommand_Load(row);
				break;
			case "ParamClear":
				command = new AdvCommand_ParamClear(row);
				break;
			case "ChangeScene":
				command = new AdvCommand_ChangeScene(row);
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

		Debug.Log("ParamSave");		
		ExtraSave.Money = (int)engine.Param.GetParameter("money");
		ExtraSave.Stress = (int)engine.Param.GetParameter("stress");
		ExtraSave.love = (int)engine.Param.GetParameter("love");
		ExtraSave.Blood = (float)engine.Param.GetParameter("blood");
		ExtraSave.Flag = (int)engine.Param.GetParameter("flag");
		ExtraSave.DayProgress = (int)engine.Param.GetParameter("day");
	}
}

public class AdvCommand_Load : AdvCommand
{
	//string log;

	public AdvCommand_Load(StringGridRow row) : base(row)
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

		Debug.Log("ParamLoad");		
		engine.Param.SetParameter("money", ExtraSave.Money);
		engine.Param.SetParameter("stress", ExtraSave.Stress);
		engine.Param.SetParameter("love", ExtraSave.love);
		engine.Param.SetParameter("blood", ExtraSave.Blood);
		engine.Param.SetParameter("flag", ExtraSave.Flag);
		engine.Param.SetParameter("day", ExtraSave.DayProgress);
	}
}

public class AdvCommand_ParamClear : AdvCommand
{
	public AdvCommand_ParamClear(StringGridRow row) : base(row)
	{
		//コンストラクタでParseすると、インポート時にエラーがでる				
	}
	
	public override void DoCommand(AdvEngine engine)
	{
		// 아직 파라메터 값 불러오는 중!
		if (!engine.Param.IsInit)
		{
			Debug.Log("!engine.Param.IsInit");
			return;
		}

		Debug.Log("ParamClear");		
		ExtraSave.Money = 0;
		ExtraSave.Stress = 0;
		ExtraSave.love = 0;
		ExtraSave.Blood = 0;
		ExtraSave.Flag = 0;
	}
}

public class AdvCommand_ChangeScene : AdvCommand
{
	string sceneName;	

	public AdvCommand_ChangeScene(StringGridRow row) : base(row)
	{
		//コンストラクタでParseすると、インポート時にエラーがでる

		//「Text」列の文字列を取得
		sceneName = ParseCell<string>(AdvColumnName.Arg1);		
	}

	//コマンド実行
	public override void DoCommand(AdvEngine engine)
	{
		Debug.Log("ChangeScene : " + sceneName);
		SceneManager.LoadScene(sceneName);
	}	
}
