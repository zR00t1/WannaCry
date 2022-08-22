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

namespace WannaCrydemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Chinese";
            comboBox1.SelectedIndex = 0;

            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString("MM/dd/yyyy HH:mm:ss");
            label2.Text = dt.ToString("MM/dd/yyyy HH:mm:ss");
        }

        public void getCurrentTime()
        {
            DateTime dt = DateTime.Now;
            label1.Text = dt.ToString("MM/dd/yyyy HH:mm:ss");
            label2.Text = dt.ToString("MM/dd/yyyy HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
            Clipboard.SetDataObject(textBox1.Text);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = @"我的电脑出了什么问题？
您的一些重要文件被我加密保存了
照片、图片、文档、压缩包、音频、视频文件、exe文件等，几乎所有类型的文件都被加密了，因此不能正常打开。
这和一般文件损坏有本质上的区别，您大可在网上找找恢复文件的方法，我很保证，没有我们的解密服务，就算老天爷来了也不能恢复这些文档。

有没有恢复这些文档的方法？
当然有可恢复的方法。只能通过我们的解密服务才能恢复。以人格担保，能够提供安全有效的恢复服务。
但这是收费的，也不能无限的推迟。
请点击<Decrypt>按钮，就有机会免费恢复一些文档。请您放心，我是绝不会骗你的。
但想要恢复全部文档，需要付款点费用。
是否随时都可以固定金额付款，就会恢复吗，当然不是，推迟付款时间越长对你越不利。
最好当天马上付款费用，每过一天费用就会翻倍。
还有，指定时间之内未付款，将会永远恢复不了。
对了，忘了告诉你，对半年以上没钱付款的穷人，会有活动免费恢复，能否轮到您就看运气了。";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = @"What's wrong with my computer?
Some of your important files were saved by my encryption
Photos, pictures, documents, compressed packages, audio, video files, exe files, etc., almost all types of files are encrypted, and therefore can not open normally.
This is a fundamental difference between the general file damage, you can find a way to restore the file on the Internet, I guarantee that we do not have the decryption service, even if God can not restore these documents.
Is there a way to restore these documents?
Of course there are recoverable methods. Can only be restored through our decryption service. To provide a safe and effective recovery service.
But this is a charge, and can not be infinitely delayed.
Please click the <Decrypt> button and have the opportunity to recover some documents for free. Please rest assured that I will never lie to you.
But you want to restore all documents, you need to pay the cost.
Whether it can be fixed at any time the amount of payment, will be restored, of course not, the longer the delay in the payment of the more unfavorable to you.
It is best to pay the day immediately, every day the cost will be doubled.
Also, within the specified time without payment, will never be restored.
Yes, forgot to tell you, for more than six months no money to pay the poor, there will be free to resume activities, can turn to see you luck.";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://bitcoin.org/en/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://bitcoin.org/en/exchanges");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/zR00t1/WannaCry/issues/1");
        
        }

        int seconds3 = 172800;
        int seconds7 = 518400;

        private void timer1_Tick(object sender, EventArgs e)
        {
            getCurrentTime();
            seconds3 --;
            label3.Text = new DateTime(1970, 01, 01, 00, 00, 00).AddSeconds(seconds3).ToString("dd:HH:mm:ss");
            seconds7--;
            label4.Text = new DateTime(1970, 01, 01, 00, 00, 00).AddSeconds(seconds7).ToString("dd:HH:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
