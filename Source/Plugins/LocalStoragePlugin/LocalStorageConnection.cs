﻿using CommonNote.PluginInterface;
using System;
using System.Collections.Generic;

namespace CommonNote.Plugins.LocalStorage
{
	class LocalStorageConnection : IRemoteStorageConnection
	{
		public void StartNewSync()
		{
			// ok
		}

		public void FinishNewSync()
		{
			//
		}

		public INote DownloadNote(string id, out bool result)
		{
			result = false;
			return null;
		}

		public void DeleteNote(INote note)
		{
			// ok
		}

		public List<string> ListMissingNotes(List<INote> localnotes)
		{
			return new List<string>();
		}

		public RemoteResult UpdateNote(INote note)
		{
			return RemoteResult.UpToDate;
		}

		public INote UploadNote(INote note)
		{
			return note;
		}
	}
}
