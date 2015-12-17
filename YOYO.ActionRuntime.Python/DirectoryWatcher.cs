using System;
using System.Timers;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YOYO.ActionRuntime.Python
{
	public class DirectoryWatcher
	{
		public event EventHandler<FileChangedEventArgs> OnFileChanged;

		const double timer_interval = 30000;
		Timer watcher_timer = new Timer ();
		string PathName;
        string searchPattern;


        Dictionary<string, PyFileInfo> files_realtime = new Dictionary<string, PyFileInfo> ();
		Dictionary<string, PyFileInfo> files_last = new Dictionary<string, PyFileInfo> ();

		public DirectoryWatcher (string pathName,string searchpattern)
		{
			this.PathName = pathName;
            this.searchPattern = searchpattern;
			watcher_timer.Elapsed += timer_elapsed;
			watcher_timer.Interval = timer_interval;
			watcher_timer.Enabled = false;
		}

		public void Start ()
		{

			if (!System.IO.Directory.Exists (this.PathName) || !verify_timer ())
				throw new Exception ("The Whatcher thread is not ready, please check!");

			// is a directory and timer is ready
			IEnumerable<PyFileInfo> files = from n in System.IO.Directory.GetFiles (this.PathName,this.searchPattern)
			                               select new PyFileInfo (n, get_file_md5 (n), Status.Added_Modified);
						
			foreach (var f in files) {
				files_realtime.Add (f.FileName, f);
				files_last.Add (f.FileName, f);
			}

			watcher_timer.Start ();
		}

		public void Stop ()
		{
			if (watcher_timer.Enabled)
				watcher_timer.Enabled = false;
		}

		private bool verify_timer ()
		{
			return (watcher_timer.Interval > 0) && watcher_timer.Enabled == false ;
		}

		private void timer_elapsed (object sender, ElapsedEventArgs args)
		{
            files_realtime.Clear(); 

			List<string> dir_files = new List<string> (System.IO.Directory.GetFiles (this.PathName,this.searchPattern));

			dir_files.ForEach (f => {

				files_realtime.Add (f, new PyFileInfo (f, get_file_md5 (f), Status.None));

			});

			var both = files_realtime.Intersect (files_last, new PyFileInfoCompare ());
			var files_added_or_modified = files_realtime.Except (both, new PyFileInfoCompare ());
			var files_removed = files_last.Except (both, new PyFileInfoCompare ());

			foreach (var item in files_added_or_modified) {
				item.Value.status = Status.Added_Modified;
				if (OnFileChanged != null) {
					OnFileChanged (this, new FileChangedEventArgs (item.Value));
					item.Value.status = Status.None;
				}
			}

			foreach (var item in files_removed) {
				item.Value.status = Status.Removed;
				if (OnFileChanged != null) {
					OnFileChanged (this, new FileChangedEventArgs (item.Value));
					item.Value.status = Status.None;
				}
			}



			files_last = files_realtime.ToDictionary (k=>k.Key,v=>v.Value);

		}

		private static string get_file_md5 (string filename)
		{
			try {  
				FileStream file = new FileStream (filename, FileMode.Open);  
				System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider ();  
				byte[] retVal = md5.ComputeHash (file);  
				file.Close ();  

				StringBuilder sb = new StringBuilder ();  
				for (int i = 0; i < retVal.Length; i++) {  
					sb.Append (retVal [i].ToString ("x2"));  
				}  
				return sb.ToString ();  
			} catch (Exception ex) {  
				throw new Exception ("GetMD5HashFromFile() fail,error:" + ex.Message);  
			}  
		}
	}

	public enum Status
	{
		None,
		Added_Modified,
		Removed
	}

	public class PyFileInfo
	{
		public string FileName;
		public string md5;
		public Status status;

		public PyFileInfo (string fname, string md5, Status status)
		{
			this.FileName = fname;
			this.md5 = md5;
			this.status = status;
		}
	}


	public class PyFileInfoCompare:IEqualityComparer<KeyValuePair<string, PyFileInfo>>
	{
		public bool Equals (KeyValuePair<string, PyFileInfo> a, KeyValuePair<string, PyFileInfo> b)
		{
			return (a.Key.Equals (b.Key) && a.Value.md5.Equals (b.Value.md5));
		}

		public int GetHashCode (KeyValuePair<string, PyFileInfo> kv)
		{
			return kv.Value.md5.GetHashCode();
		}
	}

	public class FileChangedEventArgs:EventArgs
	{
		public PyFileInfo FileInfo;

		public FileChangedEventArgs (PyFileInfo fileinfo)
		{
			this.FileInfo = fileinfo;
		}
	}


}

