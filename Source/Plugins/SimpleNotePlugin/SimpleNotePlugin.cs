﻿using CommonNote.PluginInterface;
using System;

namespace CommonNote.Plugins.SimpleNote
{
	public class SimpleNotePlugin : ICommonNoteProvider
	{
		public string GetName()
		{
			return "Simplenote";
		}

		public Version GetVersion()
		{
			return new Version(0, 0, 0, 1);
		}

		public IRemoteStorageConfiguration CreateEmptyRemoteStorageConfiguration()
		{
			throw new NotImplementedException();
		}

		public IRemoteStorageConnection CreateRemoteStorageConnection(IRemoteStorageConfiguration config)
		{
			throw new NotImplementedException();
		}
	}
}
