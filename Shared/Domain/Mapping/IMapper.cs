using FurniGo.DataMapper.Shared.Domain.Models;

namespace FurniGo.DataMapper.Shared.Domain.Mapping
{
    public interface IMapper<BaseType, TargetType1, TargetType2> where BaseType : IEntity where TargetType1 : IEntity where TargetType2 : IEntity
    {
        /// <summary>
        /// Maps <paramref name="TargetType1"/> to the <typeparamref name="BaseType"/> type.
        /// </summary>
        /// <param name="toMap"></param>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public BaseType MapBase(TargetType1 toMap, BaseType baseObject);
        /// <summary>
        /// Maps <paramref name="TargetType2"/> to the <typeparamref name="BaseType"/> type.
        /// </summary>
        /// <param name="toMap"></param>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public BaseType MapBase(TargetType2 toMap, BaseType baseObject);
        /// <summary>
        /// Maps <paramref name="TargetType1"/> to the <typeparamref name="BaseType"/> type using the default values when <typeparamref name="TargetType1"/> doesn't provide them
        /// </summary>
        /// <param name="toMap"></param>
        /// <returns></returns>
        public BaseType MapDefault(TargetType1 toMap);
        /// <summary>
        /// Maps <paramref name="TargetType2"/> to the <typeparamref name="BaseType"/> type using the default values when <typeparamref name="TargetType2"/> doesn't provide them
        /// </summary>
        /// <param name="toMap"></param>
        /// <returns></returns>
        public BaseType MapDefault(TargetType2 toMap);
        /// <summary>
        /// Maps <paramref name="BaseType"/> to the <typeparamref name="TargetType1"/>
        /// </summary>
        /// <param name="toMap"></param>
        /// <returns></returns>
        public TargetType1 MapToType1(BaseType toMap);
        /// <summary>
        /// Maps the <paramref name="BaseType"/> to the <typeparamref name="TargetType2"/>
        /// </summary>
        /// <param name="toMap"></param>
        /// <returns></returns>
        public TargetType2 MapToType2(BaseType toMap);
    }
}
