﻿using AlephNote.PluginInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using AlephNote.Common.Plugins;
using AlephNote.Common.AlephXMLSerialization;
using System.Linq;

namespace AlephNote.Settings
{
	// ReSharper disable RedundantThisQualifier
	// ReSharper disable CompareOfFloatsByEqualityOperator
	public class AppSettings : ObservableObject, IAlephSerializable
	{
		public const string ENCRYPTION_KEY = @"jcgkZJvoykjpoGkDWHqiNoXoLZRJxpdb";

		[AlephXMLField]
		public ConfigInterval SynchronizationFrequency { get { return _synchronizationFreq; } set { _synchronizationFreq = value; OnPropertyChanged(); } }
		private ConfigInterval _synchronizationFreq = ConfigInterval.Sync15Min;

		[AlephXMLField]
		public bool ProxyEnabled { get { return _proxyEnabled; } set { _proxyEnabled = value; OnPropertyChanged(); } }
		private bool _proxyEnabled = false;

		[AlephXMLField]
		public string ProxyHost { get { return _proxyHost; } set { _proxyHost = value; OnPropertyChanged(); } }
		private string _proxyHost = string.Empty;

		[AlephXMLField]
		public int? ProxyPort { get { return _proxyPort; } set { _proxyPort = value; OnPropertyChanged(); } }
		private int? _proxyPort = null;

		[AlephXMLField]
		public string ProxyUsername { get { return _proxyUsername; } set { _proxyUsername = value; OnPropertyChanged(); } }
		private string _proxyUsername = string.Empty;

		[AlephXMLField(Encrypted=true)]
		public string ProxyPassword { get { return _proxyPassword; } set { _proxyPassword = value; OnPropertyChanged(); } }
		private string _proxyPassword = string.Empty;

		[AlephXMLField]
		public bool MinimizeToTray { get { return _minimizeToTray; } set { _minimizeToTray = value; OnPropertyChanged(); } }
		private bool _minimizeToTray = true;

		[AlephXMLField]
		public bool CloseToTray { get { return _closeToTray; } set { _closeToTray = value; OnPropertyChanged(); } }
		private bool _closeToTray = false;

		[AlephXMLField]
		public string TitleFontFamily { get { return _titleFontFamily; } set { _titleFontFamily = value; OnPropertyChanged(); } }
		private string _titleFontFamily = string.Empty;

		[AlephXMLField]
		public FontModifier TitleFontModifier { get { return _titleFontModifier; } set { _titleFontModifier = value; OnPropertyChanged(); } }
		private FontModifier _titleFontModifier = FontModifier.Bold;

		[AlephXMLField]
		public FontSize TitleFontSize { get { return _titleFontSize; } set { _titleFontSize = value; OnPropertyChanged(); } }
		private FontSize _titleFontSize = FontSize.Size16;

		[AlephXMLField]
		public string NoteFontFamily { get { return _noteFontFamily; } set { _noteFontFamily = value; OnPropertyChanged(); } }
		private string _noteFontFamily = string.Empty;

		[AlephXMLField]
		public FontModifier NoteFontModifier { get { return _noteFontModifier; } set { _noteFontModifier = value; OnPropertyChanged(); } }
		private FontModifier _noteFontModifier = FontModifier.Normal;

		[AlephXMLField]
		public FontSize NoteFontSize { get { return _noteFontSize; } set { _noteFontSize = value; OnPropertyChanged(); } }
		private FontSize _noteFontSize = FontSize.Size08;

		[AlephXMLField]
		public string ListFontFamily { get { return _listFontFamily; } set { _listFontFamily = value; OnPropertyChanged(); } }
		private string _listFontFamily = string.Empty;

		[AlephXMLField]
		public FontModifier ListFontModifier { get { return _listFontModifier; } set { _listFontModifier = value; OnPropertyChanged(); } }
		private FontModifier _listFontModifier = FontModifier.Normal;

		[AlephXMLField]
		public FontSize ListFontSize { get { return _listFontSize; } set { _listFontSize = value; OnPropertyChanged(); } }
		private FontSize _listFontSize = FontSize.Size12;

