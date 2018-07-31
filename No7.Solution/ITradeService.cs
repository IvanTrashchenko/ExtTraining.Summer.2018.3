using System.IO;

namespace No7.Solution
{
    public interface ITradeService
    {
        void ReadStream(Stream stream);

        void ParseToRecords();

        void SaveToTable(string connectionString);
    }

    // абстракция сервиса для работы со списком записей
}
