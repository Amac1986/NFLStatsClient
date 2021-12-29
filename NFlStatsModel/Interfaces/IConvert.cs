namespace NFLStats.Model.Models;

public interface IConvert
{
    string ToCSV();
    string GetCSVHead();
    string ToHtml(string element);
    string GetHtmlHead();
}