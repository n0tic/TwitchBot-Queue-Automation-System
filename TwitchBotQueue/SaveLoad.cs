using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotQueue
{
    public static class SaveLoad
    {
        #region BinaryFormatter Save
        public static bool DoesSaveExist(int? saveID)
        {
            string filename;

            if (saveID != null)
                filename = "data" + saveID + ".dat";
            else
                filename = "data.dat";

            return File.Exists(filename) ? true : false;
        }

        public static bool SaveDataToFile(object data, int? saveID)
        {
            FileStream fs;
            bool returnState;

            if (saveID != null)
                fs = new FileStream("data" + saveID + ".dat", FileMode.Create);
            else
                fs = new FileStream("data.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, data);
                returnState = true;
            }
            catch (System.Exception e)
            {
                returnState = false;
            }

            fs.Close();
            return returnState;
        }

        public static object LoadFromFile<T>(int? saveID)
        {
            object _data;
            string filename;

            if (saveID != null)
                filename = "data" + saveID + ".dat";
            else
                filename = "data.dat";

            if (File.Exists(filename))
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    var bformatter = new BinaryFormatter();
                    try
                    {
                        _data = (object)bformatter.Deserialize(stream);
                        stream.Close();
                        return (T)_data;
                    }
                    catch (System.Runtime.Serialization.SerializationException e)
                    {
                        stream.Close();
                        File.Delete(filename);
                        return null;
                    }
                }
            }
            else { return null; }
        }
        #endregion BinaryFormatter Save
    }
}
