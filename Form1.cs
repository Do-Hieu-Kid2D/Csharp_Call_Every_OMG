using System.Diagnostics;
using System.Numerics;

namespace Csharp_Call_Python_Dkid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Cái này phát cái là nó là python.exe -> k can thiệp đc luôn!

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.WorkingDirectory = Application.StartupPath + "\\Resorc";
                startInfo.FileName = @"D:\app\python\python.exe";
                startInfo.Arguments = $" chuyen.py vi \"{textBox1.Text}";  //truyền đc txt cần nói sang python
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process p = Process.Start(startInfo);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Gọi open file để lấy 1 file mp3! 
            openFileDialog1.Filter = "MP3 Audio File|*.mp3";
            openFileDialog1.Title = "Chọn tệp MP3 để mở";
            string filePath = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                textBox2.Text = filePath;
            }
            // có đường dẫ mp3 rồi làm sao gọi python phát đây

            // Setup cho đối tượng ProcessStartInfo -> thằng này để truyền vào Process 
            // và thằng process sẽ chạy thằng startinfo này  - cái này là python.exe rồi nha
            ProcessStartInfo startsInfo = new ProcessStartInfo(); // new ra
            startsInfo.CreateNoWindow = true;  // không tạo cửa sổ trực quan = true;
            startsInfo.UseShellExecute = false; // k sử dụng (cmd.exe) để chạy chương trình.
            startsInfo.FileName = @"D:\app\python\python.exe";  // file name muốn chạy là java.exe
            startsInfo.WindowStyle = ProcessWindowStyle.Hidden;   // không hiện cửa sổ đối tượng j đó...
            startsInfo.RedirectStandardOutput = true;   // Đầu ra của trương trinh java.exe sẽ thông qua luồng đầu ra chuẩn -> mày có thể đọc        
            startsInfo.WorkingDirectory = Application.StartupPath + "\\Resorc";  // nơi làm việc của chương trình java.exe (CT phụ mk đang gọi)
            startsInfo.Arguments = $"phatNhac.py \"{filePath}\""; // Tham số đc truyền vào chương trình đó.
            try
            {
                // oke đấy -> đoạn này là tạo 1 process vói 1 ttham số ProcessStartInfo!
                // và gọi phương thức start để chạy luôn
                using (Process exe = Process.Start(startsInfo))
                {
                    // Chương trình chính đợi thằng process chạy! 
                    exe.WaitForExit();
                }
                  
            }
            catch (Exception ex) { ex.ToString(); }
        }
    }
}