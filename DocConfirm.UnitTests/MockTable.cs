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
				throw new NotImplementedException();
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

		public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken token)
		{
			throw new NotImplementedException();
		}

		public IQueryable CreateQuery(Expression expression)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			throw new NotImplementedException();
		}

		public object Execute(Expression expression)
		{
			throw new NotImplementedException();
		}

		public TResult Execute<TResult>(Expression expression)
		{
			throw new NotImplementedException();
		}

		public string SqlText
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IDataContext DataContext
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}