		[AlephXMLField]
		public bool SciLineNumbers { get { return _sciLineNumbers; } set { _sciLineNumbers = value; OnPropertyChanged(); } }
		private bool _sciLineNumbers = false;

		[AlephXMLField]
		public bool SciRectSelection { get { return _sciRectSelection; } set { _sciRectSelection = value; OnPropertyChanged(); } }
		private bool _sciRectSelection = false;

		[AlephXMLField]
		public bool SciZoomable { get { return _sciZoomable; } set { _sciZoomable = value; OnPropertyChanged(); } }
		private bool _sciZoomable = true;

		[AlephXMLField]
		public bool SciUseTabs { get { return _sciUseTabs; } set { _sciUseTabs = value; OnPropertyChanged(); } }
		private bool _sciUseTabs = true;
		
		[AlephXMLField]
		public bool SciWordWrap { get { return _sciWordWrap; } set { _sciWordWrap = value; OnPropertyChanged(); } }
		private bool _sciWordWrap = false;

		[AlephXMLField]
		public bool SciShowWhitespace { get { return _sciShowWhitespace; } set { _sciShowWhitespace = value; OnPropertyChanged(); } }
		private bool _sciShowWhitespace = false;

		[AlephXMLField]
		public bool SciShowEOL { get { return _sciShowEOL; } set { _sciShowEOL = value; OnPropertyChanged(); } }
		private bool _sciShowEOL = false;

		[AlephXMLField]
		public int SciTabWidth { get { return _sciTabWidth; } set { _sciTabWidth = value; OnPropertyChanged(); } }
		private int _sciTabWidth = 4;

		[AlephXMLField]
		public int StartupPositionX { get { return _startupPositionX; } set { _startupPositionX = value; OnPropertyChanged(); } }
		private int _startupPositionX = 64;

		[AlephXMLField]
		public int StartupPositionY { get { return _startupPositionY; } set { _startupPositionY = value; OnPropertyChanged(); } }
		private int _startupPositionY = 64;

		[AlephXMLField]
		public int StartupPositionWidth { get { return _startupPositionWidth; } set { _startupPositionWidth = value; OnPropertyChanged(); } }
		private int _startupPositionWidth = 525;

		[AlephXMLField]
		public int StartupPositionHeight { get { return _startupPositionHeight; } set { _startupPositionHeight = value; OnPropertyChanged(); } }
		private int _startupPositionHeight = 350;

		[AlephXMLField]
		public ExtendedWindowStartupLocation StartupLocation { get { return _startupLocation; } set { _startupLocation = value; OnPropertyChanged(); } }
		private ExtendedWindowStartupLocation _startupLocation = ExtendedWindowStartupLocation.ScreenBottomLeft;
		
		[AlephXMLField]
		public ExtendedWindowState StartupState { get { return _startupState; } set { _startupState = value; OnPropertyChanged(); } }
		private ExtendedWindowState _startupState = ExtendedWindowState.Normal;

		[AlephXMLField]
		public bool LaunchOnBoot { get { return _launchOnBoot; } set { _launchOnBoot = value; OnPropertyChanged(); } }
		private bool _launchOnBoot = false;

		[AlephXMLField]
		public SortingMode NoteSorting { get { return _noteSorting; } set { _noteSorting = value; OnPropertyChanged(); } }
		private SortingMode _noteSorting = SortingMode.ByModificationDate;

		[AlephXMLField]
		public int SciZoom { get { return _sciZoom; } set { _sciZoom = value; OnPropertyChanged(); } }
		private int _sciZoom = 1;

		[AlephXMLField]
		public double OverviewListWidth { get { return _overviewListWidth; } set { _overviewListWidth = value; OnPropertyChanged(); } }
		private double _overviewListWidth = 150;

		[AlephXMLField]
		public NotePreviewStyle NotePreviewStyle { get { return _notePreviewStyle; } set { _notePreviewStyle = value; OnPropertyChanged(); } }
		private NotePreviewStyle _notePreviewStyle = NotePreviewStyle.Extended;

