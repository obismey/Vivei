/*
 * Created by SharpDevelop.
 * User: vachezer
 * Date: 20/02/2015
 * Time: 10:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Vivei.Dashboard.Tools.Core
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class Lookup<TKey, TElement> : IEnumerable<Lookup<TKey, TElement>.Grouping> {
		IEqualityComparer<TKey> comparer;
		public Grouping[] groupings;
		Grouping lastGrouping;
		public int count;
		
		
		public Lookup(IEqualityComparer<TKey> comparer) {
			if (comparer == null) comparer = EqualityComparer<TKey>.Default;
			this.comparer = comparer;
			groupings = new Grouping[7];
		}
		
		public IEnumerable<TResult> ApplyResultSelector<TResult>(Func<TKey, IEnumerable<TElement>, TResult> resultSelector){
			Grouping g = lastGrouping;
			if (g != null) {
				do {
					g = g.next;
					if (g.count != g.elements.Length) { Array.Resize<TElement>(ref g.elements, g.count); }
					yield return resultSelector(g.key, g.elements);
				}while (g != lastGrouping);
			}
		}
		
		private int InternalGetHashCode(TKey key)
		{
			//[....] DevDivBugs 171937. work around comparer implementations that throw when passed null
			return (key == null) ? 0 : comparer.GetHashCode(key) & 0x7FFFFFFF;
		}
		
		public Grouping GetGrouping(TKey key, bool create) {
			int hashCode = InternalGetHashCode(key);
			for (Grouping g = groupings[hashCode % groupings.Length]; g != null; g = g.hashNext)
				if (g.hashCode == hashCode && comparer.Equals(g.key, key)) return g;
			if (create) {
				if (count == groupings.Length) Resize();
				int index = hashCode % groupings.Length;
				Grouping g = new Grouping();
				g.key = key;
				g.hashCode = hashCode;
				g.elements = new TElement[1];
				g.hashNext = groupings[index];
				groupings[index] = g;
				if (lastGrouping == null) {
					g.next = g;
				}
				else {
					g.next = lastGrouping.next;
					lastGrouping.next = g;
				}
				lastGrouping = g;
				count++;
				return g;
			}
			return null;
		}
		
		void Resize() {
			int newSize = checked(count * 2 + 1);
			Grouping[] newGroupings = new Grouping[newSize];
			Grouping g = lastGrouping;
			do {
				g = g.next;
				int index = g.hashCode % newSize;
				g.hashNext = newGroupings[index];
				newGroupings[index] = g;
			} while (g != lastGrouping);
			groupings = newGroupings;
		}
		
		public class Grouping
		{
			public TKey key;
			internal int hashCode;
			public TElement[] elements;
			public int count;
			internal Grouping hashNext;
			internal Grouping next;
			
			public void Add(TElement element) {
				if (elements.Length == count) Array.Resize(ref elements, checked(count * 2));
				elements[count] = element;
				count++;
			}
			
			public override string ToString()
			{
				return key.ToString();
			}
 
		}

        public class GroupingComparer : IComparer<Grouping>
        {
            Comparer<TKey> cmp = Comparer<TKey>.Default;

            int IComparer<Grouping>.Compare(Grouping x, Grouping y)
            {
                return cmp.Compare(x.key, y.key);
            }
        }
		
		IEnumerator<Grouping> IEnumerable<Grouping>.GetEnumerator()
		{
			 Grouping g = lastGrouping;
            if (g != null) {
                do {
                    g = g.next;
                    yield return g;
                } while (g != lastGrouping);
            }
		}
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			 Grouping g = lastGrouping;
            if (g != null) {
                do {
                    g = g.next;
                    yield return g;
                } while (g != lastGrouping);
            }
		}
	}
}