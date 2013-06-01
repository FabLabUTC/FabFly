using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Deployment
{
    class Deployment
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deployment started");
            Renci.SshNet.SshClient ssh = new Renci.SshNet.SshClient("10.50.0.10", "pi", "raspberry");
            ssh.Connect();
            Console.WriteLine("Connected to RPI");
            //var shell = ssh.CreateShell(Console.OpenStandardInput(), Console.OpenStandardOutput(), Console.OpenStandardError());
            //shell.Start();
            Renci.SshNet.ScpClient scp = new Renci.SshNet.ScpClient("10.50.0.10", "pi", "raspberry");
            scp.Connect();
            Console.WriteLine("SCP Started");
            ssh.RunCommand("cd /home/pi/Csharp");
            foreach (var x in args)
            {
                ssh.RunCommand("rm \"" + System.IO.Path.GetFileName(x) + "\"");
                scp.Upload(new System.IO.FileInfo(x), "/home/pi/Csharp");
            }
            /*var cmd = ssh.CreateCommand("mono \"" + args[1] + "\"");
            var com = cmd.BeginExecute();
            
            var reader = new StreamReader(ssh.ou);
            while (!com.IsCompleted) Console.Write(reader.ReadToEnd());*/
            Console.WriteLine("\nFinished.");
        }
    }
}