		[AlephXMLField]
		public ConflictResolutionStrategy ConflictResolution { get { return _conflictResolution; } set { _conflictResolution = value; OnPropertyChanged(); } }
		private ConflictResolutionStrategy _conflictResolution = ConflictResolutionStrategy.UseClientCreateConflictFile;

		[AlephXMLField]
		public bool DocSearchEnabled { get { return _docSearchEnabled; } set { _docSearchEnabled = value; OnPropertyChanged(); } }
		private bool _docSearchEnabled = true;

		[AlephXMLField]
		public bool DocSearchCaseSensitive { get { return _docSearchCaseSensitive; } set { _docSearchCaseSensitive = value; OnPropertyChanged(); } }
		private bool _docSearchCaseSensitive = false;

		[AlephXMLField]
		public bool DocSearchWholeWord { get { return _docSearchWholeWord; } set { _docSearchWholeWord = value; OnPropertyChanged(); } }
		private bool _docSearchWholeWord = false;

		[AlephXMLField]
		public bool DocSearchRegex { get { return _docSearchRegex; } set { _docSearchRegex = value; OnPropertyChanged(); } }
		private bool _docSearchRegex = false;

		[AlephXMLField]
		public bool DocSearchLiveSearch { get { return _docSearchLiveSearch; } set { _docSearchLiveSearch = value; OnPropertyChanged(); } }
		private bool _docSearchLiveSearch = true;

		[AlephXMLField]
		public SciRegexEngine DocSearchRegexEngine { get { return _docSearchRegexEngine; } set { _docSearchRegexEngine = value; OnPropertyChanged(); } }
		private SciRegexEngine _docSearchRegexEngine = SciRegexEngine.CPlusPlus;

		[AlephXMLField]
		public bool CheckForUpdates { get { return _checkForUpdates; } set { _checkForUpdates = value; OnPropertyChanged(); } }
		private bool _checkForUpdates = true;

		[AlephXMLField]
		public bool DoGitMirror { get { return _doGitMirror; } set { _doGitMirror = value; OnPropertyChanged(); } }
		private bool _doGitMirror = false;

		[AlephXMLField]
		public string GitMirrorPath { get { return _gitMirrorPath; } set { _gitMirrorPath = value; OnPropertyChanged(); } }
		private string _gitMirrorPath = string.Empty;

		[AlephXMLField]
		public string GitMirrorFirstName { get { return _gitMirrorFirstName; } set { _gitMirrorFirstName = value; OnPropertyChanged(); } }
		private string _gitMirrorFirstName = "AlephNote";

		[AlephXMLField]
		public string GitMirrorLastName { get { return _gitMirrorLastName; } set { _gitMirrorLastName = value; OnPropertyChanged(); } }
		private string _gitMirrorLastName = "Git";

		[AlephXMLField]
		public string GitMirrorMailAddress { get { return _gitMirrorMailAddress; } set { _gitMirrorMailAddress = value; OnPropertyChanged(); } }
		private string _gitMirrorMailAddress = "auto@example.com";

		[AlephXMLField]
		public bool GitMirrorDoPush { get { return _gitMirrorDoPush; } set { _gitMirrorDoPush = value; OnPropertyChanged(); } }
		private bool _gitMirrorDoPush = false;

		[AlephXMLField]
		public RemoteStorageAccount ActiveAccount { get { return _activeAccount; } set { _activeAccount = value; OnPropertyChanged(); } }
		private RemoteStorageAccount _activeAccount = null;

		[AlephXMLField]
		public ObservableCollectionNoReset<RemoteStorageAccount> Accounts { get { return _accounts; } set { _accounts = value; OnPropertyChanged(); } }
		public ObservableCollectionNoReset<RemoteStorageAccount> _accounts = new ObservableCollectionNoReset<RemoteStorageAccount>();

		private static readonly AlephXMLSerializer<AppSettings> _serializer = new AlephXMLSerializer<AppSettings>("configuration");

		private readonly string _path;

