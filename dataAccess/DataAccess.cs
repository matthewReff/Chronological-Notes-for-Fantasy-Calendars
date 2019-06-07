using System;

namespace DataAccessors
{
    public class DataAccessor
    {

        #region Properties

        private string _filePath;

        string FilePath {
            get
            {
                return _filePath;
            }
        }

        #endregion

        public DataAccessor(string filePath)
        {
            _filePath = filePath;
        }


    }
}
