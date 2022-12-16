using KPZEXAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KPZEXAM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		FilmListDBEntities entities;
		private int current = 0;
		public MainWindow()
		{
			entities = FilmListDBEntities.Load();
			DataContext = entities;
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (current == 0) 
			{
				if (entities.Films.ToList().SingleOrDefault(x => x.FilmID == int.Parse(boxid.Text.ToString())) == null) 
				{
					entities.Films.Remove(entities.Films.ToList().SingleOrDefault(x => x.FilmID == int.Parse(boxid.Text.ToString())));
				}
			}
			if (current == 1)
			{
				if (entities.Subscribers.ToList().SingleOrDefault(x => x.SubscriberID == int.Parse(boxid.Text.ToString())) == null)
				{
					entities.Subscribers.Remove(entities.Subscribers.ToList().SingleOrDefault(x => x.SubscriberID == int.Parse(boxid.Text.ToString())));
				}
			}
			if (current == 2)
			{
				if (entities.Comments.ToList().SingleOrDefault(x => x.CommentID == int.Parse(boxid.Text.ToString())) == null)
				{
					entities.Comments.Remove(entities.Comments.ToList().SingleOrDefault(x => x.CommentID == int.Parse(boxid.Text.ToString())));
				}
			}
			if (current == 3)
			{
				if (entities.Reviews.ToList().SingleOrDefault(x => x.ReviewID == int.Parse(boxid.Text.ToString())) == null)
				{
					entities.Reviews.Remove(entities.Reviews.ToList().SingleOrDefault(x => x.ReviewID == int.Parse(boxid.Text.ToString())));
				}
			}
			entities.SaveChanges();
		}
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			base.OnClosing(e);
			entities.Dispose();
		}

		private void Film_Click(object sender, RoutedEventArgs e)
		{
			current = 0;
			Filmcontrol.Visibility = Visibility.Visible;
			Subscribercontrol.Visibility = Visibility.Collapsed;
			Commentcontrol.Visibility = Visibility.Collapsed;
			Reviewcontrol.Visibility = Visibility.Collapsed;
		}

		private void Subscriber_Click(object sender, RoutedEventArgs e)
		{
			current = 1;
			Filmcontrol.Visibility = Visibility.Collapsed;
			Subscribercontrol.Visibility = Visibility.Visible;
			Commentcontrol.Visibility = Visibility.Collapsed;
			Reviewcontrol.Visibility = Visibility.Collapsed;
		}

		private void Comment_Click(object sender, RoutedEventArgs e)
		{
			current = 2;
			Filmcontrol.Visibility = Visibility.Collapsed;
			Subscribercontrol.Visibility = Visibility.Collapsed;
			Commentcontrol.Visibility = Visibility.Visible;
			Reviewcontrol.Visibility = Visibility.Collapsed;
		}

		private void Review_Click(object sender, RoutedEventArgs e)
		{
			current = 3;
			Filmcontrol.Visibility = Visibility.Collapsed;
			Subscribercontrol.Visibility = Visibility.Collapsed;
			Commentcontrol.Visibility = Visibility.Collapsed;
			Reviewcontrol.Visibility = Visibility.Visible;
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			if (current == 0)
			{
				entities.Films.Add(new Film() { FilmID = int.Parse(boxid.Text), FilmName = boxname.Text, FilmPath = boxpath.Text });
			}
			if (current == 1)
			{
				entities.Subscribers.Add(new Subscriber() { SubscriberID = int.Parse(boxid.Text), SubscriberNick = boxname.Text });
			}
			if (current == 2)
			{
				entities.Comments.Add(new Comment() { CommentID = int.Parse(boxid.Text), CommentText = boxname.Text});
			}
			if (current == 3)
			{
				entities.Reviews.Add(new Review() { ReviewID = int.Parse(boxid.Text), ReviewText = boxname.Text});
			}
			entities.SaveChanges();
		}

		private void Button_Change_Click(object sender, RoutedEventArgs e)
		{
			if (current == 0)
			{
				if (entities.Films.ToList().SingleOrDefault(x => x.FilmID == int.Parse(boxid.Text.ToString())) == null)
				{
					entities.Films.ToList().SingleOrDefault(x => x.FilmID == int.Parse(boxid.Text.ToString())).FilmName = boxname.Text;
					entities.Films.ToList().SingleOrDefault(x => x.FilmID == int.Parse(boxid.Text.ToString())).FilmPath = boxpath.Text;
				}
			}
			if (current == 1)
			{
				if (entities.Subscribers.ToList().SingleOrDefault(x => x.SubscriberID == int.Parse(boxid.Text.ToString())) == null)
				{
					entities.Subscribers.ToList().SingleOrDefault(x => x.SubscriberID == int.Parse(boxid.Text.ToString())).SubscriberNick = boxname.Text;
				}
			}
			if (current == 2)
			{
				entities.Comments.ToList().SingleOrDefault(x => x.CommentID == int.Parse(boxid.Text.ToString())).CommentText = boxname.Text;
			}
			if (current == 3)
			{
				entities.Reviews.ToList().SingleOrDefault(x => x.ReviewID == int.Parse(boxid.Text.ToString())).ReviewText = boxname.Text;
			}
			entities.SaveChanges();
		}
	}
}
