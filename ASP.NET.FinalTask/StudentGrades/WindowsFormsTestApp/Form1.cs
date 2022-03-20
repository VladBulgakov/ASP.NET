using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentGradesDAL;

namespace WindowsFormsTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StudentGradesContext sgCont = new StudentGradesContext();
            dataGridView1.DataSource = sgCont.Students.ToList();
        }
    }
}
