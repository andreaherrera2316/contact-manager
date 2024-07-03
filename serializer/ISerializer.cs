public interface ISerializer<T>
{
    string Serialize(List<T> items);
    List<T> Deserialize(string json);
}
