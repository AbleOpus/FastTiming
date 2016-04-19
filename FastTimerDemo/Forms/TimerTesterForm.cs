using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastTimerDemo.Forms
{
    public partial class TimerTesterForm : Form
    {
        public TimerTesterForm()
        {
            InitializeComponent();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(UserControl))))
            {
                var newUC = (UserControl)Activator.CreateInstance(type);
                newUC.Dock = DockStyle.Fill;
                var page = new TabPage(newUC.Text);
                page.Controls.Add(newUC);
                tabControl.TabPages.Add(page);

            }
        }
    }
}
