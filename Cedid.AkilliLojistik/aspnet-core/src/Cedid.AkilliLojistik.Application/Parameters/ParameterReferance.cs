using Cedid.AkilliLojistik.Attribute;
using Cedid.AkilliLojistik.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Cedid.AkilliLojistik.Parameters
{
    public class ParameterReferance : IParameterReferance, IScopedDependency
    {

        public ParameterReferance(IRepository<Parameter, int> repository)
        {
            Repository = repository;
        }

        public IRepository<Parameter, int> Repository { get; }

        public async Task FillParameterRefs(object o)
        {
            var props = o.GetType().GetProperties();
            foreach (var prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    ParamaterRefAttribute paramaterRefAttribute = attr as ParamaterRefAttribute;
                    if (paramaterRefAttribute != null)
                    {
                        string refProperty = paramaterRefAttribute.ReferanceProperty;
                        string[] columns = paramaterRefAttribute.TargetColumns;

                        int parameterId = Convert.ToInt32(o.GetType().GetProperty(refProperty).GetValue(o, null));

                        string refText = await GetParameterText(parameterId, columns);

                        prop.SetValue(o, refText);
                    }
                }
            }
        }

        private async Task<string> GetParameterText(int id, string[] columns)
        {
            Parameter parameter = await Repository.FirstOrDefaultAsync(x=>x.Id == id);
            return parameter?.Text;
        }
    }
}
