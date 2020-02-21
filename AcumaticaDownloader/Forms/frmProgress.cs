using System.Windows.Forms;

namespace AcuDevDeployer
{
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();
        }

        public int ProgressValue { get { return progressBar1.Value; } set { progressBar1.Value = value; } }
        public int ProgressMax { get { return progressBar1.Maximum; } set { progressBar1.Maximum = value; } }
        public string ProgressMessage { get { return lblMessage.Text; } set { lblMessage.Text = value; } }
    }
}