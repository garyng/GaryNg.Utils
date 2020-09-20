using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace GaryNg.Utils.Wpf.Controls
{
	public class CollectionContainer : ContentControl
	{
		public static readonly DependencyProperty EmptyContentProperty = DependencyProperty.Register(
			"EmptyContent", typeof(object), typeof(CollectionContainer), new PropertyMetadata(default(object)));

		public object EmptyContent
		{
			get { return (object) GetValue(EmptyContentProperty); }
			set { SetValue(EmptyContentProperty, value); }
		}

		public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register(
			"Collection", typeof(ICollection), typeof(CollectionContainer),
			new PropertyMetadata(default(ICollection), OnCollectionPropertyChanged));

		public ICollection Collection
		{
			get { return (ICollection) GetValue(CollectionProperty); }
			set { SetValue(CollectionProperty, value); }
		}

		public static readonly DependencyProperty IsEmptyProperty = DependencyProperty.Register(
			"IsEmpty", typeof(bool), typeof(CollectionContainer), new PropertyMetadata(default(bool)));

		public bool IsEmpty
		{
			get { return (bool) GetValue(IsEmptyProperty); }
			set { SetValue(IsEmptyProperty, value); }
		}


		private static void OnCollectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs dpe)
		{
			if (dpe.OldValue != null && dpe.OldValue is INotifyCollectionChanged oldValue)
			{
				oldValue.CollectionChanged -= OnCollectionChanged;
			}

			if (dpe.NewValue != null && dpe.NewValue is INotifyCollectionChanged newValue)
			{
				newValue.CollectionChanged += OnCollectionChanged;
			}

			updateIsEmpty();

			void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs nce)
			{
				updateIsEmpty();
			}

			void updateIsEmpty()
			{
				d.SetValue(IsEmptyProperty, (d.GetValue(CollectionProperty) as ICollection)?.Count == 0);
			}
		}
	}
}