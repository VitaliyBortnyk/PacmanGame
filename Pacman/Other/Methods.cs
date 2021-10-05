using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Text;

namespace Pacman
{
    static class Methods
    {
        public static User GetCurrentUser()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(Resource.CurrentUserPath, FileMode.OpenOrCreate))
                {
                    return (User)bf.Deserialize(fs);
                }
            }
            catch { };

            return new User(null, null);
        }

        public static void Save(string path, FileMode fileMode, object obj)
        {
            FileStream fs = new FileStream(path, fileMode);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, obj);

            fs.Close();
        }

        [DllImport("winmm.dll")]

        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        public static void PlaySound(string sound)
        {
            StringBuilder sb = new StringBuilder();

            mciSendString("open \"" + @sound, sb, 0, IntPtr.Zero);
            mciSendString("play " + sound, sb, 0, IntPtr.Zero);
        }
    }
}
