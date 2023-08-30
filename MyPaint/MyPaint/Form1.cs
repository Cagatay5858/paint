﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(1024, 768);
        Pen p = new Pen(Color.Black, 5);
        bool d = false;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (d)
                d = false;
            else
                d = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(d)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawEllipse(p, e.X, e.Y, 3, 1);
                pictureBox1.Image = bmp;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            p.Color = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            p.Color = Color.Lime;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            p.Color = Color.DodgerBlue;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            p.Color = Color.DarkOrange;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            p.Color = Color.Magenta;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            p.Color = Color.Black;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image *.bmp|";
            saveFileDialog1.Title = "Dosyayi Kaydedin";
            saveFileDialog1.ShowDialog();

            if(saveFileDialog1.FileName !="")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch(saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                }
            }
        }
    }
}
