﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScriptPlayerAction : LayoutScript
{
	protected txUIButton[] mAction;
	public ScriptPlayerAction(LAYOUT_TYPE type, string name, GameLayout layout)
		:
		base(type, name, layout)
	{
		mAction = new txUIButton[(int)ACTION_TYPE.AT_MAX];
	}
	public override void assignWindow()
	{
		int count = mAction.Length;
		for (int i = 0; i < count; ++i)
		{
			mAction[i] = newObject<txUIButton>("Action" + i);
		}
	}
	public override void init()
	{
		UIEventListener.VoidDelegate[] callbackArray = new UIEventListener.VoidDelegate[] { onHuClicked, onGangClicked, onPengClicked, onPassClicked };
		int count = mAction.Length;
		for (int i = 0; i < count; ++i)
		{
			mAction[i].setClickCallback(callbackArray[i]);
		}
	}
	public override void onReset()
	{
		notifyActionAsk(null);
	}
	public override void onShow(bool immediately, string param)
	{
		;
	}
	public override void onHide(bool immediately, string param)
	{
		;
	}
	public override void update(float elapsedTime)
	{
		;
	}
	public void notifyActionAsk(List<MahjongAction> actionList)
	{
		// 先隐藏所有行为
		int count = mAction.Length;
		for (int i = 0; i < count; ++i)
		{
			LayoutTools.ACTIVE_WINDOW(mAction[i], false);
		}
		// 显示可以操作的行为
		if(actionList != null)
		{
			int actionCount = actionList.Count;
			for (int i = 0; i < actionCount; ++i)
			{
				LayoutTools.ACTIVE_WINDOW(mAction[(int)actionList[i].mType]);
			}
		}
	}
	//------------------------------------------------------------------------------------------------------
	protected void onHuClicked(GameObject obj)
	{
		// 请求麻将系统自己要胡牌
		CommandMahjongSystemRequestHu cmd = new CommandMahjongSystemRequestHu();
		cmd.mCharacter = mCharacterManager.getMyself();
		mCommandSystem.pushCommand(cmd, mMahjongSystem);
		afterActionSelected();
	}
	protected void onGangClicked(GameObject obj)
	{
		CommandMahjongSystemRequestGang cmd = new CommandMahjongSystemRequestGang();
		cmd.mCharacter = mCharacterManager.getMyself();
		mCommandSystem.pushCommand(cmd, mMahjongSystem);
		afterActionSelected();
	}
	protected void onPengClicked(GameObject obj)
	{
		CommandMahjongSystemRequestPeng cmd = new CommandMahjongSystemRequestPeng();
		cmd.mCharacter = mCharacterManager.getMyself();
		mCommandSystem.pushCommand(cmd, mMahjongSystem);
		afterActionSelected();
	}
	protected void onPassClicked(GameObject obj)
	{
		CommandMahjongSystemRequestPass cmd = new CommandMahjongSystemRequestPass();
		cmd.mCharacter = mCharacterManager.getMyself();
		mCommandSystem.pushCommand(cmd, mMahjongSystem);
		afterActionSelected();
	}
	protected void afterActionSelected()
	{
		notifyActionAsk(null);
	}
}