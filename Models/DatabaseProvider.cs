using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject.Models
{
    public class DatabaseProvider
    {
        /// <summary>
        /// This class is to provide the basic abstraction to the database
        /// </summary>
        private static Database dbInstance=null;
        /// <summary>
        /// Private Constructor
        /// </summary>
        private DatabaseProvider()
        {

        }
        /// <summary>
        /// Getting the singelton database
        /// </summary>
        /// <returns>Returns the instance of the database</returns>
        public static Database GetDatabase()
        {
            if (dbInstance == null)
            {
                dbInstance=new Database();
            }
            return dbInstance;

        }


    }
}
