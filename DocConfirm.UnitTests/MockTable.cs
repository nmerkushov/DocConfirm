using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LinqToDB;

namespace DocConfirm.UnitTests
{
	public class MockTable<T> : ITable<T> where T : class
	{
		private readonly IList<T> _entities;

		public MockTable(IList<T> entities)
		{
			_entities = entities;
		}

		#region ITable<T> Members

		public IEnumerator<T> GetEnumerator()
		{
			return _entities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Expression Expression
		{
			get
			{
				return _entities.AsQueryable().Expression;
			}
			set
			{
				//
			}
		}

		public Type ElementType
		{
			get
			{
				return _entities.AsQueryable().ElementType;
			}
		}

		public IQueryProvider Provider
		{
			get
			{
				return _entities.AsQueryable().Provider;
			}
		}

		public void InsertOnSubmit(T entity)
		{
			throw new NotImplementedException();
		}

		public void Attach(T entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteOnSubmit(T entity)
		{
			throw new NotImplementedException();
		}


		// no release - return null
		public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken token)
		{
			return null;
		}

		public IQueryable CreateQuery(Expression expression)
		{
			return null;
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return null;
		}

		public object Execute(Expression expression)
		{
			return null;
		}

		public TResult Execute<TResult>(Expression expression)
		{
			return default(TResult);
		}
		public string SqlText { get; }
		public IDataContext DataContext { get; }


		#endregion ITable<T> Members
	}
}