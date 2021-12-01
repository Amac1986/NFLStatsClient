namespace NFLStats.Model.Models;

public interface IConvertCSV
{
    string ToCSV();
    string GetCSVHead();
}