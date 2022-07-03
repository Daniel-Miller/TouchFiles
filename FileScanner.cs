internal class FileScanner
{
    public int Touch(string directory, string pattern)
    {
        int count = 0;

        DirectoryInfo di = new(directory);
        FileSystemInfo[] files = di.GetFileSystemInfos(pattern);
        foreach (FileSystemInfo file in files)
        {
            string filetype = ((file.Attributes & FileAttributes.Directory) == 0) ? "file   " : "folder ";

            Console.Write("Touching " + filetype + file.FullName);

            file.LastWriteTime = DateTime.Now;

            Console.Write(" OK\n");
            count++;
        }

        DirectoryInfo[] dirs = di.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            int temp = Touch(dir.FullName, pattern);
            if (temp >= 0)
                count += temp;
            else
                return -1;
        }

        return count;
    }
}