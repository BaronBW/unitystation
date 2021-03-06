﻿using System;
using System.Collections;
using System.Collections.Generic;
using DatabaseAPI;
using UnityEngine;

namespace AdminTools
{
	public class AdminPage : MonoBehaviour
	{
		protected AdminPageRefreshData currentData;
		protected GUI_AdminTools adminTools;

		public virtual void OnEnable()
		{
			if (adminTools == null)
			{
				adminTools = FindObjectOfType<GUI_AdminTools>();
			}
			RefreshPage();
		}

		public void RefreshPage()
		{
			RequestAdminPageRefresh.Send(ServerData.UserID, PlayerList.Instance.AdminToken);
		}

		public virtual void OnPageRefresh(AdminPageRefreshData adminPageData)
		{
			currentData = adminPageData;
			adminTools.RefreshOnlinePlayerList(adminPageData);
			adminTools.CloseRetrievingDataScreen();
		}
	}

	[Serializable]
	public class AdminPageRefreshData
	{
		//GameMode updates:
		public List<string> availableGameModes = new List<string>();
		public string currentGameMode;
		public bool isSecret;
		public string nextGameMode;

		//Player Management:
		public List<AdminPlayerEntryData> players = new List<AdminPlayerEntryData>();

	}

	[Serializable]
	public class AdminPlayerEntryData
	{
		public string name;
		public string uid;
		public string currentJob;
		public string accountName;
		public bool isAlive;
		public bool isAntag;
		public bool isAdmin;
		public bool isOnline;
		public List<AdminChatMessage> newMessages = new List<AdminChatMessage>();
	}

	[Serializable]
	public class AdminChatMessage
	{
		public string fromUserid;
		public string toUserid;
		public string message;
	}
}