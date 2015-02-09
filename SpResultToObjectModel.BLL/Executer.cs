using SpResultToObjectModel.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpResultToObjectModel.BLL
{
    public class Executer
    {
        private readonly SpExecuter spExecuter;

        public Executer()
        {
            spExecuter = new SpExecuter(); 
        }

        public TModel Execute<TModel>(string procedureName) where TModel : class
        {
            TModel model = spExecuter.Execute<TModel>(procedureName);

            return model;
        }

        public IList<TModel> ExecuteForList<TModel>(string procedureName) where TModel : class
        {
            IList<TModel> modelList = spExecuter.ExecuteForList<TModel>(procedureName);

            return modelList;
        }
    }
}
