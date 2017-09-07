namespace Badger.Data
{
    public interface IDbScalarQueryBuilder<T>
    {
        IDbScalarQueryBuilder<T> WithSql(string sql);
        IDbScalarQueryBuilder<T> WithParameter<TParam>(string name, TParam value);
        IDbScalarQueryBuilder<T> WithDefault(T @default);
        IDbScalarQuery<T> Build();
    }
}