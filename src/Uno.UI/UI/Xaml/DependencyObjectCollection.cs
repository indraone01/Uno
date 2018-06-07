using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Windows.UI.Xaml
{
	/// <summary>
	/// Non-generic base class used to generate the DependencyObject implementation.
	/// </summary>
	public partial class DependencyObjectCollectionBase : DependencyObject
	{
	}

	/// <summary>
	/// Generic base class from which other collections (DependencyObjectCollection, InlineCollection, GeometryCollection, PathFigureCollection, ArcFigureCollection, etc.) derive.
	/// </summary>
	public partial class DependencyObjectCollection<T> : DependencyObjectCollectionBase, IList<T>, IEnumerable<T>, IEnumerable, IObservableVector<T>
		where T : DependencyObject
	{
		public event VectorChangedEventHandler<T> VectorChanged;

		private List<T> _list = new List<T>();

		public DependencyObjectCollection()
		{
			Initialize();
			UpdateParent(this.GetParent());
		}

		internal DependencyObjectCollection(DependencyObject parent, bool isAutoPropertyInheritanceEnabled = true)
		{
			IsAutoPropertyInheritanceEnabled = isAutoPropertyInheritanceEnabled;

			Initialize();
			this.SetParent(parent);
			UpdateParent(parent);
		}

		private void Initialize()
		{
			((IDependencyObjectStoreProvider)this).Store.RegisterSelfParentChangedCallback(
				(instance, k, handler) => UpdateParent(handler.NewParent)
			);

			VectorChanged += (s, e) => OnCollectionChanged();
		}

		/// <summary>
		/// An internal direct access to the internal list to be able to do allocation-free enumeration
		/// </summary>
		internal List<T> Items => _list;

		private void UpdateParent(object parent)
		{
			foreach (var item in _list)
			{
				// Because parent propagation doesn't currently support all cases, 
				// we can't assume that the DependencyObjectCollection will have a parent.
				// To preserve DataContext propagation, we fallback to self if no parent is set.
				item.SetParent(parent ?? this);
			}
		}

		public uint Size
			=> (uint)_list.Count;

		public int Count
			=> _list.Count;

		public bool IsReadOnly 
			=> ((ICollection<T>)_list).IsReadOnly;

		public T this[int index]
		{
			get => _list[index];
			set
			{
				var originalValue = _list[index];

				if (!ReferenceEquals(originalValue, value))
				{
					OnRemoved(originalValue);

					_list[index] = value;

					OnAdded(value);

					RaiseVectorChanged(CollectionChange.ItemChanged, index);
				}
			}
		}

		public int IndexOf(T item) => _list.IndexOf(item);

		public void Insert(int index, T item)
		{
			_list.Insert(index, item);

			OnAdded(item);

			RaiseVectorChanged(CollectionChange.ItemInserted, index);
		}

		public void RemoveAt(int index)
		{
			OnRemoved(_list[index]);

			_list.RemoveAt(index);

			RaiseVectorChanged(CollectionChange.ItemRemoved, index);
		}

		public void Add(T item)
		{
			_list.Add(item);

			OnAdded(item);

			RaiseVectorChanged(CollectionChange.ItemInserted, _list.Count - 1);
		}

		public void Clear()
		{
			for (int index = 0; index < _list.Count; index++)
			{
				OnRemoved(_list[index]);
			}

			_list.Clear();

			RaiseVectorChanged(CollectionChange.Reset, 0);
		}

		public bool Contains(T item) 
			=> _list.Contains(item);

		public void CopyTo(T[] array, int arrayIndex) 
			=> _list.CopyTo(array, arrayIndex);

		public bool Remove(T item)
		{
			var index = _list.IndexOf(item);

			if (index != -1)
			{
				RemoveAt(index);

				return true;
			}
			else
			{
				return false;
			}
		}

		public IEnumerator<T> GetEnumerator() 
			=> _list.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() 
			=> _list.GetEnumerator();

		private void RaiseVectorChanged(CollectionChange change, int index) 
			=> VectorChanged?.Invoke(this, new VectorChangedEventArgs(change, (uint)index));

		private protected virtual void OnAdded(T d)
		{
			// Because parent propagation doesn't currently support all cases, 
			// we can't assume that the DependencyObjectCollection will have a parent.
			// To preserve DataContext propagation, we fallback to self if no parent is set.
			d.SetParent(this.GetParent() ?? this); 
		}

		private protected virtual void OnRemoved(T d)
		{
			d.SetParent(null);
		}

		private protected virtual void OnCollectionChanged()
		{
		}
	}

	/// <summary>
	/// Implements a practical collection class that can contain DependencyObject items.
	/// </summary>
	public partial class DependencyObjectCollection : DependencyObjectCollection<DependencyObject>
	{
	}
}