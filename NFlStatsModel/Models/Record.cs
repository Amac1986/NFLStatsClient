using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.Models
{
    public abstract class Record
    {
        public abstract string GetCSVHead();
        public abstract string GetHtmlHead();
        public virtual string ToCSV() {
            return string.Join(",", GetType().GetProperties().Select(p => p.GetValue(this)).ToArray());
        }
        public abstract string ToHtml(string element);

        public string BuildHeadHtml(string[] displayNames, Func<System.Reflection.PropertyInfo, bool> propertyFilter) {

            var PropertyNames = GetType().GetProperties().Where(p => propertyFilter.Invoke(p))
                .OrderBy(x => x.MetadataToken)                                         
                .Select(p => p.Name);
            var combined = PropertyNames.Select((pn, index) => new { Name = pn, Display = displayNames[index] });

            return string.Join("", combined.Select(c => $"<th data-column-name=\"{c.Name}\">{c.Display}</th>").ToArray());
        }

        public string BuildHtml(string element, Func<System.Reflection.PropertyInfo, bool> propertyFilter)
        {
            return string.Join("", GetType().GetProperties()
                .Where(p => propertyFilter.Invoke(p))
                .OrderBy(x => x.MetadataToken)
                .Select(p => p.GetValue(this))
                .Select(v => $"<{element}>{v}</{element}>")
                .ToArray());
        }
    }
}
