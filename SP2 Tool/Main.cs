using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace SP2_Tool
{
    public partial class Main : Form
    {
        public Main(string[] args)
        {
            InitializeComponent();
        }

        void File_OpenSP2_Click(object sender, EventArgs e)
        {
            ofd_OpenFiles.Title = "Please select a SP2 file...";
            ofd_OpenFiles.Filter = "SP2 Files|*.sp2";
            ofd_OpenFiles.DefaultExt = "sp2";

            if (ofd_OpenFiles.ShowDialog() == DialogResult.OK)
            {
                Program.TempData.Delete();
                ParseSP2();
            }
        }

        void ParseSP2()
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();

                using (var fs = new FileStream(ofd_OpenFiles.FileName, FileMode.Open))
                {
                    FileStream fout = null;
                    byte[] buf = new byte[1024];
                    int blen = 0;

                    int file = 0, mode = -1;

                    // mode:
                    // 0-2 'DDS '
                    // 0, 3-4 'DXBC'

                    while (true)
                    {
                        blen = fs.Read(buf, 0, buf.Length);
                        if (blen == 0) break;
                        int index = 0, startpos = 0;

                        for (int i = 0; i < blen; i++)
                        {
                            // check if we need to change mode

                            switch ((char)buf[i])
                            {
                                case 'D':
                                    if (mode == -1 || mode == 0)
                                    {
                                        if (mode == -1) startpos = i;
                                        mode++;

                                    }
                                    else goto default;
                                    break;

                                case 'S':
                                    if (mode == 1)
                                        mode = 2;
                                    else goto default;
                                    break;

                                case ' ':
                                    if (mode == 2)
                                    {
                                        mode = -1;

                                        // write data into disk
                                        if (startpos > 0)
                                        {
                                            if (fout == null)
                                                throw new Exception("No file was defined before data was to be written to disk! " + (fs.Position - buf.Length + startpos));

                                            fout.Write(buf, index, startpos - index);
                                            fout.Dispose();
                                            index = startpos;
                                        }

                                        // dis is dds file, process as dds
                                        //  Console.WriteLine("DDS " + file + " at " + (File.Position + startpos).ToString("X"));
                                        string filePth = Path.Combine(
                                            Program.TempDir, $"{file++}.dds");

                                        fout = new FileStream(filePth, FileMode.Create);
                                        Program.TempData.AddFile(filePth, false);

                                    }
                                    else goto default;
                                    break;

                                case 'X':
                                    if (mode == 0)
                                        mode = 3;
                                    else goto default;
                                    break;

                                case 'B':
                                    if (mode == 3)
                                        mode = 4;
                                    else goto default;
                                    break;

                                case 'C':
                                    if (mode == 4)
                                    {
                                        mode = -1;

                                        // write data into disk
                                        if (startpos > 0)
                                        {
                                            if (fout == null)
                                                throw new Exception("No file was defined before data was to be written to disk! " + (fs.Position - buf.Length + startpos));

                                            fout.Write(buf, index, startpos - index);
                                            fout.Dispose();
                                            index = startpos;
                                        }

                                        // dis is dxbc file
                                        //  Console.WriteLine("DXBC "+ file +" at " + (File.Position + startpos).ToString("X"));
                                        string filePth = Path.Combine(
                                            Program.TempDir, $"{file++}.o");

                                        fout = new FileStream(filePth, FileMode.Create);
                                        Program.TempData.AddFile(filePth, false);

                                    }
                                    else goto default;
                                    break;

                                default:
                                    mode = -1;
                                    break;
                            }
                        }

                        if (fout == null)
                            throw new Exception("No file was defined before data was to be written to disk! " + fs.Position);

                        // write data into file
                        if (mode == -1)
                        {
                            fout.Write(buf, index, blen - index);
                        }
                        else
                        {
                            // uh oh, mode was not cleared, this means we read part of the header.
                            fout.Write(buf, index, startpos - index);
                            fs.Seek(buf.Length - startpos, SeekOrigin.Current);
                        }
                    }

                    fout?.Dispose();
                }

                sw.Stop();
                //Console.WriteLine("Complete in " + sw.ElapsedMilliseconds + "ms");

                sdk_CreateSP2.Enabled = true;
                web_Explorer.Navigate(Program.TempDir);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                MessageBox.Show($"An error occurred:\n\n{ex}", "Fatal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void File_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void File_OpenFolder_Click(object sender, EventArgs e)
        {
            fbd_OpenFolder.Description = "Select a folder that contains DDS files.";
            if (fbd_OpenFolder.ShowDialog() == DialogResult.OK)
            {
                web_Explorer.Navigate(fbd_OpenFolder.SelectedPath);
            }
        }

        void CreateSP2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /********************************************/
            /*    VERY INCOMPLETE AND UNUSABLE CODE!!   */
            /********************************************/

            MessageBox.Show("This may produce undesirable results and the resulting SP2 file may not work with Team Sonic Racing.\n\nPlease visit the GitHub page for more information.",
                "SP2 Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            string currentPath = web_Explorer.Url.ToString().Replace("file:///", "").Replace("/", @"\") + @"\";

            if (Directory.GetFiles(currentPath, "*.dds").Length == 0)
            {
                MessageBox.Show("There are no DDS files to pack in this directory.",
                    "No DDS files available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var getDDS = new StringBuilder();
                // get all DirectDraw Surface textures
                var allDDS = Directory.GetFiles(currentPath, "*.dds",
                    SearchOption.TopDirectoryOnly).OrderBy(f =>
                {
                    int number;
                    if (int.TryParse(Path.GetFileNameWithoutExtension(f), out number))
                        return number;
                    else
                        return -1; // or some other fallback value
                });
                foreach (string DDS in allDDS)
                {
                    //Console.WriteLine("{0}", DDS);
                    getDDS.Append("\"");
                    getDDS.Append(Path.GetFileName(DDS));
                    getDDS.Append("\"");
                    getDDS.Append(" + ");
                }

                // get all DirectX Shader Bytecode
                var allDXBC = Directory.GetFiles(currentPath, "*.o",
                    SearchOption.TopDirectoryOnly).OrderBy(f =>
                {
                    int number;
                    if (int.TryParse(Path.GetFileNameWithoutExtension(f), out number))
                        return number;
                    else
                        return -1; // or some other fallback value
                });

                foreach (string O in allDXBC)
                {
                    //Console.WriteLine("{0}", O);
                    getDDS.Append("\"");
                    getDDS.Append(Path.GetFileName(O));
                    getDDS.Append("\"");
                    getDDS.Append(" + ");
                }

                var allFiles = getDDS.ToString().Remove(getDDS.ToString().Length - 3);
                //MessageBox.Show(allFiles);
                var createSP2 = new ProcessStartInfo("cmd.exe", $"/C copy /b {allFiles} sonic.gpu.sp2");
                createSP2.WorkingDirectory = currentPath;
                createSP2.WindowStyle = ProcessWindowStyle.Hidden;
                var begin = Process.Start(createSP2);
                begin.WaitForExit();
                begin.Close();

                //ofd_OpenFiles.Title = "Please select the original SP2 file.";

                //if (ofd_OpenFiles.ShowDialog() == DialogResult.OK)
                //{

                //}
            }
        }

        void Main_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "SP2 Tool\n" +
                "Developed by Hyper Development Team\n\n" + Program.VersionString +
                "\n\nCredits:\n" +
                "Hyper - Lead Developer\n" +
                "Radfordhound - Developer/Reverse-Engineer\n" +
                "Natsumi - Byte Parser\n" +
                "Beatz - Researcher",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Main_Load(object sender, EventArgs e)
        {
            // Update window title
            Text = $"SP2 Tool ({Program.VersionString})";
        }

        void Main_GitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/HyperPolygon64/SP2-Tool");
        }
    }
}
