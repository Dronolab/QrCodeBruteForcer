using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace qrcode
{
    public partial class Form1 : Form
    {
        

        public int GridSize;
        private QrCodeWorker.caseType[,] qrArray;
        private BackgroundWorker bg;
        private List<Tuple<string, QrCodeWorker.caseType[,]>> resultTab = new List<Tuple<string, QrCodeWorker.caseType[,]>>();
        private about aboutWin = new about();

        public Form1()
        {
            GridSize = 15;
            InitQrArray(GridSize);
            aboutWin.Hide();
            InitializeComponent();

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitQrArray(GridSize);
            UpdateCombinaisonCount();
            qrDisplay.Refresh();
        }

        private void InitQrArray(int size)
        {
            qrArray = new QrCodeWorker.caseType[size, size];
        }

        private void qrDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            try {
                ChangeCases(new Point(e.X, e.Y), e.Button);
            }
            catch (Exception err) { CombinaisonsCount.Text = err.Message; }

        }

        private void ChangeCases(Point pos, MouseButtons btn)
        {
            int x, y;
            x = pos.X / ((qrDisplay.Size.Height) / GridSize);
            y = pos.Y / ((qrDisplay.Size.Width) / GridSize);

            if (x >= GridSize || y >= GridSize)
                return;

            //Console.WriteLine("X=" + x + "\tY=" + y);
            switch (btn)
            {
                case MouseButtons.Left:
                    if (qrArray[x, y] != QrCodeWorker.caseType.Black)
                        qrArray[x, y] = QrCodeWorker.caseType.Black;
                    else
                        return;
                        break;

                case MouseButtons.Right:
                    if (qrArray[x, y] != QrCodeWorker.caseType.White)
                        qrArray[x, y] = QrCodeWorker.caseType.White;
                    else
                        return;
                    break;

                case MouseButtons.Middle:
                    if (qrArray[x, y] != QrCodeWorker.caseType.Unknown)
                        qrArray[x, y] = QrCodeWorker.caseType.Unknown;
                    else
                        return;
                    break;

                default:
                    break;

            }
            UpdateCombinaisonCount();
            qrDisplay.Refresh();
        }

        private Int64 GetCombinaisonsCount(QrCodeWorker.caseType[,] array)
        {
            int count = 0;
            for (int line = 0; line < qrArray.GetLength(0); line++)
            {
                for (int col = 0; col < qrArray.GetLength(1); col++)
                {
                    if (qrArray[line, col] == QrCodeWorker.caseType.Unknown)
                    {
                        count++;
                    }
                }
            }
            return Convert.ToInt64(Math.Pow(2, count));
        }

        private void UpdateCombinaisonCount()
        {
            CombinaisonsCount.Text = "Combinaisons : " + GetCombinaisonsCount(qrArray);
        }

        private void qrDisplay_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var whitePen    = new Pen(Color.White   , 1);
                var grayPen     = new Pen(Color.Gray    , 1);
                var BlackPen    = new Pen(Color.Black   , 1);


                for (int line = 0; line < qrArray.GetLength(0); line++)
                {
                    for (int col = 0; col < qrArray.GetLength(1); col++)
                    {
                        QrCodeWorker.caseType val = qrArray[line, col];
                        Size s = new Size(((qrDisplay.Size.Height + 0) / GridSize)-1, ((qrDisplay.Size.Width + 0) / GridSize)-1);
                        Point loc = new Point(line * s.Height + line, col * s.Width + col);
                        //Console.Write(val + "\t");
                        switch (val)
                        {
                            case QrCodeWorker.caseType.Black:
                                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(loc, s));
                                break;
                            case QrCodeWorker.caseType.White:

                                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(loc, s));
                                break;
                            case QrCodeWorker.caseType.Unknown:

                                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(loc, s));
                                break;
                        }
                    }
                }
            }
        }

        private void generateAllPossibilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bg = new BackgroundWorker();
            
            bg.WorkerReportsProgress = true;
            bg.DoWork += Bg_DoWork;
            bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
            CombinaisonsCount.Text = "Running all " + GetCombinaisonsCount(qrArray) + " Possibilities ...";
            UseWaitCursor = true;
            this.Enabled = false;
            bg.RunWorkerAsync(qrArray);
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var compressedResults = new Dictionary<string, Int64>();
            var result = e.Result as List<Tuple<string, QrCodeWorker.caseType[,]>>;
            resultTab = result;
            listBox1.Items.Clear();
            int notEmpty = 0;
            
            foreach(Tuple<string, QrCodeWorker.caseType[,]> keyVal in result)
            {
                listBox1.Items.Add((string)keyVal.Item1);
                if ((string)keyVal.Item1 != "")
                    notEmpty++;


                if (compressedResults.ContainsKey((string)keyVal.Item1))
                    compressedResults[(string)keyVal.Item1]++;
                else
                    compressedResults.Add((string)keyVal.Item1, 1);
            }
            foreach (KeyValuePair<string, Int64> keyVal in compressedResults)
                listBox1.Items.Insert(0, string.Format(keyVal.Key + "(" + keyVal.Value + ")"));

            result.Insert(0, new Tuple<string, QrCodeWorker.caseType[,]>("QR Source", qrArray));
            this.Enabled = true;
            this.UseWaitCursor = false;

            CombinaisonsCount.Text = "Done. " + result.Count + " Results... (" + notEmpty + " not empty)";
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitQrArray(resultTab.ElementAt(listBox1.SelectedIndex).Item2.GetLength(0));
            qrArray = resultTab.ElementAt(listBox1.SelectedIndex).Item2;
            UpdateCombinaisonCount();
            qrDisplay.Refresh();
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            var qrCodeArray = (QrCodeWorker.caseType[,])e.Argument;
            QrCodeWorker qr = new QrCodeWorker(qrCodeArray.GetLength(0));
            bg.ReportProgress(0, "Generating all " + GetCombinaisonsCount(qrCodeArray) + " combinaisons and decoding them...");
            var result = qr.ProcessQRcode(qrCodeArray);
            bg.ReportProgress(0, "Successfully generated and decoded " + result.Count + " QR codes..");
            e.Result = result;
        }

        private void gridSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompts.ShowDialog("Select a QR Code size", "Bob Ross", GridSize);
            GridSize = promptValue;
            InitQrArray(promptValue);
            UpdateCombinaisonCount();
            qrDisplay.Refresh();
        }

        private void loadTestQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridSize = 21;
            InitQrArray(21);
            UpdateCombinaisonCount();
            char[,] testArray = new char[,]{
                {'0','0','0','0','0','0','0','1','0','0','1','0','0','1','0','0','0','0','0','0','0'},
                {'0','1','1','1','1','1','0','1','0','0','1','1','0','1','0','1','1','1','1','1','0'},
                {'0','1','0','0','0','1','0','1','1','1','1','0','0','1','0','1','0','0','0','1','0'},
                {'0','1','0','0','0','1','0','1','0','1','1','1','0','1','0','1','0','0','0','1','0'},
                {'0','1','0','0','0','1','0','1','1','1','0','1','1','1','0','1','0','0','0','1','0'},
                {'0','1','1','1','1','1','0','1','1','0','1','1','0','1','0','1','1','1','1','1','0'},
                {'0','0','0','0','0','0','0','1','0','1','0','1','0','1','0','0','0','0','0','0','0'},
                {'1','1','1','1','1','1','1','1','0','1','0','0','0','1','1','1','1','1','1','1','1'},
                {'1','0','0','1','0','0','0','0','1','0','1','1','0','0','0','1','1','0','1','0','0'},
                {'1','1','1','1','0','0','1','1','1','1','0','1','1','1','1','1','0','1','0','0','1'},
                {'0','0','0','1','0','0','0','1','0','1','0','0','0','0','0','1','1','1','0','0','0'},
                {'1','1','0','1','0','1','1','1','0','0','0','1','0','1','0','1','1','1','0','0','1'},
                {'0','0','1','0','0','1','0','1','0','1','1','0','1','1','0','1','0','1','1','0','1'},
                {'1','1','1','1','1','1','1','1','1','0','0','0','1','0','1','1','0','0','0','1','0'},
                {'0','0','0','0','0','0','0','1','0','0','0','0','0','0','0','0','0','0','0','1','1'},
                {'0','1','1','1','1','1','0','1','0','0','0','1','0','0','0','1','0','0','0','1','0'},
                {'0','1','0','0','0','1','0','1','0','0','1','0','0','1','0','0','0','0','0','1','0'},
                {'0','1','0','0','0','1','0','1','1','0','0','0','1','1','0','0','1','1','1','1','0'},
                {'0','1','0','0','0','1','0','1','0','1','0','1','1','0','1','1','1','1','0','1','0'},
                {'0','1','1','1','1','1','0','1','0','0','1','0','0','0','0','0','0','0','1','1','0'},
                {'0','0','0','0','0','0','0','1','1','0','0','1','0','1','1','1','1','0','0','1','1'}
                };
            for (int line = 0; line < qrArray.GetLength(0); line++)
            {
                for (int col = 0; col < qrArray.GetLength(1); col++)
                {
                    if (testArray[line, col] == '0')
                        qrArray[line, col] = QrCodeWorker.caseType.Black;
                    else
                        qrArray[line, col] = QrCodeWorker.caseType.White;
                    //if (qrArray[line, col] == QrCodeWorker.caseType.Black)
                    //    Console.Write(''0',');
                    //else
                    //    Console.Write(''1',');
                }
                //Console.Write('\n');
            }
            qrDisplay.Refresh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutWin.ShowDialog();
        }

        private void qrDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            try {
                if (e.Button != MouseButtons.None)
                    ChangeCases(new Point(e.X, e.Y), e.Button);
            }
            catch (Exception err) { CombinaisonsCount.Text = err.Message; }
        }
    }
}
