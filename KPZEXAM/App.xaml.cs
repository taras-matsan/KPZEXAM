using KPZEXAM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KPZEXAM
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private FilmListDBEntities _filmModel;
		public App() 
		{
			_filmModel = FilmListDBEntities.Load();
			var window = new MainWindow() { DataContext = _filmModel };
			window.Show();
		}
	}
}
