using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpResultToObjectModel.DAL
{
    public class SpExecuter
    {
        public TModel Execute<TModel>(string procedureName) where TModel : class
        {
            SqlCommand command = new SqlCommand(procedureName, ConnectionProvider.Instance.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            TModel model = Activator.CreateInstance<TModel>();
            while (reader.Read())
            {
                model = ConvertToModel<TModel>(reader);
            }
            reader.Close();

            return model;
        }

        public IList<TModel> ExecuteForList<TModel>(string procedureName) where TModel : class
        {
            SqlCommand command = new SqlCommand(procedureName, ConnectionProvider.Instance.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            IList<TModel> modelList = Activator.CreateInstance<List<TModel>>();

            while (reader.Read())
            {
                TModel model = ConvertToModel<TModel>(reader);
                modelList.Add(model);
            }
            reader.Close();

            return modelList;
        }

        private TModel ConvertToModel<TModel>(SqlDataReader reader) where TModel : class
        {
            TModel model = Activator.CreateInstance<TModel>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                PropertyInfo propertyInfo = typeof(TModel).GetProperty(reader.GetName(i));
                if (propertyInfo == null)
                {
                    continue;
                }
                propertyInfo.SetValue(model, reader.GetValue(i), null);
            }

            return model;
        }
    }
}
