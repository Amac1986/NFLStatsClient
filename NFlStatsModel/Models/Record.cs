using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.Models
{
    public abstract class Record : IConvert
    {
        public abstract string GetCSVHead();
        public abstract string GetHtmlHead();
        public virtual string ToCSV() {
            return string.Join(",", GetType().GetProperties().Select(p => p.GetValue(p)).ToArray());
        }
        public abstract string ToHtml(string element);

        public string BuildHeadHtml(string[] displayNames) {

            var PropertyNames = GetType().GetProperties().Select(p => p.Name);
            var combined = PropertyNames.Select((pn, index) => new { Name = pn, Display = displayNames[index] });

            return string.Join("", combined.Select(c => $"<th data-column-name=\"{c.Name}\">{c.Display}</th>").ToArray());
        }

        public string BuildHtml(string element)
        {
            return string.Join("", GetType().GetProperties().Select(p => p.GetValue(p)).Select(v => $"<{element}>{v}</{element}>").ToArray());
        }
    }
}
