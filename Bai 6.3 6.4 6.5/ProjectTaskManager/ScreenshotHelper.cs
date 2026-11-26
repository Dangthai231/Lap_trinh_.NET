using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProjectTaskManager.GUI;

namespace ProjectTaskManager
{
    public static class ScreenshotHelper
    {
        public static void CaptureScreenshots()
        {
            string outDir = @"D:\Lap_trinh_.NET\Bai 6.3 6.4 6.5\screenshot";
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            Console.WriteLine("Đang chụp ảnh giao diện các màn hình...");

            FormMain frm = new FormMain();
            frm.Show();
            Application.DoEvents();
            Thread.Sleep(500);

            // Tìm TabControl
            TabControl tc = null;
            foreach (Control c in frm.Controls)
            {
                if (c is TabControl t)
                {
                    tc = t;
                    break;
                }
            }

            // 1. Chụp Tab Kanban (Tab 0)
            if (tc != null) tc.SelectedIndex = 0;
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frm, Path.Combine(outDir, "6.3_KanbanBoard.jpg"));

            // 2. Chụp Tab List View (Tab 1)
            if (tc != null) tc.SelectedIndex = 1;
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frm, Path.Combine(outDir, "6.3_ListView.jpg"));

            // 3. Chụp Tab Dự án (Tab 2)
            if (tc != null) tc.SelectedIndex = 2;
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frm, Path.Combine(outDir, "6.3_QuanLyDuAn.jpg"));

            // 4. Chụp Tab Thành viên (Tab 3)
            if (tc != null) tc.SelectedIndex = 3;
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frm, Path.Combine(outDir, "6.3_QuanLyThanhVien.jpg"));

            // 5. Chụp Tab Cảnh báo trễ hạn & Báo cáo (Tab 4)
            if (tc != null) tc.SelectedIndex = 4;
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frm, Path.Combine(outDir, "6.3_CanhBaoTreHan_BaoCao.jpg"));

            frm.Close();

            // 6. Chụp Form Thêm / Sửa Task
            FormTask frmTask = new FormTask(3); // Task 3
            frmTask.Show();
            Application.DoEvents();
            Thread.Sleep(500);
            SaveFormImage(frmTask, Path.Combine(outDir, "6.3_FormTask_PhanCong.jpg"));
            frmTask.Close();

            Console.WriteLine("Đã lưu tất cả ảnh chụp màn hình vào: " + outDir);
        }

        private static void SaveFormImage(Form f, string filePath)
        {
            using (Bitmap bmp = new Bitmap(f.Width, f.Height))
            {
                f.DrawToBitmap(bmp, new Rectangle(0, 0, f.Width, f.Height));
                bmp.Save(filePath, ImageFormat.Jpeg);
                Console.WriteLine("Saved: " + filePath);
            }
        }
    }
}