		private AppSettings(string path)
		{
			_path = path;
		}

		public static AppSettings CreateEmpty(string path)
		{
			var r = new AppSettings(path);

			var defplugin = PluginManagerSingleton.Inst.GetDefaultPlugin();
			r._activeAccount = new RemoteStorageAccount(Guid.NewGuid(), defplugin, defplugin.CreateEmptyRemoteStorageConfiguration());

			r._accounts.Add(r._activeAccount);

			return r;
		}

		public void Save()
		{
			File.WriteAllText(_path, Serialize());
		}

		public static AppSettings Load(string path)
		{
			return Deserialize(File.ReadAllText(path), path);
		}

		public string Serialize()
		{
			return _serializer.Serialize(this);
		}

		public static AppSettings Deserialize(string xml, string path)
		{
			var r = CreateEmpty(path);
			_serializer.Deserialize(r, xml);
			return r;
		}

		public void OnAfterDeserialize()
		{
			_activeAccount = _accounts.FirstOrDefault(a => a.ID == _activeAccount.ID);
			if (_activeAccount == null) throw new Exception("Deserialization error: ActiveAccount not found in AccountList");
		}

		public AppSettings Clone()
		{
			var r = CreateEmpty(_path);

			_serializer.Clone(this, r);

			return r;
		}

		public bool IsEqual(AppSettings other)
		{
			return _serializer.IsEqual(this, other);
		}

		public void RemoveAccount(RemoteStorageAccount acc)
		{
			if (_activeAccount == acc) ActiveAccount = Accounts.FirstOrDefault();

			Accounts.Remove(acc);

			OnPropertyChanged("Accounts");
		}

		public void AddAccountAndSetActive(RemoteStorageAccount acc)
		{
			Accounts.Add(acc);
			ActiveAccount = acc;

			OnPropertyChanged("Accounts");
		}

		public IWebProxy CreateProxy()
		{
			if (ProxyEnabled)
			{
				if (string.IsNullOrWhiteSpace(ProxyUsername) && string.IsNullOrWhiteSpace(ProxyPassword))
				{
					return PluginManagerSingleton.Inst.GetProxyFactory().Build(ProxyHost, ProxyPort ?? 443);
				}
				else
				{
					return PluginManagerSingleton.Inst.GetProxyFactory().Build(ProxyHost, ProxyPort ?? 443, ProxyUsername, ProxyPassword);
				}
			}
			else
			{
				return PluginManagerSingleton.Inst.GetProxyFactory().Build();
			}
		}

		public int GetSyncDelay()
		{
			switch (SynchronizationFrequency)
			{
				case ConfigInterval.Sync01Min:  return       1 * 60 * 1000;
				case ConfigInterval.Sync02Min:  return       2 * 60 * 1000;
				case ConfigInterval.Sync05Min:  return       5 * 60 * 1000;
				case ConfigInterval.Sync10Min:  return      10 * 60 * 1000;
				case ConfigInterval.Sync15Min:  return      15 * 60 * 1000;
				case ConfigInterval.Sync30Min:  return      30 * 60 * 1000;
				case ConfigInterval.Sync01Hour: return  1 * 60 * 60 * 1000;
				case ConfigInterval.Sync02Hour: return  1 * 60 * 60 * 1000;
				case ConfigInterval.Sync06Hour: return  6 * 60 * 60 * 1000;
				case ConfigInterval.Sync12Hour: return 12 * 60 * 60 * 1000;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public IComparer GetNoteComparator()
		{
			switch (NoteSorting)
			{
				case SortingMode.None:
					return ProjectionComparer.Create<INote, string>(n => n.GetUniqueName());
				case SortingMode.ByName:
					return ProjectionComparer.Create<INote, string>(n => n.Title);
				case SortingMode.ByCreationDate:
					return ProjectionComparer.Create<INote, DateTimeOffset>(n => n.CreationDate, true);
				case SortingMode.ByModificationDate:
					return ProjectionComparer.Create<INote, DateTimeOffset>(n => n.ModificationDate, true);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
