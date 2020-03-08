namespace Lib.DataBase.utils
{
    public interface ISerializable
    {
        byte[] Serialization();
        T Deserialization<T>();
    }
}
