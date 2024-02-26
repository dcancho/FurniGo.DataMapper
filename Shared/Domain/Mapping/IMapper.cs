using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.Shared.Domain.Mapping
{
	/// <summary>
	/// Mapper from <typeparamref name="T1"/> to <typeparamref name="T2"/> and vice versa for saving and retrieving data from the database.
	/// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
    public interface IMapper<T1, T2>
    {
        /// <summary>
        /// Maps <typeparamref name="T2"/> to the <typeparamref name="T1"/> type.
        /// </summary>
        /// <param name="toMap"></param>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public T1 Map(T2 toMap);
				/// <summary>
				/// Maps <typeparamref name="T1"/> to the <typeparamref name="T2"/> type.
				/// </summary>
				/// <param name="toMap"></param>
				/// <returns></returns>
        public T2 Map(T1 toMap);
    }
}
