using System;
using System.Collections.Generic;

namespace Badger.Data
{
    /// <summary>
    /// Builder to create a PreparedQuery.
    /// </summary>
    public interface IQueryBuilder
    {
        /// <summary>
        /// Sets the SQL that will be executed.
        /// </summary>
        /// <param name="sql">the SQL text.</param>
        IQueryBuilder WithSql(string sql);

        /// <summary>
        /// Sets a query parameter.
        /// </summary>
        /// <param name="name">the name of the query parameter.</param>
        /// <param name="value">the parameter value.</param>
        IQueryBuilder WithParameter<T>(string name, T value);


        /// <summary>
        /// Sets a string command parameter with a length.
        /// </summary>
        /// <param name="name">the name of the query parameter.</param>
        /// <param name="value">the parameter value.</param>
        /// <param name="length">the max length of the string.</param>
        IQueryBuilder WithParameter(string name, string value, int length);

        /// <summary>
        /// Sets a table parameter.
        /// </summary>
        /// <typeparam name="T">the type of the query parameter.</typeparam>
        /// <param name="name">the name of the query parameter.</param>
        /// <param name="value">the value of the query parameter.</param>
        /// <returns></returns>
        IQueryBuilder WithTableParameter<T>(string name, IEnumerable<T> value);

        /// <summary>
        /// Sets up a mapper for reading a multiple row result set.
        /// </summary>
        /// <param name="mapper">the mapping function.</param>
        IQueryBuilder<IEnumerable<T>> WithMapper<T>(Func<IRow, T> mapper);

        /// <summary>
        /// Sets up a mapper for reading a single row with an optional default if
        /// no rows are returned by the query.
        /// </summary>
        /// <param name="mapper">the mapping function.</param>
        /// <param name="default">the default value.</param>
        IQueryBuilder<T> WithSingleMapper<T>(Func<IRow, T> mapper, T @default = default);

        /// <summary>
        /// Sets up the query to execute for a scalar result with an optioanl default
        /// if null is returned.
        /// </summary>
        /// <param name="default">the default value.</param>
        IQueryBuilder<T> WithScalar<T>(T @default = default);

        /// <summary>
        /// Specifies a command timeout for the query
        /// </summary>
        /// <param name="timeout">the desired timeout.</param>
        /// <returns></returns>
        IQueryBuilder WithTimeout(TimeSpan timeout);
    }

    /// <summary>
    /// Builder to create a PreparedQuery with a known result type.
    /// </summary>
    public interface IQueryBuilder<T>
    {
        /// <summary>
        /// Builds the prepared query.
        /// </summary>
        IPreparedQuery<T> Build();
    }
}
