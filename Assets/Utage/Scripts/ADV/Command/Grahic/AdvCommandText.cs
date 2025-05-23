﻿// UTAGE: Unity Text Adventure Game Engine (c) Ryohei Tokimura
using UnityEngine;
using System.Text;

namespace Utage
{

	/// <summary>
	/// コマンド：テキスト表示
	/// </summary>
	public class AdvCommandText : AdvCommand
		, IAdvInitOnCreateEntity
	{

		public AdvCommandText(StringGridRow row, AdvSettingDataManager dataManager)
			: base(row)
		{

			//ボイスファイル設定
			InitVoiceFile(dataManager);
			//ページコントロール
			this.PageCtrlType = ParseCellOptional<AdvPageControllerType>(AdvColumnName.PageCtrl, AdvPageControllerType.InputBrPage);
			this.IsNextBr = AdvPageController.IsBrType(PageCtrlType);
			this.IsPageEnd = AdvPageController.IsPageEndType(PageCtrlType);

			//エディター用のチェック
			if (AdvCommand.IsEditorErrorCheck)
			{
				TextData textData = new TextData(ParseCellLocalizedText());
				if (!string.IsNullOrEmpty(textData.ErrorMsg))
				{
					Debug.LogError(ToErrorString(textData.ErrorMsg));
				}
			}
		}

		//ページ用のデータからコマンドに必要な情報を初期化
		public override void InitFromPageData(AdvScenarioPageData pageData)
		{
			this.PageData = pageData;
			this.IndexPageData = PageData.TextDataList.Count;
			PageData.AddTextData(this);
			PageData.InitMessageWindowName(this, ParseCellOptional<string>(AdvColumnName.WindowType, ""));
		}

		//エンティティコマンドとして利用
		public void InitOnCreateEntity(AdvCommand original)
		{
			AdvCommandText originalText = original as AdvCommandText; 
			this.PageData = originalText.PageData;
			PageData.ChangeTextDataOnCreateEntity(originalText.IndexPageData, this);
		}

		//コマンド実行
		public override void DoCommand(AdvEngine engine)
		{
			if (IsEmptyCell(AdvColumnName.Arg1))
			{
				engine.Page.CharacterInfo = null;
			}
			if (null != VoiceFile)
			{
				if (!engine.Page.CheckSkip () || !engine.Config.SkipVoiceAndSe) 
				{
					//キャラクターラベル
					engine.SoundManager.PlayVoice ( engine.Page.CharacterLabel, VoiceFile);
				}
			}
			engine.Page.UpdatePageTextData(this);
		}

		//コマンド終了待ち
		public override bool Wait(AdvEngine engine)
		{
			return engine.Page.IsWaitTextCommand;
		}

		public override void OnChangeLanguage(AdvEngine engine)
		{
			if (!LanguageManagerBase.Instance.IgnoreLocalizeVoice)
			{
				//ボイスファイル設定
				InitVoiceFile(engine.DataManager.SettingDataManager);
			}
		}

		protected virtual void InitVoiceFile(AdvSettingDataManager dataManager)
		{
			//ボイスファイル設定
			string voice = ParseCellOptional<string>(AdvColumnName.Voice, "");
			if (!string.IsNullOrEmpty(voice))
			{
				VoiceFile = ParseVoiceSub(dataManager, voice);
			}
		}

		//ページ区切り系のコマンドか
		public override bool IsTypePage() { return true; }
		//ページ終端のコマンドか
		public override bool IsTypePageEnd() { return IsPageEnd; }
		public bool IsPageEnd { get; private set; }
		public bool IsNextBr { get; private set; }
		public AdvPageControllerType PageCtrlType { get; private set; }

		public AssetFile VoiceFile { get; private set; }

		AdvScenarioPageData PageData { get; set; }
		int IndexPageData { get; set; }
	}
}
