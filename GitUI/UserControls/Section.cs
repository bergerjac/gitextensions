using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitUI.UserControls
{
    public partial class Section : UserControl
    {
        readonly SectionInfo info;

        public Section()
        {
            InitializeComponent();
        }

        public Section(SectionInfo info)
        {
            this.info = info;
            btnObject.Text = info.Title;
            btnObject.Click += OnClick;


        }

        void OnClick(object sender, EventArgs e)
        {
            info.OnSelecting();
            if (Selected != null)
            {
                Selected(this, EventArgs.Empty);
            }
            info.OnSelected();
        }

        void Expand()
        {
            if (info.Children == null) { return; }

            ParallelLoopResult result = Parallel.ForEach(
                  info.Children,
                  new ParallelOptions { TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext() },
                  AddChild
              );
        }

        void AddChild(SectionInfo child)
        {
            layoutChildren.Controls.Add(new Section(child));
        }

        public event EventHandler Selected;
    }

    public class SectionInfo
    {
        public string Title { get; set; }
        public Action OnSelecting { get; set; }
        public Action OnSelected { get; set; }
        public IEnumerable<SectionInfo> Children { get; set; }
    }
}
